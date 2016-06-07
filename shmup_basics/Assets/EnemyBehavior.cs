using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    int health = 2;
    private ShooterBehavior weapon;

    void Awake() {
        weapon = gameObject.GetComponentInChildren<ShooterBehavior>();
    }

    void Update() {
        if(health <= 0) {
            GameObject.Destroy(gameObject);
        }

        weapon.fire();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "bullet" && coll.gameObject.layer == LayerMask.NameToLayer("bullet_player")) {
            health--;
			GameObject.Destroy (coll.gameObject);
        }
    }
}
