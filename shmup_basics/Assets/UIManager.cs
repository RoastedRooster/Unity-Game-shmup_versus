using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private Transform uiSoldier;
    private Transform uiEvil;
    private Sprite emptyPowerUp;
    private Sprite emptyBonusEffect;
    private Sprite emptyMalusEffect;

    void Start() {
        uiSoldier = transform.FindChild("UISoldierSide");
        uiEvil = transform.FindChild("UIEvilSide");
        emptyPowerUp = uiSoldier.FindChild("PowerUp").gameObject.GetComponent<Image>().sprite;
        emptyBonusEffect = uiSoldier.FindChild("ActiveBonus").gameObject.GetComponent<Image>().sprite;
        emptyMalusEffect = uiSoldier.FindChild("ActiveMalus").gameObject.GetComponent<Image>().sprite;
    }

	public void playerWin (string name) {
        if(name == "evil") {
            uiSoldier.FindChild("Lost").gameObject.GetComponent<Text>().enabled = true;
            uiEvil.FindChild("Won").gameObject.GetComponent<Text>().enabled = true;
        } else {
            uiSoldier.FindChild("Won").gameObject.GetComponent<Text>().enabled = true;
            uiEvil.FindChild("Lost").gameObject.GetComponent<Text>().enabled = true;
        }
    }

    public void playerTakeDamage(string name, float[] indexes) {
        if (name == "evil") {
            foreach (var index in indexes) {
                if (uiEvil.FindChild("CharLife/" + index) != null) {
                    uiEvil.FindChild("CharLife/" + index).gameObject.GetComponent<Image>().enabled = false;
                }
            }
        } else {
            foreach (var index in indexes) {
                if(uiSoldier.FindChild("CharLife/" + index) != null) {
                    uiSoldier.FindChild("CharLife/" + index).gameObject.GetComponent<Image>().enabled = false;
                }
            }
        }
    }

    public void baseTakeDamage(string name, int[] indexes) {
        if (name == "evil") {
            foreach (var index in indexes) {
                if(uiEvil.FindChild("BaseLife/" + index) != null) {
                    uiEvil.FindChild("BaseLife/" + index).gameObject.GetComponent<Image>().enabled = false;
                }
            }
        }
        else {
            foreach (var index in indexes) {
                if(uiSoldier.FindChild("BaseLife/" + index) != null) {
                    uiSoldier.FindChild("BaseLife/" + index).gameObject.GetComponent<Image>().enabled = false;
                }
            }
        }
    }

    public void resetPlayerLife(string name) {
        if (name == "evil") {
            for (int i = 1; i <= 5; i++) {
                if (uiEvil.FindChild("CharLife/" + i) != null) {
                    uiEvil.FindChild("CharLife/" + i).gameObject.GetComponent<Image>().enabled = true;
                }
            }
        }
        else {
            for (int i = 1; i <= 5; i++) {
                if(uiSoldier.FindChild("CharLife/" + i)) {
                    uiSoldier.FindChild("CharLife/" + i).gameObject.GetComponent<Image>().enabled = true;
                }
            }
        }
    }

    public void updatePowerUp(string name, Sprite icon) {
        if (name == "evil") {
            uiEvil.FindChild("PowerUp").gameObject.GetComponent<Image>().sprite = icon;
        }
        else {
            uiSoldier.FindChild("PowerUp").gameObject.GetComponent<Image>().sprite = icon;
        }
    }

    public void resetPowerUp(string name) {
        if (name == "evil") {
            uiEvil.FindChild("PowerUp").gameObject.GetComponent<Image>().sprite = emptyPowerUp;
        }
        else {
            uiSoldier.FindChild("PowerUp").gameObject.GetComponent<Image>().sprite = emptyPowerUp;
        }
    }

    public void updatePowerUpEffect(string name, string powerUp, Sprite icon) {
        if (name == "evil") {
            if (powerUp == "bonus") {
                uiEvil.FindChild("ActiveBonus").gameObject.GetComponent<Image>().sprite = icon;
            }
            else {
                uiEvil.FindChild("ActiveMalus").gameObject.GetComponent<Image>().sprite = icon;
            }
        }
        else {
            if (powerUp == "bonus") {
                uiSoldier.FindChild("ActiveBonus").gameObject.GetComponent<Image>().sprite = icon;
            }
            else {
                uiSoldier.FindChild("ActiveMalus").gameObject.GetComponent<Image>().sprite = icon;
            }
        }
    }

    public void resetPowerUpEffect(string name, string powerUp) {
        if (name == "evil") {
            if(powerUp == "bonus") {
                uiEvil.FindChild("ActiveBonus").gameObject.GetComponent<Image>().sprite = emptyBonusEffect;
            } else {
                uiEvil.FindChild("ActiveMalus").gameObject.GetComponent<Image>().sprite = emptyMalusEffect;
            }
        }
        else {
            if (powerUp == "bonus") {
                uiSoldier.FindChild("ActiveBonus").gameObject.GetComponent<Image>().sprite = emptyBonusEffect;
            }
            else {
                uiSoldier.FindChild("ActiveMalus").gameObject.GetComponent<Image>().sprite = emptyMalusEffect;
            }
        }
    }

    public void updateWaveCounter(string name, int wave) {
        if (name == "evil") {
            uiEvil.FindChild("Wave").gameObject.GetComponent<Text>().text = "Wave " + wave;
        }
        else {
            uiSoldier.FindChild("Wave").gameObject.GetComponent<Text>().text = "Wave " + wave;
        }
    }
}
