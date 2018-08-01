﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

    public AudioClip whatHappened;
    public AudioClip goodLandingArea;

    private AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        audioSource.Play();
	}

    void OnFindClearArea() {
        Debug.Log(name + " OnFindClearArea");
        audioSource.clip = goodLandingArea;
        audioSource.Play();

        Invoke("CallHeli", goodLandingArea.length + 1f);  
    }

    void CallHeli() {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}
