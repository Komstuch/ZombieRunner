using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public SceneLoader sceneLoader;
	public Slider diffSlider;
    public Text diffText;

	private MusicManager musicManager;
    private int difficulty;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		diffSlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update () {
        //musicManager.SetVolume(volumeSlider.value);
        difficulty = (int)diffSlider.value;
        switch (difficulty)
        {
            case 1:
                diffText.text = "Zombies are much slower and spawn very rarely";
                break;
            case 2:
                diffText.text = "Zombies are almost as fast as you and spawn at considerable rate";
                break;
            case 3:
                diffText.text = "Zombies are faster than you and spawn like hell";
                break;
            default:
                diffText.text = "Zombies";
                break;
        }

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
