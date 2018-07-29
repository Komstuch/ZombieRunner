using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // The parent of the spawn points
    public GameObject landingAreaPrefab;

    private SceneLoader sceneLoader;
    private Transform[] gameSpawnPoints;
    private bool respawn = true;
    private SpawnPoint[] spawnPoints;

    private float playerHeliOffset; //Distance between the player and heli
    private bool heliReady = false;
    private Helicopter helicopter;

    void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>(); // First method
        gameSpawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>(); // Second method, first component in array is the parent

        helicopter = FindObjectOfType<Helicopter>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }	

	void Update () {
		if(respawn == true){
            ReSpawn();
            respawn = false;
        }
        if (heliReady == true) {
            playerHeliOffset = CheckDistanceFromHelicopter();

            if (playerHeliOffset < 3f) {
                sceneLoader.LoadScene("Win Game");
            }
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

    void OnAwiatingForPlayer() {
        Debug.Log("Awiating for the player");
        heliReady = true;
    }

    float CheckDistanceFromHelicopter() {
        Vector3 offset = helicopter.transform.position - transform.position;

        return offset.magnitude;
    }
}
