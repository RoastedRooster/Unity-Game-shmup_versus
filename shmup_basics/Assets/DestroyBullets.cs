using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "bullet") {
			Destroy (coll.gameObject);
		}
    }

	void OnCollisionExit2D(Collision2D coll) {
		Debug.Log ("Destroy you know");
		if (coll.transform.tag == "Enemy") {
			Destroy (coll.gameObject);
		}
	}
}
