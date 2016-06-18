using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

    public int ControllerIndex;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    public GameObject startingPoint;
    
    private float health = 5;
    private float startingHealth;
    [SerializeField]
    private float fireRateCoefficient = 1;
    private Rigidbody2D rb2d;
    private ShooterBehavior weapon;
    private string playerName;

    public void setControllerIndex(int i) {
        ControllerIndex = i;
    }

    public int getControllerIndex() {
        return ControllerIndex;
    }

    public float getFireRateCoefficient() {
        return fireRateCoefficient;
    }

    public void setFireRateCoefficient(float newValue) {
        fireRateCoefficient = newValue;
    }

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        weapon = gameObject.GetComponentInChildren<ShooterBehavior>();
        startingHealth = health;
        playerName = transform.name.Split('_')[1];
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
        Debug.Log(playerName);
        GameObject.Find("GameScreenUI").GetComponent<UIManager>().resetPlayerLife(playerName);
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
            float damage = coll.GetComponent<BulletBehavior>().getDamage();
            float[] indexes = new float[(int) damage];
            indexes.Initialize();
            
            for (int i = 0; i < damage; i++) {
                if(health > 0) {
                    // Stock life icone to remove
                    indexes[i] = health;
                }
                // Damage player
                health -= 1;
            }

            // Hide loosed life icon(s)
            GameObject.Find("GameScreenUI").GetComponent<UIManager>().playerTakeDamage(playerName, indexes);

            // Destroy the bullet
            GameObject.Destroy (coll.gameObject);
		}
	}
}
