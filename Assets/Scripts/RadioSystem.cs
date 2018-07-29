using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

    public AudioClip initialCall;
    public AudioClip initialReply;
    public AudioClip heliArrival;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMakeInitialHeliCall() {
        Debug.Log(name + " OnMakeInitialHeliCall");
        audioSource.clip = initialCall;
        audioSource.Play();
        Invoke("DispatchHelicopter", initialCall.length + 3f);
    }

    void DispatchHelicopter() {
        BroadcastMessage("OnDispatchHelicopter");
        audioSource.clip = initialReply;
        audioSource.Play();
    }

    void OnHeliArrival() {
        BroadcastMessage("OnAwiatingForPlayer");
        audioSource.clip = heliArrival;
        audioSource.Play();
    }

    void OnFindClearArea() {
        BroadcastMessage("OnActivateSpawning");
    }


}
