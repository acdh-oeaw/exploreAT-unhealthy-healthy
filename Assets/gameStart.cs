using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class gameStart : MonoBehaviour {

	public Text controlsText;
	public Text startText;

	// Use this for initialization
	void Start () {
		if (ap.language == "en") {
			controlsText.text = ap.en_gameStart_controlsText;
			startText.text = ap.en_gameStart_startText;
		}
		else if(ap.language == "es") {
			controlsText.text = ap.es_gameStart_controlsText;
			startText.text = ap.es_gameStart_startText;
		}
		else if(ap.language == "de") {
			controlsText.text = ap.de_gameStart_controlsText;
			startText.text = ap.de_gameStart_startText;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N) && SceneManager.GetActiveScene().name == "intro_scene"){
			SceneManager.LoadScene("scene"); // Regenerate Scene
		}
	}
}
