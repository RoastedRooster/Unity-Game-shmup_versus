using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
    public virtual void bonus(PlayerBehavior player) { }
    public virtual void malus(PlayerBehavior opponent) { }
}
