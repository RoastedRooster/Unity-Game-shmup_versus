using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    private float damage;

	// Use this for initialization
	void Start () {
        damage = 1.0f;
	}

    public float getDamage() {
        return damage;
    }
}
