using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private bool isCalled = false;
    private bool isAtPosition = false;

    private Rigidbody rigidBody;
    private Animator animator;
    private LandingArea landingArea;

    private Vector3 offsetXZ; // Offset in XZ plane
    private float offsetY; // Offset in Y plane

    private float horizontalSpeed = 30f; // Speed of approach in XZ plane
    private float verticalSpeed = -10f; // Speed of descent in Y plane

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); 
    }

    void Update(){
        if (isCalled && !isAtPosition) {
            CheckXZDistance();
        } else if (isAtPosition){
            CheckYDistance();
        }
    }

    void OnDispatchHelicopter() {
        if (!isCalled) {
            Debug.Log("Helicopter Called");
            TargetLandingArea();
            animator.enabled = true;

            Vector3 localVel = transform.InverseTransformDirection(new Vector3(0, 0, horizontalSpeed)); // Transform velocity vector from world space to local space
            localVel.x = -localVel.x; // Inverse X-axis - WHY!?
            rigidBody.velocity = localVel;

            isCalled = true;
        }
    }

    void TargetLandingArea()
    {
        landingArea = FindObjectOfType<LandingArea>();
        offsetXZ = CalculateOffsetInXZPlane();

        Quaternion rotation = Quaternion.LookRotation(offsetXZ.normalized);
        transform.rotation = rotation; // Align Heli with Landing Area
    }

    void CheckXZDistance(){
        offsetXZ = CalculateOffsetInXZPlane();

        if(offsetXZ.magnitude < 5f) {
            rigidBody.velocity = new Vector3(0, verticalSpeed, 0); // Start descending after reaching flare position
            Debug.Log("Destination Reached");
            isAtPosition = true;
        }
    }

    void CheckYDistance() {
        offsetY = CalculateOffsetInYPlane();

        if (Mathf.Abs(offsetY) < 1f) {
            rigidBody.velocity = new Vector3(0, 0, 0); // Stop at pick-up position
            SendMessageUpwards("OnHeliArrival");
        }
    }

    private Vector3 CalculateOffsetInXZPlane() {
        Vector3 offXZ = landingArea.transform.position - transform.position; // Vector positioning form heli to the landing area
        offXZ = new Vector3(offXZ.x, 0, offXZ.z); // Lock alignemnt in Y direction (plane)
        return offXZ;
    }

    private float CalculateOffsetInYPlane() {
        float offY = landingArea.transform.position.y - transform.position.y; // Difference in horizontal position
        return offY;
    }
}
