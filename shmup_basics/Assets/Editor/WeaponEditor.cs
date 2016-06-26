using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor {

    [Range(0f, 1000f)]
    public float fireRate = 0.5f;

    public int bulletSpeed = 1;

    public List<GameObject> bullets;
}
