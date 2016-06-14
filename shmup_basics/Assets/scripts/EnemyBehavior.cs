using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]
    private float health = 2;
    private float fireRateCoefficient = 1;
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
            health -= coll.GetComponent<BulletBehavior>().getDamage();
            GameObject.Destroy (coll.gameObject);
        }
    }

    public float getFireRateCoefficient() {
        return fireRateCoefficient;
    }

    public void setFireRateCoefficient(float newValue) {
        fireRateCoefficient = newValue;
    }
}
