using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

    public float timeSinceLastTrigger = 0f;

    private int objectsInTrigger = 0;
    private bool foundClearArea = false;

    void Update()
    {
        if (objectsInTrigger > 0){
            timeSinceLastTrigger = 0f;
        }

        timeSinceLastTrigger += Time.deltaTime;

        if (timeSinceLastTrigger > 2f && Time.realtimeSinceStartup > 10f && !foundClearArea) {
            SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
    }

    void OnTriggerEnter() {
        objectsInTrigger++;
    }
    void OnTriggerExit(){
        objectsInTrigger--;
    }
}