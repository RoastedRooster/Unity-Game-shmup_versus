using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GoForwardScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOMoveY(transform.position.y - 150, 2);
	}

	// Update is called once per frame
	void Update () {

	}
}
