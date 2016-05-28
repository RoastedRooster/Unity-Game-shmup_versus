using UnityEngine;
using System.Collections;

public class ShooterBehavior : MonoBehaviour {

    public Weapon weapon;
    public int xDirection;

    private float nextFire = 0.0F;
    
    public void fire() {
        // Check if the player can fire
        if(Time.time > nextFire) {

            // Instantiate a new bullet
            foreach (GameObject bullet in weapon.bullets) {
                GameObject bullet_go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                Bullet sc = bullet_go.GetComponent<Bullet>();
                sc.setXDirection(xDirection);
                sc.setXSpeed(weapon.bulletSpeed);
            }
            
            // Make the bullet move
            // bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, direction * weapon.bulletSpeed);

            // Set cooldown
            nextFire = Time.time + weapon.fireRate;
        }
    }
}
