using UnityEngine;

public class PlayerBaseBehavior : MonoBehaviour {

    public GameObject enemy;

    [SerializeField]
    private int health = 5;
    private string playerName;

    void Start() {
        playerName = transform.name.Split('_')[0];
    }
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0) {
            enemy.GetComponent<PlayerBehavior>().win();
            
            // With the reference from the opponent we can find his name and make him win
            string name = enemy.transform.name.Split('_')[1];
            GameObject.Find("GameScreenUI").GetComponent<UIManager>().playerWin(name);
        }
	}
    
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.transform.tag == "Enemy") {
            // Remove actual life icon before we decrement health
            GameObject.Find("GameScreenUI").GetComponent<UIManager>().baseTakeDamage(playerName, new int[1] { health });
            // Remove life to base
            health--;
            // Destroy enemy gameobject
            GameObject.Destroy(coll.gameObject, 0.5f);
        }
    }
}
