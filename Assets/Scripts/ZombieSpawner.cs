using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombie; // Zombie prefab
    public bool spawningActivated = false;

    private float spawnRate = 5; //Seen every X seconds
    private Transform[] zombieSpawnPoints;

	void Start () {
        zombieSpawnPoints = GetComponentsInChildren<Transform>();
       
	}

	void Update () {
        for (int i =1; i < zombieSpawnPoints.Length; i++) { 
            if (isTimeToSpawn() && spawningActivated){
                Spawn(zombieSpawnPoints[i]);
            }
        }
    }

    void Spawn(Transform spawnPoint){
        GameObject myAttacker = Instantiate(zombie) as GameObject;
        myAttacker.transform.parent = spawnPoint.transform;
        myAttacker.transform.position = spawnPoint.transform.position;
    }

    bool isTimeToSpawn() {

        float spawnsPerSecond = 1 / spawnRate;

        if (Time.deltaTime > spawnRate) {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5; // By multiplying by Time.deltaTime we "convert" the calculation from frames to seconds (/5 because of 5 spawn points)

        return (Random.value < threshold);
    }

    void OnActivateSpawning() {
        Debug.Log("Activate Zombie Spawning");
        spawningActivated = true;
    }
}
