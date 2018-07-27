using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycycle : MonoBehaviour {

    [Tooltip("Number of Minutes per Second")]
    public float timeScale = 300f; //how many minutes per second

    float sunSpeed; // velocity of sun changing deg/s depending on timeScale
	
	void Update () {

        sunSpeed = Time.deltaTime / 360 * timeScale;
        MoveSun();
	}

    void MoveSun() {
        transform.RotateAround(transform.position, Vector3.forward, sunSpeed);
    }
}
