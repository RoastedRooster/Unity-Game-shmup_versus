using UnityEngine;
using System.Collections;

public class DestroyEnemies : MonoBehaviour {
    
	void OnTriggerEnter2D (Collider2D coll) {
        if(coll.transform.tag == "Enemy") {
            // Enemy is in player base
            GameObject.Destroy(coll.gameObject, 0.5f);
        }
	}
}
