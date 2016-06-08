using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "bullet") {
			Destroy (coll.gameObject);
		}
    }
}
