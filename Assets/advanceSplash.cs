using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class advanceSplash : MonoBehaviour {

	public RawImage rawimage;
	public Texture en_firstTexture;
	public Texture es_firstTexture;
	public Texture de_firstTexture;
	public Texture en_secondTexture;
	public Texture es_secondTexture;
	public Texture de_secondTexture;
	public Text advanceText;
	public Text infoText;

	public Texture tuten1,tuten2,tuten3,tuten4,tuten5,tuten6,tuten7,tuten8,tuten9,tuten10;
	public Texture tutes1,tutes2,tutes3,tutes4,tutes5,tutes6,tutes7,tutes8,tutes9,tutes10;
	public Texture tutde1,tutde2,tutde3,tutde4,tutde5,tutde6,tutde7,tutde8,tutde9,tutde10;

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
		if (ApplicationModel.tutorialState == 0) {
			ApplicationModel.tutorialState = 1;
		}

		if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
			if (ApplicationModel.language == "en") {
				advanceText.text = ApplicationModel.en_tutorial_advanceText;
				rawimage.texture = tuten1;
			}
			else if (ApplicationModel.language == "es") {
				advanceText.text = ApplicationModel.es_tutorial_advanceText;
				rawimage.texture = tutes1;
			}
			else if (ApplicationModel.language == "de") {
				advanceText.text = ApplicationModel.de_tutorial_advanceText;
				rawimage.texture = tutde1;
			}
		}

		if (string.Equals(SceneManager.GetActiveScene ().name,"pyramid_scene")) {
			panelFood.SetActive (true);
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoPyramid;
				advanceText.text = ApplicationModel.en_pyramid_advanceText;
				infoText.text = ApplicationModel.en_pyramid_advanceText;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoPyramid;
				advanceText.text = ApplicationModel.es_pyramid_advanceText;
				infoText.text = ApplicationModel.es_pyramid_infoText;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoPyramid;
				advanceText.text = ApplicationModel.de_pyramid_advanceText;
				infoText.text = ApplicationModel.de_pyramid_infoText;
			}
			iconWater.SetActive (true);
			checkBreadPasta.SetActive (true);
			checkFruitVeggies.SetActive (true);
			checkMeatFish.SetActive (true);
			checkMilkCheese.SetActive (true);
			checkSweetSalty.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Language selection on start screen
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {ApplicationModel.language = "en";}
		else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {ApplicationModel.language = "es";}
		else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad2)) {ApplicationModel.language = "de";}

		// Tutorial advancement step-by-step
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1) ||
			Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2) ||
			Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3) ||
			Input.GetKeyDown (KeyCode.N)){

			// If in start scree, load pyramid
			if (string.Equals(SceneManager.GetActiveScene ().name,"splash_scene")) {
				SceneManager.LoadScene ("pyramid_scene");
			}

			// If in start scree, load pyramid
			if (string.Equals(SceneManager.GetActiveScene ().name,"pyramid_scene")) {
				SceneManager.LoadScene ("tutorial_scene");
			}

			// If in tutorial, go step-by-step
			else if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
				if (ApplicationModel.tutorialState < 10) {
					ApplicationModel.tutorialState += 1;
					changeTutorialImage ();
				} else if (ApplicationModel.tutorialState == 10) {
					ApplicationModel.tutorialState = 0;
					SceneManager.LoadScene ("intro_scene");
				}
			}
		}

		// Skip tutorial
		if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene") && Input.GetKeyDown (KeyCode.S)) {
			ApplicationModel.tutorialState = 0;
			SceneManager.LoadScene ("intro_scene");
		}
	}

	void changeTutorialImage(){
		if (ApplicationModel.language == "en") {
			if(ApplicationModel.tutorialState == 2){rawimage.texture = tuten2;}
			if(ApplicationModel.tutorialState == 3){rawimage.texture = tuten3;}
			if(ApplicationModel.tutorialState == 4){rawimage.texture = tuten4;}
			if(ApplicationModel.tutorialState == 5){rawimage.texture = tuten5;}
			if(ApplicationModel.tutorialState == 6){rawimage.texture = tuten6;}
			if(ApplicationModel.tutorialState == 7){rawimage.texture = tuten7;}
			if(ApplicationModel.tutorialState == 8){rawimage.texture = tuten8;}
			if(ApplicationModel.tutorialState == 9){rawimage.texture = tuten9;}
			if(ApplicationModel.tutorialState == 10){rawimage.texture = tuten10;}
		}
		else if (ApplicationModel.language == "es") {
			if(ApplicationModel.tutorialState == 2){rawimage.texture = tutes2;}
			if(ApplicationModel.tutorialState == 3){rawimage.texture = tutes3;}
			if(ApplicationModel.tutorialState == 4){rawimage.texture = tutes4;}
			if(ApplicationModel.tutorialState == 5){rawimage.texture = tutes5;}
			if(ApplicationModel.tutorialState == 6){rawimage.texture = tutes6;}
			if(ApplicationModel.tutorialState == 7){rawimage.texture = tutes7;}
			if(ApplicationModel.tutorialState == 8){rawimage.texture = tutes8;}
			if(ApplicationModel.tutorialState == 9){rawimage.texture = tutes9;}
			if(ApplicationModel.tutorialState == 10){rawimage.texture = tutes10;}
		}
		else if (ApplicationModel.language == "de") {
			if(ApplicationModel.tutorialState == 2){rawimage.texture = tutde2;}
			if(ApplicationModel.tutorialState == 3){rawimage.texture = tutde3;}
			if(ApplicationModel.tutorialState == 4){rawimage.texture = tutde4;}
			if(ApplicationModel.tutorialState == 5){rawimage.texture = tutde5;}
			if(ApplicationModel.tutorialState == 6){rawimage.texture = tutde6;}
			if(ApplicationModel.tutorialState == 7){rawimage.texture = tutde7;}
			if(ApplicationModel.tutorialState == 8){rawimage.texture = tutde8;}
			if(ApplicationModel.tutorialState == 9){rawimage.texture = tutde9;}
			if(ApplicationModel.tutorialState == 10){rawimage.texture = tutde10;}
		}
	}
}
