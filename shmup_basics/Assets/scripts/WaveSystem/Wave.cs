using rr.agent.pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rr.wavesystem {

    [CreateAssetMenuAttribute(menuName = "Wave System/Wave")]
    public class Wave : ScriptableObject {

        public const float NOT_TIMED = 0f;

        public float duration = Wave.NOT_TIMED;
        public List<KeyValuePair<Spawn, float>> spawnList = new List<KeyValuePair<Spawn, float>>();

        public bool IsCleared {
            get {
                foreach (var spawned in _spawnedList) {
                    if (spawned != null)
                        return false;
                }
                return true;
            }
        }

        public bool IsSpawned {
            get {
                return _nextSpawnIndex >= spawnList.Count;
            }
        }

        private int _nextSpawnIndex = 0;
        private List<GameObject> _spawnedList = new List<GameObject>();

        public float SpawnNext() {
            if(!IsSpawned) {
                var spawn = spawnList[_nextSpawnIndex].Key;
                var spawnObject = GameObject.Instantiate(spawn.enemyPrefab, spawn.spawnLocation.transform.position, Quaternion.identity) as GameObject;
                spawnObject.GetComponent<AgentWithMovePattern>().pattern = spawn.movementPattern;
                _spawnedList.Add(spawnObject);

                _nextSpawnIndex++;

                return spawnList[_nextSpawnIndex].Value;
            }

            return 0;
        }

        public void Reset() {
            _nextSpawnIndex = 0;
            _spawnedList.Clear();
        }

        public Wave Clone() {
            var clone = ScriptableObject.CreateInstance<Wave>();
            clone.spawnList = spawnList;
            clone.duration = duration;

            return clone;
        }

    }

}
