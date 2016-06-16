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
            
            // With the reference from the opponent we can his name
            // and make it win
            string name = enemy.transform.name.Split('_')[1];
            if (name == "evil") {
                GameObject.Find("GameScreenUI").GetComponent<UIManager>().evilPlayerWin();
            } else {
                GameObject.Find("GameScreenUI").GetComponent<UIManager>().soldierPlayerWin();
            }
            
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
