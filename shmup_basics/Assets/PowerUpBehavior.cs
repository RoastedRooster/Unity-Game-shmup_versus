using UnityEngine;
using System.Collections;

public class PowerUpBehavior : MonoBehaviour {
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -200);
    }
}
