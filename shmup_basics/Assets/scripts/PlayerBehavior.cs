using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

    public int ControllerIndex;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;
    public float invulnerabilityTime = 1.0f;

    public GameObject startingPoint;

    private float health = 5;
    private float startingHealth;
    [SerializeField]
    private float fireRateCoefficient = 1;
    private Rigidbody2D rb2d;
    private ShooterBehavior weapon;
    private string playerName;
    private UIManager uiManager;
    private bool isInvulnerable;
    private float invulnerabiltyEndTime = 0.0f;

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
        uiManager = GameObject.Find("GameScreenUI").GetComponent<UIManager>();
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
        uiManager.resetPlayerLife(playerName);

        // Reset powerup and it's UI
        GetComponent<PowerUpManager>().reset();
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal_" + ControllerIndex);
        float v = Input.GetAxisRaw("Vertical_keyboard_" + ControllerIndex);

        if(v == .0f) {
            v = -Input.GetAxisRaw("Vertical_gamepad_" + ControllerIndex);
        }

        rb2d.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);

        if (Input.GetButton("Fire_" + ControllerIndex)) {
            weapon.fire();
        }
    }

    public void win() {
        Debug.Log("Player " + name + " win !");
        Time.timeScale = 0f;
    }

    IEnumerator flashEffect() {
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0.75f);
        yield return new WaitForEndOfFrame();
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0f);
    }

    IEnumerator onHitEffect() {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.15f);

        if (Time.time >= invulnerabiltyEndTime) {
            isInvulnerable = false;
        } else {
            StartCoroutine("onHitEffect");
        }
    }

	void damagePlayer(float damage) {
	}

	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.transform.tag == "bullet") {
            if(!isInvulnerable) {
                float damage = coll.GetComponent<BulletBehavior>().getDamage();
                
				float[] indexes = new float[(int)damage];
                indexes.Initialize();

                // Make player flash
                StartCoroutine("flashEffect");
                // Start invulnerability effect
                invulnerabiltyEndTime = Time.time + invulnerabilityTime;
                isInvulnerable = true;
                StartCoroutine("onHitEffect");

                // Damage the player
                for (int i = 0; i < damage; i++) {
                    if (health > 0) {
                        // Stock life icone to remove
                        indexes[i] = health;
                    }
                    // Damage player
                    health -= 1;
                }

                // Hide loosed life icon(s)
                uiManager.playerTakeDamage(playerName, indexes);

                // Destroy the bullet
                GameObject.Destroy(coll.gameObject);
            }
		} else if (coll.transform.tag == "Enemy") {
            if (!isInvulnerable) {
                // Make player flash
                StartCoroutine("flashEffect");
                // Start invulnerability effect
                invulnerabiltyEndTime = Time.time + invulnerabilityTime;
                isInvulnerable = true;
                StartCoroutine("onHitEffect");

                float damage = 2;
                float[] indexes = new float[(int)damage];
                indexes.Initialize();
                // Damage the player
                for (int i = 0; i < damage; i++) {
                    if (health > 0) {
                        // Stock life icone to remove
                        indexes[i] = health;
                    }
                    // Damage player
                    health -= 1;
                }

                // Hide loosed life icon(s)
                uiManager.playerTakeDamage(playerName, indexes);

                // Destroy the enemy
                coll.gameObject.GetComponent<EnemyBehavior>().takeDamage(99f);
            }
        }
	}
}
