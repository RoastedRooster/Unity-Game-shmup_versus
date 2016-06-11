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

        private int _currentWaveIndex = 0;
        private Wave _currentWave;
        private float _timeBeforeNextWave = -1f;
        private float _timeBeforeNextSpawn = 0f;
        private bool _stopped = false;

        public void Start() {
            foreach (var wave in waveList)
                wave.Reset();
        }

        public void Update() {
            if (_stopped)
                return;

            var currentTime = Time.realtimeSinceStartup;

            if(_currentWave == null || (_timeBeforeNextWave > 0 && _timeBeforeNextWave < currentTime) || _currentWave.IsSpawned && _currentWave.IsCleared) {
                _currentWave = GetNextWave();
            }
            
            if(_currentWave == null) {
                _stopped = true;
                return;
            }

            if(!_currentWave.IsSpawned && currentTime > _timeBeforeNextSpawn) {
                _currentWave.SpawnNext();
                _timeBeforeNextSpawn = currentTime + _currentWave.spawnPeriod;
            }
        }

        protected Wave GetNextWave() {
            if (_currentWaveIndex < waveList.Count) {
                waveCount++;
                var nextWave = waveList[_currentWaveIndex];
                _currentWaveIndex++;
                return nextWave;
            }
            else {
                switch(endingMode) {
                    case EndingMode.Restart:
                        waveCount++;
                        _currentWaveIndex = 0;
                        var nextWave = waveList[_currentWaveIndex];
                        nextWave.Reset();
                        return nextWave;
                    case EndingMode.InfiniteLast:
                        return _currentWave.Clone();
                    case EndingMode.LoopLast:
                        waveCount++;
                        return _currentWave.Clone();
                    case EndingMode.Combine:
                        waveCount++;
                        _currentWaveIndex++;

                        Wave combinedWave = ScriptableObject.CreateInstance<Wave>();
                        var waveTypesCount = waveList.Count;
                        
                        var div = Mathf.FloorToInt(waveCount / waveTypesCount);
                        var mod = waveCount % waveTypesCount;

                        var totalPeriod = 0f;
                        var totalWave = 0;

                        Wave tmpWave;
                        if(mod > 0) {
                            tmpWave = waveList[mod];
                            combinedWave.spawnList.AddRange(tmpWave.spawnList);
                            combinedWave.duration += tmpWave.duration;
                            totalPeriod += tmpWave.spawnPeriod;
                            totalWave++;
                        }

                        if(div > 0) {
                            tmpWave = waveList[waveTypesCount - 1];
                            for(var i = 0; i < div; i++) {
                                combinedWave.spawnList.AddRange(tmpWave.spawnList);
                                combinedWave.duration += tmpWave.duration;
                                totalPeriod += tmpWave.spawnPeriod;
                                totalWave++;
                            }
                        }

                        combinedWave.spawnPeriod = totalPeriod / totalWave;

                        return combinedWave;

                    case EndingMode.Stop:
                    default:
                        return null;
                }
            }
        }

    }

}
