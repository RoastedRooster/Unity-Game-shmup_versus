using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    protected int xDirection = 0;
    protected int xSpeed = 0;
    // protected int yDirection = 0;
    
    protected Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void setXDirection(int direction) {
        xDirection = direction;
    }

    public int getXDirection() {
        return xDirection;
    }

    public void setXSpeed(int speed) {
        xSpeed = speed;
    }

    public int getXSpeed() {
        return xSpeed;
    }

    /*
    public void setYDirection(int direction) {
        yDirection = direction;
    }

    public int getYDirection() {
        return yDirection;
    }
    */
}
