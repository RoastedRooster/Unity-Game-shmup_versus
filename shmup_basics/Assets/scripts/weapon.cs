using UnityEngine;
using System.Collections;

[CreateAssetMenuAttribute(menuName = "SHMUP/Weapon")]
public class Weapon : ScriptableObject {
    public string name;

    [Range(1f, 10f)]
    public float fireRate = 5f;

    public GameObject bullet;
}
