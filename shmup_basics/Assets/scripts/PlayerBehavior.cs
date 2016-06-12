using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

    public int ControllerIndex;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    public GameObject startingPoint;

    [SerializeField]
    private float health = 5;
    private float startingHealth;
    private Rigidbody2D rb2d;
    private ShooterBehavior weapon;

    public void setControllerIndex(int i) {
        ControllerIndex = i;
    }

    public int getControllerIndex() {
        return ControllerIndex;
    }

    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        weapon = gameObject.GetComponentInChildren<ShooterBehavior>();
        startingHealth = health;
    }

    void Update() {
        if(health <= 0) {
            killPlayer();
        }
    }

    void killPlayer() {
        // TODO : Explosioooooon
        transform.position = startingPoint.transform.position;
        health = startingHealth;
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal_" + ControllerIndex);
        float v = Input.GetAxisRaw("Vertical_" + ControllerIndex);

        rb2d.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);

        if (Input.GetButton("Fire_" + ControllerIndex)) {
            weapon.fire();
        }
    }

    public void win() {
        Debug.Log("Player " + name + " win !");
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "bullet") {
            // Damage player
            health -= coll.GetComponent<BulletBehavior>().getDamage();

            // Destroy the player
			GameObject.Destroy (coll.gameObject);
		} else if (coll.transform.tag == "powerup") {
            Debug.Log("Powerup");
            GameObject.Destroy(coll.gameObject);
        }
	}
}
