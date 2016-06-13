using UnityEngine;
using System.Collections;
using System;

public class TestPowerUp : MonoBehaviour, IPowerUp {

    void IPowerUp.bonus() {
        throw new NotImplementedException();
    }

    void IPowerUp.malus() {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
