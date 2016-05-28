using UnityEngine;
using System.Collections;

public class ShooterBehavior : MonoBehaviour {

    public Weapon weapon;
    public GameObject position;
    public int direction;

    private float nextFire = 0.0F;

    public void fire() {
        // Check if the player can fire
        if(Time.time > nextFire) {

            // Instantiate a new bullet
            GameObject bullet = Instantiate(weapon.bullet, position.transform.position, Quaternion.identity) as GameObject;

            // Make the bullet move
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, direction * weapon.bulletSpeed);

            // Set cooldown
            nextFire = Time.time + weapon.fireRate;
        }
    }
}
