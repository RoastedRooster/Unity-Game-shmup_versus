using UnityEngine;
using System.Collections;

public class ShooterBehavior : MonoBehaviour {

    public Weapon weapon;
    public GameObject position;
    public float fireRate = 0.5F;

    private float nextFire = 0.0F;

    public void fire() {
        // Check if the player can fire
        if(Time.time > nextFire) {

            // Instantiate a new bullet
            GameObject clone = Instantiate(weapon.bullet, position.transform.position, Quaternion.identity) as GameObject;
            nextFire = Time.time + weapon.fireRate;
        }
    }
}
