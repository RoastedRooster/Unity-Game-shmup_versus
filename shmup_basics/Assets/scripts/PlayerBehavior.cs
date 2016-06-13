﻿using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

    public int ControllerIndex;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    public GameObject startingPoint;

    [SerializeField]
    private float health = 5;
    private float startingHealth;
    private float fireRateCoefficient = 1;
    private Rigidbody2D rb2d;
    private ShooterBehavior weapon;
    private GameObject actualPowerUp = null;

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

    void usePowerUpBonus() {
        if(actualPowerUp != null) {
            PowerUpBehavior powerUp = actualPowerUp.GetComponent<PowerUpBehavior>();
            powerUp.setPlayer(gameObject);
            GameObject opponent = findOpponent();
            powerUp.setOpponent(opponent);
        }
    }

    void usePowerUpMalus() {
        if(actualPowerUp != null) {
            PowerUpBehavior powerUp = actualPowerUp.GetComponent<PowerUpBehavior>();
            powerUp.setPlayer(gameObject);
            GameObject opponent = findOpponent();
            powerUp.setOpponent(opponent);
        }
    }

    GameObject findOpponent() {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        GameObject opponent = null;
        foreach (GameObject player in players) {
            if (player != this) {
                opponent = player;
            }
        }
        return opponent;
    }

    void catchPowerUp(GameObject powerUp) {
        if(actualPowerUp == null) {
            actualPowerUp = powerUp;
        }
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "bullet") {
            // Damage player
            health -= coll.GetComponent<BulletBehavior>().getDamage();

            // Destroy the player
			GameObject.Destroy (coll.gameObject);
		} else if (coll.transform.tag == "powerup") {
            catchPowerUp(coll.gameObject);
            GameObject.Destroy(coll.gameObject);
        }
	}
}
