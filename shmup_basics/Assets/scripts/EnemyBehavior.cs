using UnityEngine;
using System.Collections;
using rr.agent.pattern;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]
    private float health = 2;
    private float fireRateCoefficient = 1;
    private ShooterBehavior weapon;
    private Animator anim;
    private AgentWithMovePattern movementManager;

    void Awake() {
        weapon = gameObject.GetComponentInChildren<ShooterBehavior>();
        anim = GetComponent<Animator>();
        movementManager = GetComponent<AgentWithMovePattern>();
    }

    public void takeDamage(float damage) {
        health -= damage;
    }

    void Update() {
        if(health <= 0) {
            StartCoroutine("kill");
        }
        weapon.fire();
    }

    IEnumerator kill() {
        movementManager.Stop();
        anim.SetBool("isDead", true);
        // Wait for one frame because Unity doesn't update clip info on the exact next frame.....
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
        GameObject.Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "bullet" && coll.gameObject.layer == LayerMask.NameToLayer("bullet_player")) {
            health -= coll.GetComponent<BulletBehavior>().getDamage();
            // Make enemy flash
            StartCoroutine("flashEffect");
            GameObject.Destroy (coll.gameObject);
        }
    }

    IEnumerator flashEffect() {
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0.75f);
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0f);
    }

    public float getFireRateCoefficient() {
        return fireRateCoefficient;
    }

    public void setFireRateCoefficient(float newValue) {
        fireRateCoefficient = newValue;
    }
}
