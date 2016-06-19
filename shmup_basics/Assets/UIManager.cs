using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private Transform uiSoldier;
    private Transform uiEvil;
    private Sprite emptyPowerUp;

    void Start() {
        uiSoldier = transform.FindChild("UISoldierSide");
        uiEvil = transform.FindChild("UIEvilSide");
        emptyPowerUp = uiSoldier.FindChild("PowerUp").gameObject.GetComponent<Image>().sprite;
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
                uiEvil.FindChild("CharLife/" + index).gameObject.GetComponent<Image>().enabled = false;
            }
        } else {
            foreach (var index in indexes) {
                uiSoldier.FindChild("CharLife/" + index).gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }

    public void baseTakeDamage(string name, int[] indexes) {
        if (name == "evil") {
            foreach (var index in indexes) {
                uiEvil.FindChild("BaseLife/" + index).gameObject.GetComponent<Image>().enabled = false;
            }
        }
        else {
            foreach (var index in indexes) {
                uiSoldier.FindChild("BaseLife/" + index).gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }

    public void resetPlayerLife(string name) {
        if (name == "evil") {
            for (int i = 1; i <= 5; i++) {
                uiEvil.FindChild("CharLife/" + i).gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else {
            for (int i = 1; i <= 5; i++) {
                uiSoldier.FindChild("CharLife/" + i).gameObject.GetComponent<Image>().enabled = true;
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
}
