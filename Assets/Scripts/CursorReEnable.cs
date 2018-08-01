using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorReEnable : MonoBehaviour {

	void Awake () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
	}

}
