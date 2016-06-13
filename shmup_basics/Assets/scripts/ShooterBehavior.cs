using UnityEngine;
using System.Collections;

public class ShooterBehavior : MonoBehaviour {

    public Weapon weapon;

    private float nextFire = 0.0F;
    private int yDir = 0;
    private string layerName;

    void Start() {
        if (transform.parent.tag == "Player") {
            yDir = 1;
            layerName = "bullet_player";
        }
        else {
            yDir = -1;
            layerName = "bullet_enemy";
        }
    }

    public void fire() {
        // Check if the player can fire
        if(Time.time > nextFire) {

            // Instantiate all the bullets and set needed attributes
            foreach (GameObject bullet in weapon.bullets) {
                GameObject bullet_go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                Bullet sc = bullet_go.GetComponent<Bullet>();
                sc.gameObject.layer = LayerMask.NameToLayer(layerName);
                sc.setYDirection(yDir);
                sc.setYSpeed(weapon.bulletSpeed);
            }

            // Set cooldown
            float fireRateCoefficient = 0.0f;
            if(transform.parent.tag == "Player") {
                fireRateCoefficient = GetComponentInParent<PlayerBehavior>().getFireRateCoefficient();
            } else {
                fireRateCoefficient = GetComponentInParent<EnemyBehavior>().getFireRateCoefficient();
            }

            nextFire = Time.time + weapon.fireRate * fireRateCoefficient;
        }
    }
}
