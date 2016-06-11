using rr.agent.pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rr.wavesystem {

    [CreateAssetMenuAttribute(menuName = "Wave System/Wave")]
    public class Wave : ScriptableObject {

        public const float NOT_TIMED = 0f;

        public float spawnPeriod = 1f;
        public float duration = Wave.NOT_TIMED;
        public List<Spawn> spawnList = new List<Spawn>();

        public bool IsCleared {
            get {
                foreach (var spawned in spawnList) {
                    if (spawned != null)
                        return true;
                }
                return false;
            }
        }

        public bool IsSpawned {
            get {
                return _nextSpawnIndex >= spawnList.Count;
            }
        }

        private int _nextSpawnIndex = 0;
        private List<GameObject> _spawned = new List<GameObject>();

        public void SpawnNext() {
            if(!IsSpawned) {
                var spawn = spawnList[_nextSpawnIndex];
                var spawnObject = GameObject.Instantiate(spawn.enemyPrefab, spawn.spawnLocation.transform.position, Quaternion.identity) as GameObject;
                spawnObject.GetComponent<AgentWithMovePattern>().pattern = spawn.movementPattern;
                _spawned.Add(spawnObject);

                _nextSpawnIndex++;
            }
        }

        public void Reset() {
            _nextSpawnIndex = 0;
            _spawned.Clear();
        }

        public Wave Clone() {
            var clone = ScriptableObject.CreateInstance<Wave>();
            clone.spawnList = spawnList;
            clone.duration = duration;
            clone.spawnPeriod = spawnPeriod;

            return clone;
        }

    }

}
