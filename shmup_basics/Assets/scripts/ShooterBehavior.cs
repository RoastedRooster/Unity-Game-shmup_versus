using UnityEngine;
using System.Collections;

public class ShooterBehavior : MonoBehaviour {

    public Weapon weapon;
    public int yDirection;

    private float nextFire = 0.0F;
    
    public void fire() {
        // Check if the player can fire
        if(Time.time > nextFire) {

            // Instantiate all the bullets and set needed attributes
            foreach (GameObject bullet in weapon.bullets) {
                GameObject bullet_go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                Bullet sc = bullet_go.GetComponent<Bullet>();
                sc.setYDirection(yDirection);
                sc.setYSpeed(weapon.bulletSpeed);
            }
            
            

            // Set cooldown
            nextFire = Time.time + weapon.fireRate;
        }
    }
}
