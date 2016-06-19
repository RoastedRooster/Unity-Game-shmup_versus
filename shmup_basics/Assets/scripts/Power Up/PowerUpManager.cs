using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : MonoBehaviour {

    public class PowerUpObject {
        public float startTime;
        public float endTime;
        public PowerUp powerUp;

        public PowerUpObject(PowerUp powerUp) {
            this.powerUp = powerUp;
            this.endTime = 0;
            this.startTime = 0;
        }

        public void setStartTime(float time) {
            this.startTime = time;
        }

        public void setEndTime(float time) {
            this.endTime = time;
        }
    }

    private PowerUpObject handheldPowerUp;

    private int controllerIndex;

    private List<PowerUpObject> activeBonus = new List<PowerUpObject>();
    private List<PowerUpObject> activeMalus = new List<PowerUpObject>();

    private PlayerBehavior player;
    private PlayerBehavior opponent;
    private string playerName;
    private UIManager uiManager;

    void Start () {
        handheldPowerUp = new PowerUpObject(null);
        controllerIndex = GetComponent<PlayerBehavior>().ControllerIndex;

        player = GetComponent<PlayerBehavior>();
        opponent = findOpponent();

        playerName = transform.name.Split('_')[1];
        uiManager = GameObject.Find("GameScreenUI").GetComponent<UIManager>();
    }

	void Update () {
        if (handheldPowerUp.powerUp != null) {

            if (Input.GetButton("Bonus_" + controllerIndex)) {
                activateBonus();
            }

            if (Input.GetButton("Malus_" + controllerIndex)) {
                activateMalus();
            }
        }

        for (int i = 0; i < activeBonus.Count; i++) {
            PowerUpObject bonus = activeBonus[i];

            if (bonus.startTime == 0) {
                // Set active bonus powerup icon
                uiManager.updatePowerUpEffect(playerName, "bonus", bonus.powerUp.bonusIcon);
                // Activate bonus and calculate end time
                bonus.powerUp.activateBonus(GetComponent<PlayerBehavior>());
                bonus.setStartTime(Time.time);
                bonus.setEndTime(Time.time + bonus.powerUp.duration);
            }

            if (bonus.endTime <= Time.time) {
                // Remove bonus effect icon
                uiManager.resetPowerUpEffect(playerName, "bonus");
                // Deactivate bonus effect and remove it from the list
                bonus.powerUp.deactivateBonus(player);
                activeBonus.Remove(bonus);
            }
        }

        for (int i = 0; i < activeMalus.Count; i++) {
            PowerUpObject malus = activeMalus[i];

            if (malus.startTime == 0.0f) {
                // Set active malus powerup icon
                uiManager.updatePowerUpEffect(playerName, "malus", malus.powerUp.malusIcon);
                // Activate malus and calculate end time
                malus.powerUp.activateMalus(GetComponent<PlayerBehavior>());
                malus.setStartTime(Time.time);
                malus.setEndTime(Time.time + malus.powerUp.duration);
            }

            if (malus.endTime <= Time.time) {
                // Remove malus effect icon
                uiManager.resetPowerUpEffect(playerName, "malus");
                // Deactivate malus effect and remove it from the list
                malus.powerUp.deactivateMalus(player);
                activeMalus.Remove(malus);
            }
        }
    }

    public void activateBonus() {
        activeBonus.Add(new PowerUpObject(handheldPowerUp.powerUp));
        uiManager.resetPowerUp(playerName);
        handheldPowerUp.powerUp = null;
    }

    public void activateMalus() {
        opponent.GetComponent<PowerUpManager>().addMalus(handheldPowerUp.powerUp);
        uiManager.resetPowerUp(playerName);
        handheldPowerUp.powerUp = null;
    }

    public void addMalus(PowerUp malus) {
        activeMalus.Add(new PowerUpObject(malus));
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.transform.tag == "powerup") {
            if (handheldPowerUp.powerUp == null) {
                handheldPowerUp.powerUp = coll.gameObject.GetComponent<PowerUp>();
                // Get powerup icon
                Sprite icon = handheldPowerUp.powerUp.icon;
                // Update UI powerup icon
                uiManager.updatePowerUp(playerName, icon);
            }

            coll.gameObject.SetActive(false);
        }
    }

    PlayerBehavior findOpponent() {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        GameObject opponent = null;
        foreach (GameObject player in players) {
            if (player != this.gameObject) {
                opponent = player;
            }
        }
        return opponent.GetComponent<PlayerBehavior>();
    }
}
