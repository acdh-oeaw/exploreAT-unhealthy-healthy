using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverController : MonoBehaviour {

	public GameObject gameOverObject;
	public GameObject scoreObject; 
	Text scoreText;
	bool shown;

	// Use this for initialization
	void Start () {
		scoreText = scoreObject.GetComponent < Text >();
		gameOverObject.SetActive(false);
		shown = false;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText = scoreObject.GetComponent < Text >();
		if (shown == true) {
			// Game over
			Time.timeScale = 0f;
		}
		if(float.Parse(scoreText.text) < 0f) {
			shown = false;
			gameOverObject.SetActive (true);
		}
	}
}
