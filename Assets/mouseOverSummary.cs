using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseOverSummary : MonoBehaviour {

	public GameObject panelFood;
	public Text textFood;
	public Text titleFood;

	// Use this for initialization
	void Start () {
		panelFood.SetActive (false);
		textFood.GetComponent<Text> ().text = "";
		titleFood.GetComponent<Text> ().text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver()
	{
		panelFood.SetActive (true);
		if (this.gameObject.name == "checkPastaBread") {
			titleFood.GetComponent<Text> ().text = "Bread & Pasta";
		}
		else if(this.gameObject.name == "checkFruitVeggies"){
			titleFood.GetComponent<Text> ().text = "Fruit & Vegetables";
		}
		else if(this.gameObject.name == "checkMeatFish"){
			titleFood.GetComponent<Text> ().text = "Meat, Fish & Eggs";
		}
		else if(this.gameObject.name == "checkMilkCheese"){
			titleFood.GetComponent<Text> ().text = "Dairy Products";
		}
		else if(this.gameObject.name == "checkSweetSalty"){
			titleFood.GetComponent<Text> ().text = "Sweets and Salties";
		}
		textFood.GetComponent<Text> ().text = "Informative Text Goes Here !!!";
	}

	void OnMouseExit()
	{
		panelFood.SetActive (false);
		textFood.GetComponent<Text> ().text = "";
		titleFood.GetComponent<Text> ().text = "";
	}
}
