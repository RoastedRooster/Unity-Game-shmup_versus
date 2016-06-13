using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpBehavior : MonoBehaviour {
    public IPowerUp powerUp;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -200);
    }

    public void activateBonus() {
        powerUp.bonus();
    }

    public void activateMalus() {
        powerUp.malus();
    }

    public void setPlayer(GameObject player) {

    }

    public void setOpponent(GameObject opponent) {

    }
}
