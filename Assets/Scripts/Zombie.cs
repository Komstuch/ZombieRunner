using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private AICharacterControl aICharacterControl; //We can get player object from AI character controll script
    private Player player;
    private SceneLoader sceneLoader;

    public float distanceToPlayer;

	void Start () {
        aICharacterControl = GetComponent<AICharacterControl>();
        player = aICharacterControl.playerCharacter;
        sceneLoader = FindObjectOfType<SceneLoader>();
	}

	void Update () {
        ChcekDistanceToPlayer();

        if (distanceToPlayer < 1.5f) {
            sceneLoader.LoadScene("End Game");
            Debug.LogWarning("You Lost! killed by: " + name + " " + transform.parent.name);
        }

    }

    private void ChcekDistanceToPlayer() {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        distanceToPlayer = directionToPlayer.magnitude;
        distanceToPlayer = Mathf.Abs(distanceToPlayer);
    }
}
