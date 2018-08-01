using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombie; // Zombie prefab
    public bool spawningActivated = false;

    private float spawnRate = 5f; //Seen every X seconds
    private Transform[] zombieSpawnPoints;

	void Start () {
        zombieSpawnPoints = GetComponentsInChildren<Transform>();
       
	}

	void Update () {
        for (int i =1; i < zombieSpawnPoints.Length; i++) { 
            if (IsTimeToSpawn() && spawningActivated){
                Spawn(zombieSpawnPoints[i]);
            }
        }
    }

    void Spawn(Transform spawnPoint){
        GameObject myAttacker = Instantiate(zombie) as GameObject;
        myAttacker.transform.parent = spawnPoint.transform;
        myAttacker.transform.position = spawnPoint.transform.position;
    }

    bool IsTimeToSpawn() {

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

    void SetZombieSpawnRate()
    {
        int difficulty = (int)PlayerPrefsManager.GetDifficulty();
        switch (difficulty)
        {
            case 1:
                spawnRate = 5f;
                break;
            case 2:
                spawnRate = 2.5f;
                break;
            case 3:
                spawnRate = 1f;
                break;
            default:
                spawnRate = 2.5f;
                break;
        }
    }
}
