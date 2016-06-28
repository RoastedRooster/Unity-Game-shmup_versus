using UnityEngine;
using System.Collections;

public class MovementSpeedPowerUp : PowerUp {

	override public void activateBonus(PlayerBehavior player) {
		player.setMovementSpeedCoefficient(2f);
	}

	override public void deactivateBonus(PlayerBehavior player) {
		player.setMovementSpeedCoefficient(1f);
	}

	override public void activateMalus(PlayerBehavior opponent) {
		opponent.setMovementSpeedCoefficient(0.5f);
	}

	override public void deactivateMalus(PlayerBehavior opponent) {
		opponent.setMovementSpeedCoefficient(1f);
	}
}
