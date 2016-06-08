using UnityEngine;
using System.Collections;

public class ForwardBullet : Bullet {
    
    new void Start() {
        base.Start();
    }

    void FixedUpdate() {
        rb2d.velocity = new Vector2(0, yDirection * ySpeed);
    }
}
