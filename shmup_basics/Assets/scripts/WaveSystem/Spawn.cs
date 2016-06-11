using UnityEngine;
using System.Collections;
using rr.agent.pattern;

namespace rr.wavesystem {

    /// <summary>
    /// Contains the required data to spawn an enemy.
    /// </summary>
    [CreateAssetMenuAttribute(menuName = "Wave System/Spawn")]
    public class Spawn : ScriptableObject {

        #region FIELDS
            
        // Where to spawn the enemy 
        public GameObject spawnLocation; 
        
        // Which enemy to spawn            
        public GameObject enemyPrefab;

        // Which movement pattern the enemy should have
        public MovePattern movementPattern;

        #endregion

    }

}


