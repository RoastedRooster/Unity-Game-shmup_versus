using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpBehavior : MonoBehaviour {
    private Rigidbody2D rb2d;
    private PlayerBehavior player;
    private PlayerBehavior opponent;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -200);
    }
}
