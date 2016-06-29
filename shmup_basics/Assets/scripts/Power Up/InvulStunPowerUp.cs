using UnityEngine;
using System.Collections;

public class InvulStunPowerUp : PowerUp {

    override public void activateBonus(PlayerBehavior player) {
        player.setInvulnerability(true);
    }

    override public void deactivateBonus(PlayerBehavior player) {
        player.setInvulnerability(false);
    }

    override public void activateMalus(PlayerBehavior opponent) {
        opponent.setMovementSpeedCoefficient(0f);
    }

    override public void deactivateMalus(PlayerBehavior opponent) {
        opponent.setMovementSpeedCoefficient(1f);
    }
}
