using UnityEngine;
using System.Collections;

public class RandAngleForwardBullet : Bullet {

    public int angle;

    new void Start() {
        base.Start();
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FixedUpdate() {
        Vector2 bulletForce = transform.up * ySpeed;
        rb2d.velocity = bulletForce;
    }
}
