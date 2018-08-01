using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] float autoLoadNextLevelAfter;

    void Start() {
        if (autoLoadNextLevelAfter <= 0f) {
            Debug.LogWarning("Level auto load disabled ,use a positive number in seconds");
        }
        else {
            Debug.Log("LoadLevel");
            Invoke("LoadNextScreen", autoLoadNextLevelAfter);
        }
    }

    public void LoadNextScreen() {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);  
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("Start Scene");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
