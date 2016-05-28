using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public int ControllerIndex;
    public float hMaxSpeed = 5f;
    public float vMaxSpeed = 5f;

    private Rigidbody2D rb2d;


    public void setControllerIndex(int i) {
        ControllerIndex = i;
    }

    public int getControllerIndex() {
        return ControllerIndex;
    }

    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal_" + ControllerIndex);
        float v = Input.GetAxisRaw("Vertical_" + ControllerIndex);

        rb2d.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);
    }
}
