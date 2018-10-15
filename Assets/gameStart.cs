using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour {

	public Text controlsText;
	public Text startText;

	// Use this for initialization
	void Start () {
		if (ApplicationModel.language == "en") {
			controlsText.text = ApplicationModel.en_gameStart_controlsText;
			startText.text = ApplicationModel.en_gameStart_startText;
		}
		else if(ApplicationModel.language == "es") {
			controlsText.text = ApplicationModel.es_gameStart_controlsText;
			startText.text = ApplicationModel.es_gameStart_startText;
		}
		else if(ApplicationModel.language == "de") {
			controlsText.text = ApplicationModel.de_gameStart_controlsText;
			startText.text = ApplicationModel.de_gameStart_startText;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)){
			SceneManager.LoadScene("scene"); // Regenerate Scene
		}
	}
}
