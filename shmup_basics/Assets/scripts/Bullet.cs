using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    protected int yDirection = 0;
    protected int ySpeed = 0;
    // protected int yDirection = 0;
    
    protected Rigidbody2D rb2d;

    protected void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void setYDirection(int direction) {
        yDirection = direction;
    }

    public int getYDirection() {
        return yDirection;
    }

    public void setYSpeed(int speed) {
        ySpeed = speed;
    }

    public int getYSpeed() {
        return ySpeed;
    }
}
