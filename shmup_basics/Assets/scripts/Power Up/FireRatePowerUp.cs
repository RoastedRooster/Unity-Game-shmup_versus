using UnityEngine;
using System.Collections;
using System;

public class FireRatePowerUp : PowerUp {
    
    override public void activateBonus(PlayerBehavior player) {
        player.setFireRateCoefficient(0.5f);
    }

    override public void deactivateBonus(PlayerBehavior player) {
        player.setFireRateCoefficient(1);
    }

    override public void activateMalus(PlayerBehavior opponent) {
        opponent.setFireRateCoefficient(2);
    }

    override public void deactivateMalus(PlayerBehavior opponent) {
        opponent.setFireRateCoefficient(1);
    }
}
