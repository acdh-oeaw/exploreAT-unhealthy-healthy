using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mouseOverSummary : MonoBehaviour {

	public GameObject panelFood;
	public Text textFood;
	public Text titleFood;

	// Use this for initialization
	void Start () {
		if (string.Equals (SceneManager.GetActiveScene ().name, "pyramid_scene")) {
			panelFood.SetActive (true);
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoPyramid;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoPyramid;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoPyramid;
			}
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "summary_scene")) {
			panelFood.SetActive (false);
			textFood.GetComponent<Text> ().text = "";
			titleFood.GetComponent<Text> ().text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver()
	{
		panelFood.SetActive (true);
		if (this.gameObject.name == "checkPastaBread") {
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titleBreadPasta;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoBreadPasta;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titleBreadPasta;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoBreadPasta;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titleBreadPasta;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoBreadPasta;
			}
		}
		else if(this.gameObject.name == "checkFruitVeggies"){
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titleFruitVeggies;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoFruitVeggies;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titleFruitVeggies;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoFruitVeggies;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titleFruitVeggies;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoFruitVeggies;
			}
		}
		else if(this.gameObject.name == "checkMeatFish"){
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titleMeatFish;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoMeatFish;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titleMeatFish;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoMeatFish;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titleMeatFish;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoMeatFish;
			}
		}
		else if(this.gameObject.name == "checkMilkCheese"){
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titleMilkCheese;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoMilkCheese;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titleMilkCheese;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoMilkCheese;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titleMilkCheese;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoMilkCheese;
			}
		}
		else if(this.gameObject.name == "checkSweetSalty"){
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titleSweetSalty;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoSweetSalty;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titleSweetSalty;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoSweetSalty;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titleSweetSalty;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoSweetSalty;
			}
		}
		else if(this.gameObject.name == "iconWater"){
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titleWater;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoWater;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titleWater;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoWater;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titleWater;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoWater;
			}
		}
	}

	void OnMouseExit()
	{
		if (string.Equals (SceneManager.GetActiveScene ().name, "summary_scene")) {
			panelFood.SetActive (false);
			textFood.GetComponent<Text> ().text = "";
			titleFood.GetComponent<Text> ().text = "";
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "pyramid_scene")) {
			if (ApplicationModel.language == "en") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.en_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.en_infoPyramid;
			} else if (ApplicationModel.language == "es") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.es_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.es_infoPyramid;
			} else if (ApplicationModel.language == "de") {
				titleFood.GetComponent<Text> ().text = ApplicationModel.de_titlePyramid;
				textFood.GetComponent<Text> ().text = ApplicationModel.de_infoPyramid;
			}
		}
	}
}
