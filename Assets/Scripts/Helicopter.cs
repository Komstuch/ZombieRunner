using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private bool isCalled = false;
    private Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnDispatchHelicopter() {
        if (!isCalled) {
            Debug.Log("Helicopter Called");
            isCalled = true;
            rigidBody.velocity = new Vector3(0,0,50f);
        }
    }
}
