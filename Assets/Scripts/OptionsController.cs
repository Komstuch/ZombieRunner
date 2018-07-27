using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public SceneLoader sceneLoader;
	public Slider diffSlider;

	private MusicManager musicManager;
	
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		diffSlider.value = PlayerPrefsManager.GetDifficulty();
	
	}
	
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(diffSlider.value);
		
		sceneLoader.LoadScene("Start Scene");
	}
	
	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		diffSlider.value = 2f;
	}
}
