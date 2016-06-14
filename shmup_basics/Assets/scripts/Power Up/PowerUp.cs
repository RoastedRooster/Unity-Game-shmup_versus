using System;
using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public float duration;
    public virtual void activateBonus(PlayerBehavior player) { }
    public virtual void deactivateBonus(PlayerBehavior player) { }
    public virtual void activateMalus(PlayerBehavior opponent) { }
    public virtual void deactivateMalus(PlayerBehavior opponent) { }
}
