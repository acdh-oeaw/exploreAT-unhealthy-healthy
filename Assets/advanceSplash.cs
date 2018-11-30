using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class advanceSplash : MonoBehaviour {

	public RawImage rawimage;
	public Texture[] spritesSplash;
	public Texture en_firstTexture;
	public Texture es_firstTexture;
	public Texture de_firstTexture;
	public Texture en_secondTexture;
	public Texture es_secondTexture;
	public Texture de_secondTexture;
	public Text advanceText;
	public Text infoText;

	public Texture tuten1,tuten2,tuten3,tuten4,tuten5,tuten6,tuten7,tuten8,tuten9,tuten10,tuten11,tuten12;
	public Texture tutes1,tutes2,tutes3,tutes4,tutes5,tutes6,tutes7,tutes8,tutes9,tutes10,tutes11,tutes12;
	public Texture tutde1,tutde2,tutde3,tutde4,tutde5,tutde6,tutde7,tutde8,tutde9,tutde10,tutde11,tutde12;

	public GameObject panelFood;
	public Text textFood;
	public Text titleFood;

	public GameObject iconWater;
	public GameObject checkBreadPasta;
	public GameObject checkFruitVeggies;
	public GameObject checkMeatFish;
	public GameObject checkMilkCheese;
	public GameObject checkSweetSalty;

	// Use this for initialization
	void Start () {
		if(string.Equals(SceneManager.GetActiveScene ().name,"splash_scene")){
			ap.language = "en";
		}

		if (ap.tutorialState == 0) {
			ap.tutorialState = 1;
		}

		if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
			if (ap.language == "en") {
				advanceText.text = ap.en_tutorial_advanceText;
				rawimage.texture = tuten1;
			}
			else if (ap.language == "es") {
				advanceText.text = ap.es_tutorial_advanceText;
				rawimage.texture = tutes1;
			}
			else if (ap.language == "de") {
				advanceText.text = ap.de_tutorial_advanceText;
				rawimage.texture = tutde1;
			}
		}

		if (string.Equals(SceneManager.GetActiveScene ().name,"pyramid_scene")) {
			panelFood.SetActive (true);
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.en_infoPyramid;
				advanceText.text = ap.en_pyramid_advanceText;
				infoText.text = ap.en_pyramid_infoText;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.es_infoPyramid;
				advanceText.text = ap.es_pyramid_advanceText;
				infoText.text = ap.es_pyramid_infoText;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.de_infoPyramid;
				advanceText.text = ap.de_pyramid_advanceText;
				infoText.text = ap.de_pyramid_infoText;
			}
			iconWater.SetActive (true);
			checkBreadPasta.SetActive (true);
			checkFruitVeggies.SetActive (true);
			checkMeatFish.SetActive (true);
			checkMilkCheese.SetActive (true);
			checkSweetSalty.SetActive (true);
			Debug.Log("Screen Width : " + Screen.width);
			Debug.Log("Screen Height : " + Screen.height);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Language selection on start screen
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {ap.language = "en";}
		else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {ap.language = "es";}
		else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad2)) {ap.language = "de";}

		// Change the messages of the splash screen depending on the language if it changed
		if (string.Equals (SceneManager.GetActiveScene ().name, "splash_scene")) {
			if (ap.language == "en") {
				advanceText.text = ap.en_splash_text;
				rawimage.texture = spritesSplash[0];
			} else if (ap.language == "es") {
				advanceText.text = ap.es_splash_text;
				rawimage.texture = spritesSplash[1];
			} else if (ap.language == "de") {
				advanceText.text = ap.de_splash_text;
				rawimage.texture = spritesSplash[2];
			}
		}

		// Advancement step-by-step
		if (Input.GetKeyDown (KeyCode.N)){

			// If in start screen, load pyramid
			if (string.Equals(SceneManager.GetActiveScene ().name,"splash_scene")) {
				SceneManager.LoadScene ("pyramid_scene");
			}

			// If in start scree, load pyramid
			if (string.Equals(SceneManager.GetActiveScene ().name,"pyramid_scene")) {
				SceneManager.LoadScene ("tutorial_scene");
			}

			// If in tutorial, go step-by-step
			else if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
				if (ap.tutorialState < 12) {
					ap.tutorialState += 1;
					changeTutorialImage ();
				} else if (ap.tutorialState == 12) {
					ap.tutorialState = 0;
					SceneManager.LoadScene ("intro_scene");
				}
			}
		}

		// Skip tutorial
		if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene") && Input.GetKeyDown (KeyCode.S)) {
			ap.tutorialState = 0;
			SceneManager.LoadScene ("intro_scene");
		}
	}

	void changeTutorialImage(){
		if (ap.language == "en") {
			if(ap.tutorialState == 2){rawimage.texture = tuten2;}
			else if(ap.tutorialState == 3){rawimage.texture = tuten3;}
			else if(ap.tutorialState == 4){rawimage.texture = tuten4;}
			else if(ap.tutorialState == 5){rawimage.texture = tuten5;}
			else if(ap.tutorialState == 6){rawimage.texture = tuten6;}
			else if(ap.tutorialState == 7){rawimage.texture = tuten7;}
			else if(ap.tutorialState == 8){rawimage.texture = tuten8;}
			else if(ap.tutorialState == 9){rawimage.texture = tuten9;}
			else if(ap.tutorialState == 10){rawimage.texture = tuten10;}
			else if(ap.tutorialState == 11){rawimage.texture = tuten11;}
			else if(ap.tutorialState == 12){rawimage.texture = tuten12;}
		}
		else if (ap.language == "es") {
			if(ap.tutorialState == 2){rawimage.texture = tutes2;}
			else if(ap.tutorialState == 3){rawimage.texture = tutes3;}
			else if(ap.tutorialState == 4){rawimage.texture = tutes4;}
			else if(ap.tutorialState == 5){rawimage.texture = tutes5;}
			else if(ap.tutorialState == 6){rawimage.texture = tutes6;}
			else if(ap.tutorialState == 7){rawimage.texture = tutes7;}
			else if(ap.tutorialState == 8){rawimage.texture = tutes8;}
			else if(ap.tutorialState == 9){rawimage.texture = tutes9;}
			else if(ap.tutorialState == 10){rawimage.texture = tutes10;}
			else if(ap.tutorialState == 11){rawimage.texture = tutes11;}
			else if(ap.tutorialState == 12){rawimage.texture = tutes12;}
		}
		else if (ap.language == "de") {
			if(ap.tutorialState == 2){rawimage.texture = tutde2;}
			else if(ap.tutorialState == 3){rawimage.texture = tutde3;}
			else if(ap.tutorialState == 4){rawimage.texture = tutde4;}
			else if(ap.tutorialState == 5){rawimage.texture = tutde5;}
			else if(ap.tutorialState == 6){rawimage.texture = tutde6;}
			else if(ap.tutorialState == 7){rawimage.texture = tutde7;}
			else if(ap.tutorialState == 8){rawimage.texture = tutde8;}
			else if(ap.tutorialState == 9){rawimage.texture = tutde9;}
			else if(ap.tutorialState == 10){rawimage.texture = tutde10;}
			else if(ap.tutorialState == 11){rawimage.texture = tutde11;}
			else if(ap.tutorialState == 12){rawimage.texture = tutde12;}
		}
	}
}
