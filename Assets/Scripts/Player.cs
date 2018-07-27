using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // The parent of the spawn points
    public GameObject landingAreaPrefab;

    private Transform[] gameSpawnPoints;
    private bool respawn = false;
    private SpawnPoint[] spawnPoints;

	void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>(); // First method
    
        gameSpawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>(); // Second method, first component in array is the parent
    }	

	void Update () {
		if(respawn == true){
            ReSpawn();
            respawn = false;
        }
	}

    private void ReSpawn() {
        int spawnPointNumber = spawnPoints.Length;
        int randomPoint = UnityEngine.Random.Range(0, spawnPointNumber);

        transform.position = spawnPoints[randomPoint].transform.position;
    }

    void OnFindClearArea() {
        Invoke("DropFlare", 3f);
    }

    void DropFlare() {
        Debug.Log("Dropped a Flare");
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
}
