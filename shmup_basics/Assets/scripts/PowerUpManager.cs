using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {

    private GameObject handheldPowerUp;

    private PowerUp[] activeBonus;
    private PowerUp[] activeMalus;

    private GameObject player;
    private GameObject opponent;

    void Start () {
        activeBonus = null;
        activeMalus = null;
    }
	
	void Update () {
        /*
        foreach (var bonus in activeBonus) {
            // if(bonus.duration )
        }

        foreach (var malus in activeMalus) {
            // if(bonus.duration )
        }
        */
    }

    /*
    public void activateBonus() {
        powerUp.activateBonus(player);
    }

    public void activateMalus() {
        powerUp.activateMalus(opponent);
    }

    public void setPlayer(GameObject player) {
        this.player = player.GetComponent<PlayerBehavior>();
    }

    public void setOpponent(GameObject opponent) {
        this.opponent = opponent.GetComponent<PlayerBehavior>();
    }
    */

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.transform.tag == "powerup") {
            // catchPowerUp(coll.gameObject);
            GameObject.Destroy(coll.gameObject);
        }
    }

    /*
    void usePowerUpBonus() {
        if (actualPowerUp != null) {
            PowerUpBehavior powerUp = actualPowerUp.GetComponent<PowerUpBehavior>();
            // powerUp.setPlayer(gameObject);
            GameObject opponent = findOpponent();
            // powerUp.setOpponent(opponent);
            // powerUp.activateBonus();
        }
    }

    void usePowerUpMalus() {
        if (actualPowerUp != null) {
            PowerUpBehavior powerUp = actualPowerUp.GetComponent<PowerUpBehavior>();
            // powerUp.setPlayer(gameObject);
            GameObject opponent = findOpponent();
            // powerUp.setOpponent(opponent);
            // powerUp.activateMalus();
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
        if (actualPowerUp == null) {
            actualPowerUp = powerUp;
            usePowerUpBonus();
        }
    }
    */
}
