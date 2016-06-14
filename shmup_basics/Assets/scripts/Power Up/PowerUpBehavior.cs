using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpBehavior : MonoBehaviour {
    public PowerUp powerUp;

    private Rigidbody2D rb2d;
    private PlayerBehavior player;
    private PlayerBehavior opponent;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -200);
    }

    public void activateBonus() {
        powerUp.bonus(player);
    }

    public void activateMalus() {
        powerUp.malus(opponent);
    }

    public void setPlayer(GameObject player) {
        this.player = player.GetComponent<PlayerBehavior>();
    }

    public void setOpponent(GameObject opponent) {
        this.opponent = opponent.GetComponent<PlayerBehavior>();
    }
}
