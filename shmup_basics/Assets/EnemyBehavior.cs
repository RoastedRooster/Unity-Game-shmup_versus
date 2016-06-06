using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    int health = 2;

    void Update() {
        if(health <= 0) {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "bullet") {
            health--;
			GameObject.Destroy (coll.gameObject);
        }
    }
}
