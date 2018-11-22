using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class mouseOverSummary : MonoBehaviour {

	public GameObject panelFood;
	public Text textFood;
	public Text titleFood;

	// Use this for initialization
	void Start () {
		if (string.Equals (SceneManager.GetActiveScene ().name, "pyramid_scene")) {
			panelFood.SetActive (true);
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.en_infoPyramid;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.es_infoPyramid;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.de_infoPyramid;
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
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titleBreadPasta;
				textFood.GetComponent<Text> ().text = ap.en_infoBreadPasta;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titleBreadPasta;
				textFood.GetComponent<Text> ().text = ap.es_infoBreadPasta;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titleBreadPasta;
				textFood.GetComponent<Text> ().text = ap.de_infoBreadPasta;
			}
		}
		else if(this.gameObject.name == "checkFruitVeggies"){
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titleFruitVeggies;
				textFood.GetComponent<Text> ().text = ap.en_infoFruitVeggies;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titleFruitVeggies;
				textFood.GetComponent<Text> ().text = ap.es_infoFruitVeggies;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titleFruitVeggies;
				textFood.GetComponent<Text> ().text = ap.de_infoFruitVeggies;
			}
		}
		else if(this.gameObject.name == "checkMeatFish"){
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titleMeatFish;
				textFood.GetComponent<Text> ().text = ap.en_infoMeatFish;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titleMeatFish;
				textFood.GetComponent<Text> ().text = ap.es_infoMeatFish;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titleMeatFish;
				textFood.GetComponent<Text> ().text = ap.de_infoMeatFish;
			}
		}
		else if(this.gameObject.name == "checkMilkCheese"){
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titleMilkCheese;
				textFood.GetComponent<Text> ().text = ap.en_infoMilkCheese;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titleMilkCheese;
				textFood.GetComponent<Text> ().text = ap.es_infoMilkCheese;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titleMilkCheese;
				textFood.GetComponent<Text> ().text = ap.de_infoMilkCheese;
			}
		}
		else if(this.gameObject.name == "checkSweetSalty"){
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titleSweetSalty;
				textFood.GetComponent<Text> ().text = ap.en_infoSweetSalty;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titleSweetSalty;
				textFood.GetComponent<Text> ().text = ap.es_infoSweetSalty;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titleSweetSalty;
				textFood.GetComponent<Text> ().text = ap.de_infoSweetSalty;
			}
		}
		else if(this.gameObject.name == "iconWater"){
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titleWater;
				textFood.GetComponent<Text> ().text = ap.en_infoWater;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titleWater;
				textFood.GetComponent<Text> ().text = ap.es_infoWater;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titleWater;
				textFood.GetComponent<Text> ().text = ap.de_infoWater;
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
			if (ap.language == "en") {
				titleFood.GetComponent<Text> ().text = ap.en_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.en_infoPyramid;
			} else if (ap.language == "es") {
				titleFood.GetComponent<Text> ().text = ap.es_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.es_infoPyramid;
			} else if (ap.language == "de") {
				titleFood.GetComponent<Text> ().text = ap.de_titlePyramid;
				textFood.GetComponent<Text> ().text = ap.de_infoPyramid;
			}
		}
	}
}
