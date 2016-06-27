using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenuAttribute(menuName = "SHMUP/Weapon")]
[Serializable]
public class Weapon : ScriptableObject {
    [Range(0f, 1000f)]
    public float fireRate = 0.5f;

    public int bulletSpeed = 1;

    public List<GameObject> bullets;
}
