using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class advanceResults : MonoBehaviour {

	public RawImage rawimage;
	public Texture en_firstTexture;
	public Texture es_firstTexture;
	public Texture de_firstTexture;
	public Texture en_secondTexture;
	public Texture es_secondTexture;
	public Texture de_secondTexture;
	public Text advanceText;



	// Use this for initialization
	void Start () {
		if (ap.tutorialState == 0) {
			ap.tutorialState = 1;
		}

		if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
			if (ap.language == "en") {
				advanceText.text = ap.en_tutorial_advanceText;
				rawimage.texture = en_firstTexture;
			}
			else if (ap.language == "es") {
				advanceText.text = ap.es_tutorial_advanceText;
				rawimage.texture = es_firstTexture;
			}
			else if (ap.language == "de") {
				advanceText.text = ap.de_tutorial_advanceText;
				rawimage.texture = de_firstTexture;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {ap.language = "en";}
		else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {ap.language = "es";}
		else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad2)) {ap.language = "de";}

		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1) ||
			Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2) ||
			Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3) ||
			Input.GetKeyDown (KeyCode.N)){
			if (string.Equals(SceneManager.GetActiveScene ().name,"splash_scene")) {
				SceneManager.LoadScene ("tutorial_scene");
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
				if (ap.tutorialState == 1) {
					ap.tutorialState = 2;
					changeTutorialImage ();
				} else if (ap.tutorialState == 2) {
					SceneManager.LoadScene ("intro_scene");
				}
			}
		}
	}

	void changeTutorialImage(){
		if (ap.language == "en") {
			rawimage.texture = en_secondTexture;
		}
		else if (ap.language == "es") {
			rawimage.texture = es_secondTexture;
		}
		else if (ap.language == "de") {
			rawimage.texture = de_secondTexture;
		}
	}
}
