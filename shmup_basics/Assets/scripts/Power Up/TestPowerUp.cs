using UnityEngine;
using System.Collections;
using System;

public class TestPowerUp : MonoBehaviour, IPowerUp {

    void IPowerUp.bonus() {
        StartCoroutine("IncreasePlayerFireRate");
    }

    void IPowerUp.malus() {
        StartCoroutine("DecreaseOpponentFireRate");
    }

    IEnumerator IncreasePlayerFireRate () {
        yield return new WaitForSeconds(3.0f);
	}

    IEnumerator DecreaseOpponentFireRate () {
        yield return new WaitForSeconds(3.0f);
    }
}
