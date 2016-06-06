using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "bullet") {
			GameObject.Destroy (coll.gameObject);

        }
    }
}
