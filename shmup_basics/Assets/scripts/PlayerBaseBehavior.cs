using UnityEngine;
using System.Collections;

public class PlayerBaseBehavior : MonoBehaviour {

    [SerializeField]
    private int health = 5;
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0) {
            Debug.Log("Player loose !");
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.transform.tag == "Enemy") {
            // Enemy is in player base
            // Remove life to base
            health--;
            // Destroy enemy gameobject
            GameObject.Destroy(coll.gameObject, 0.5f);
        }
    }
}
