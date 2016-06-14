using UnityEngine;
using System.Collections;
using rr.agent.pattern;
using System;

namespace rr.wavesystem {

    /// <summary>
    /// Contains the required data to spawn an enemy.
    /// </summary>
    [Serializable]
    public class Spawn {

        #region FIELDS
            
        // Where to spawn the enemy 
        public GameObject spawnLocation;

        // Which enemy to spawn            
        public GameObject enemyPrefab;

        // Which movement pattern the enemy should have
        public MovePattern movementPattern;

        // Time before next spawn
        public float timeBeforeNextSpawn;

        #endregion

    }

}


