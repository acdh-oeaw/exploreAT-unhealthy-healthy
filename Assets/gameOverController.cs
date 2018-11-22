using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ap = ApplicationModel;

public class gameOverController : MonoBehaviour {

	public GameObject gameOverObject;
	bool shown;

	// Use this for initialization
	void Start () {
		gameOverObject.SetActive(false);
		shown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (shown == true) {
			// Game over
			Time.timeScale = 0f;
		}
		if(ap.timerSlices <= 0) {
			shown = false;
			gameOverObject.SetActive (false);
		}
	}
}
