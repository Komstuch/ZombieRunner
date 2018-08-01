using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
    public AudioClip[] deathSoundArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log("Don't destroy on load "+ name);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];

        if (thisLevelMusic)
        { //If there is some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;

            if(scene.name == "End Game") { // If we lost the game play death sound
                audioSource.clip = deathSoundArray[Random.Range(0, deathSoundArray.Length)];
                audioSource.loop = false;
                audioSource.volume = 1f;
                Debug.Log("You Have died, here is some music: " + audioSource.clip.name);
            }
            audioSource.Play();
        }
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetVolume(float volume) { // Method Accessed from the Options Controller
        audioSource.volume = volume;

    }
}
