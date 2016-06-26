using System;
using System.Collections.Generic;
using UnityEngine;

namespace rr.wavesystem {

    public enum EndingMode {
        Stop,
        Restart,
        Combine,
        LoopLast,
        InfiniteLast
    }

    public class WaveSystem : MonoBehaviour {

        public EndingMode endingMode = EndingMode.Stop;
        public List<Wave> waveList = new List<Wave>();
        public int waveCount = 0;
        public string playerName;

        private int _currentWaveIndex = 0;
        private Wave _currentWave;
        private float _timeBeforeNextWave = -1f;
        private float _timeBeforeNextSpawn = 0f;
        private bool _stopped = true;
        private UIManager uiManager;
        private FieldGameManager powerupManager;

        public void Start() {
            foreach (var wave in waveList)
                wave.Reset();
            uiManager = GameObject.Find("GameScreenUI").GetComponent<UIManager>();
            powerupManager = GameObject.Find(transform.parent.name + "/FieldManager").GetComponent<FieldGameManager>();
        }

        public void toggle() {
            if(_stopped) {
                _stopped = false;
            } else {
                _stopped = true;
            }
        }

        public void Update() {
            if (_stopped)
                return;

            var currentTime = Time.realtimeSinceStartup;

            if(_currentWave == null || (_timeBeforeNextWave > 0 && _timeBeforeNextWave < currentTime) || _currentWave.IsSpawned && _currentWave.IsCleared) {
                if(_currentWave != null && _currentWave.IsCleared) {
                    // Drop powerup on wave end
                    powerupManager.DropPowerUp();
                }
                _currentWave = GetNextWave();
            }

            if(_timeBeforeNextWave > 0) {
                uiManager.updateWaveTimer(playerName, _timeBeforeNextWave);
            } else {
                uiManager.updateWaveTimer(playerName, 0);
            }

            if(_currentWave == null) {
                _stopped = true;
                return;
            }

            if(!_currentWave.IsSpawned && currentTime > _timeBeforeNextSpawn) {
                var timeTilNext = _currentWave.SpawnNext();
                _timeBeforeNextSpawn = currentTime + timeTilNext;
            }
        }

        void updateWaveCounter() {
            waveCount++;
            uiManager.updateWaveCounter(playerName, waveCount);
        }

        protected Wave GetNextWave() {
            if (_currentWaveIndex < waveList.Count) {
                updateWaveCounter();
                var nextWave = waveList[_currentWaveIndex];
                _currentWaveIndex++;
                return nextWave;
            }
            else {
                switch(endingMode) {
                    case EndingMode.Restart:
                        updateWaveCounter();
                        _currentWaveIndex = 0;
                        var nextWave = waveList[_currentWaveIndex];
                        nextWave.Reset();
                        return nextWave;
                    case EndingMode.InfiniteLast:
                        return _currentWave.Clone();
                    case EndingMode.LoopLast:
                        updateWaveCounter();
                        return _currentWave.Clone();
                    case EndingMode.Combine:
                        updateWaveCounter();
                        _currentWaveIndex++;

                        Wave combinedWave = ScriptableObject.CreateInstance<Wave>();
                        var waveTypesCount = waveList.Count;

                        var div = Mathf.FloorToInt(waveCount / waveTypesCount);
                        var mod = waveCount % waveTypesCount;

                        Wave tmpWave;
                        if(mod > 0) {
                            tmpWave = waveList[mod];
                            combinedWave.spawnList.AddRange(tmpWave.spawnList);
                            combinedWave.duration += tmpWave.duration;
                        }

                        if(div > 0) {
                            tmpWave = waveList[waveTypesCount - 1];
                            for(var i = 0; i < div; i++) {
                                combinedWave.spawnList.AddRange(tmpWave.spawnList);
                                combinedWave.duration += tmpWave.duration;
                            }
                        }

                        return combinedWave;

                    case EndingMode.Stop:
                    default:
                        return null;
                }
            }
        }

    }

}
