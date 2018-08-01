using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log("Don't destroy on load "+ name);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

	void Start () {
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }


    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        Debug.Log("OnSceneLoaded: " + scene.buildIndex);

        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];

        Debug.Log("Playing clip " + thisLevelMusic);

        if (thisLevelMusic)
        { //If there is some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            if(scene.name == "End Game") {
                audioSource.loop = false;
                audioSource.volume = 1f;
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
