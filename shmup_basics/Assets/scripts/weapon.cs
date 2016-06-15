using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenuAttribute(menuName = "SHMUP/Weapon")]
[System.Serializable]
public class Weapon : ScriptableObject {
    [Range(1f, 10f)]
    public float fireRate = 5f;

    public int bulletSpeed = 1;

    public List<GameObject> bullets;
}
