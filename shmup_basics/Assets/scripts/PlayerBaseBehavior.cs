using UnityEngine;
using System.Collections;

public class PlayerBaseBehavior : MonoBehaviour {

    public GameObject enemy;

    [SerializeField]
    private int health = 5;
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0) {
            enemy.GetComponent<PlayerBehavior>().win();
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
