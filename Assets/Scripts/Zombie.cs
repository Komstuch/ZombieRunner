using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private AICharacterControl aICharacterControl; //We can get player object from AI character controll script
    private Player player;
    private SceneLoader sceneLoader;
    private AudioSource audioSource;

    public float distanceToPlayer;
    public AudioClip[] zombieMoans;
    public float moanRate = 3f; //Moan once every 3 seconds

    void Start () {
        aICharacterControl = GetComponent<AICharacterControl>();
        audioSource = GetComponent<AudioSource>();
        player = aICharacterControl.playerCharacter;
        sceneLoader = FindObjectOfType<SceneLoader>();
	}

	void Update () {
        ChcekDistanceToPlayer();

        if (distanceToPlayer < 1.5f) {
            sceneLoader.LoadScene("End Game");
            Debug.LogWarning("You Lost! killed by: " + name + " " + transform.parent.name);
        }

        if (IsTimeToMoan()) {
            SelectRandomMoan();
            audioSource.Play();
        }
    }

    private void ChcekDistanceToPlayer() {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        distanceToPlayer = directionToPlayer.magnitude;
        distanceToPlayer = Mathf.Abs(distanceToPlayer);
    }

    bool IsTimeToMoan() {

        float moansPerSecond = 1/moanRate;

        if (Time.deltaTime > moanRate) {
            Debug.LogWarning("Moan rate capped by frame rate");
        }

        float threshold = moansPerSecond * Time.deltaTime; // By multiplying by Time.deltaTime we "convert" the calculation from frames to seconds (/5 because of 5 spawn points)

        return (Random.value < threshold);
    }

    void SelectRandomMoan() {
        int i = Random.Range(0, zombieMoans.Length);

        //Debug.Log("Zombie: " + name + "Generates moan: " + i);

        audioSource.clip = zombieMoans[i];
    }
}
