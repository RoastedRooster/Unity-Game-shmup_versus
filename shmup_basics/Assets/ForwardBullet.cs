using UnityEngine;
using System.Collections;

public class ForwardBullet : Bullet {

    void FixedUpdate() {
        rb2d.velocity = new Vector2(0, yDirection * ySpeed);
    }
}
