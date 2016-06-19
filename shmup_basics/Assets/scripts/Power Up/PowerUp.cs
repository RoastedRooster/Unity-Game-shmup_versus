using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float duration;
    public Sprite icon;
    public Sprite bonusIcon;
    public Sprite malusIcon;

    public virtual void activateBonus(PlayerBehavior player) { }
    public virtual void deactivateBonus(PlayerBehavior player) { }
    public virtual void activateMalus(PlayerBehavior opponent) { }
    public virtual void deactivateMalus(PlayerBehavior opponent) { }
}
