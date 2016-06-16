using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private Transform uiSoldier;
    private Transform uiEvil;

    void Start() {
        uiSoldier = transform.FindChild("UISoldierSide");
        uiEvil = transform.FindChild("UIEvilSide");
    }

	// Use this for initialization
	public void evilPlayerWin () {
        uiSoldier.FindChild("Lost").gameObject.GetComponent<Text>().enabled = true;
        uiEvil.FindChild("Won").gameObject.GetComponent<Text>().enabled = true;
    }

    public void soldierPlayerWin() {
        uiSoldier.FindChild("Won").gameObject.GetComponent<Text>().enabled = true;
        uiEvil.FindChild("Lost").gameObject.GetComponent<Text>().enabled = true;
    }
}
