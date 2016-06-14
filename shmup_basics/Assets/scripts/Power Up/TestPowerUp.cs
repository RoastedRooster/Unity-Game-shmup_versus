using UnityEngine;
using System.Collections;
using System;

public class TestPowerUp : PowerUp {

    override public void activateBonus(PlayerBehavior player) {
        StartCoroutine(IncreasePlayerFireRate(player));
    }

    override public void activateMalus(PlayerBehavior opponent) {
        StartCoroutine(DecreaseOpponentFireRate(opponent));
    }

    IEnumerator IncreasePlayerFireRate(PlayerBehavior player) {
        player.setFireRateCoefficient(0.5f);
        yield return new WaitForSeconds(3.0f);
        player.setFireRateCoefficient(1);
    }

    IEnumerator DecreaseOpponentFireRate(PlayerBehavior opponent) {
        opponent.setFireRateCoefficient(2);
        yield return new WaitForSeconds(3.0f);
        opponent.setFireRateCoefficient(1);
    }
}
