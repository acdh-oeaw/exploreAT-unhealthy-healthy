using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemChecker : MonoBehaviour {

	public GameObject PopUpObject;
	Text scoreText; 

		public GameObject BarWaterObject;
		public GameObject BarSportObject;
		public GameObject TimerObject;

		public GameObject checkBreadPastaObject;
		public GameObject checkFruitVeggiesObject;
		public GameObject checkMeatFishObject;
		public GameObject checkMilkCheeseObject;
		public GameObject checkSweetSaltyObject;

		public GameObject counterBreadPastaObject;
		public GameObject counterFruitVeggiesObject;
		public GameObject counterMeatFishObject;
		public GameObject counterMilkCheeseObject;
		public GameObject counterSweetSaltyObject;

	public GameObject GameOverObject;
	public GameObject LevelObject;

		public Sprite[] barWaterSprites;
		public Sprite[] barSportSprites;
		public Sprite[] timerSprites;

		public Sprite[] checkBreadPastaSprites;
		public Sprite[] checkFruitVeggiesSprites;
		public Sprite[] checkMeatFishSprites;
		public Sprite[] checkMilkCheeseSprites;
		public Sprite[] checkSweetSaltySprites;

	public GameObject TimeUpObject;
	public GameObject CheckProgressObject;

	public Sprite[] fruitSprites;

	// Use this for initialization
	void Start () {
		
		PopUpObject.SetActive (false);
		GameOverObject.SetActive (false);
		TimeUpObject.SetActive(false);
		CheckProgressObject.SetActive (false);

		// From zero to value - model
//		counterBreadPastaObject.GetComponent < Text > ().text = ""+0;
//		counterFruitVeggiesObject.GetComponent < Text > ().text = ""+0;
//		counterMeatFishObject.GetComponent < Text > ().text = ""+0;
//		counterMilkCheeseObject.GetComponent < Text > ().text = ""+0;
//		counterSweetSaltyObject.GetComponent < Text > ().text = ""+0;

		// From value to zero - model
		counterBreadPastaObject.GetComponent < Text > ().text = ""+((ApplicationModel.counterBreadPastaMax-ApplicationModel.counterBreadPastaMin)-ApplicationModel.counterBreadPasta);
		counterFruitVeggiesObject.GetComponent < Text > ().text = ""+(ApplicationModel.counterFruitVeggiesValue-ApplicationModel.counterFruitVeggies);
		counterMeatFishObject.GetComponent < Text > ().text = ""+((ApplicationModel.counterMeatFishMax-ApplicationModel.counterMeatFishMin)-ApplicationModel.counterMeatFish);
		counterMilkCheeseObject.GetComponent < Text > ().text = ""+(ApplicationModel.counterMilkCheeseValue-ApplicationModel.counterMilkCheese);
		counterSweetSaltyObject.GetComponent < Text > ().text = ""+(ApplicationModel.counterSweetSaltyValue-ApplicationModel.counterSweetSalty);

		if (ApplicationModel.language == "en") {
			GameOverObject.GetComponent < Text > ().text = ApplicationModel.en_scene_gameOverText;
			TimeUpObject.GetComponent < Text >().text = ApplicationModel.en_scene_timeupText;
			CheckProgressObject.GetComponent < Text >().text = ApplicationModel.en_scene_checkProgressText;
		}
		else if (ApplicationModel.language == "es") {
			GameOverObject.GetComponent < Text > ().text = ApplicationModel.es_scene_gameOverText;
			TimeUpObject.GetComponent < Text >().text = ApplicationModel.es_scene_timeupText;
			CheckProgressObject.GetComponent < Text >().text = ApplicationModel.es_scene_checkProgressText;
		}
		else if (ApplicationModel.language == "de") {
			GameOverObject.GetComponent < Text > ().text = ApplicationModel.de_scene_gameOverText;
			TimeUpObject.GetComponent < Text >().text = ApplicationModel.de_scene_timeupText;
			CheckProgressObject.GetComponent < Text >().text = ApplicationModel.de_scene_checkProgressText;
		}

		LevelObject.GetComponent < Text > ().text += ApplicationModel.level;

		//InvokeRepeating("decreaseTimer", 5, 5);
		InvokeRepeating("decreaseTimer", 8, 8); // 1 minute rounds
	}
	
	// Update is called once per frame
	void Update () {
		ApplicationModel.totalTime += Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) { 

		if (TimeUpObject.activeSelf || GameOverObject.activeSelf) {
			return;
		}

		if (other.gameObject.tag == "Good") {
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "FoodBreadPasta") {
			updateCounter ("breadPasta", ApplicationModel.valueBreadPasta);
//			counterBreadPastaObject.GetComponent < Text > ().text = ""+ApplicationModel.counterBreadPasta;
			if (ApplicationModel.counterBreadPasta >= ApplicationModel.counterBreadPastaMin && ApplicationModel.counterBreadPasta <= ApplicationModel.counterBreadPastaMax) {
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [0];
			} else {
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodFruitVeggies") {
			updateCounter ("fruitVeggies", ApplicationModel.valueFruitVeggies);		
//			counterFruitVeggiesObject.GetComponent < Text > ().text = ""+ApplicationModel.counterFruitVeggies;
			if (ApplicationModel.counterFruitVeggies >= ApplicationModel.counterFruitVeggiesValue) {
				checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [0];
			} else {
				checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodMeatFish") {
			updateCounter ("meatFish", ApplicationModel.valueMeatFish);
//			counterMeatFishObject.GetComponent < Text > ().text = ""+ApplicationModel.counterMeatFish;
			if (ApplicationModel.counterMeatFish >= ApplicationModel.counterMeatFishMin && ApplicationModel.counterMeatFish <= ApplicationModel.counterMeatFishMax) {
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [0];
			} else {
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodMilkCheese") {
			updateCounter ("milkCheese", ApplicationModel.valueMilkCheese);
//			counterMilkCheeseObject.GetComponent < Text > ().text = ""+ApplicationModel.counterMilkCheese;
			if (ApplicationModel.counterMilkCheese >= ApplicationModel.counterMilkCheeseValue) {
				checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [0];
			} else {
				checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodSweetSalty") {
			updateCounter ("sweetSalty", ApplicationModel.valueSweetSalty);
//			counterSweetSaltyObject.GetComponent < Text > ().text = ""+ApplicationModel.counterSweetSalty;
			if (ApplicationModel.counterSweetSalty <= ApplicationModel.counterSweetSaltyValue) {
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [0];
			} else {
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [1];
			}
			Destroy (other.gameObject);

			// Check for game over
			if (ApplicationModel.counterSweetSalty > ApplicationModel.counterSweetSaltyValue) {
				// GAME OVER
				ApplicationModel.gameOver = true;
				Destroy (other.gameObject);
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}

		else if (other.gameObject.tag == "Bicycle") {

			Destroy (other.gameObject);

			// Update the SPORTS BAR

			if (ApplicationModel.totalSport >= ApplicationModel.counterSportValue)
				return;
			
			ApplicationModel.totalSport += ApplicationModel.valueSport;

			if (ApplicationModel.totalSport == 1) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[1];}
			else if (ApplicationModel.totalSport == 2) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[2];}
			else if (ApplicationModel.totalSport == 3) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[3];}
			else if (ApplicationModel.totalSport == 4) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[4];}
			else if (ApplicationModel.totalSport == 5) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[5];}
			else if (ApplicationModel.totalSport == 6) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[6];}
			else if (ApplicationModel.totalSport == 7) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[7];}

			gameObject.SendMessage("HandleBicycleItemCollision");
		}

		else if (other.gameObject.tag == "Water") {
			Destroy (other.gameObject);

			// Update the WATER BAR

			if (ApplicationModel.totalWater >= ApplicationModel.counterWaterValue)
				return;

			ApplicationModel.totalWater += ApplicationModel.valueWater;

			if (ApplicationModel.totalWater == 1) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[1];}
			else if (ApplicationModel.totalWater == 2) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[2];}
			else if (ApplicationModel.totalWater == 3) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[3];}
			else if (ApplicationModel.totalWater == 4) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[4];}
			else if (ApplicationModel.totalWater == 5) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[5];}
			else if (ApplicationModel.totalWater == 6) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[6];}


			gameObject.SendMessage("HandleWaterItemCollision");
		}

		else if (other.gameObject.tag == "EnergyDrink") {
			// GAME OVER
			ApplicationModel.gameOver = true;
			Destroy (other.gameObject);
			GameOverObject.SetActive(true);
			gameObject.SendMessage("HandleEnergyDrinkItemCollision");
		}

		// Update counter values
		if (((ApplicationModel.counterBreadPastaMax - ApplicationModel.counterBreadPastaMin) - ApplicationModel.counterBreadPasta) > 0) {
			counterBreadPastaObject.GetComponent < Text > ().text = ""+((ApplicationModel.counterBreadPastaMax-ApplicationModel.counterBreadPastaMin)-ApplicationModel.counterBreadPasta);
		} else {
			counterBreadPastaObject.GetComponent < Text > ().text = "0";
			checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [0];
			if(ApplicationModel.counterBreadPasta > ApplicationModel.counterBreadPastaMax){
				// GAME OVER
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [1];
				ApplicationModel.gameOver = true;
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}
		if ((ApplicationModel.counterFruitVeggiesValue - ApplicationModel.counterFruitVeggies) > 0) {
			counterFruitVeggiesObject.GetComponent < Text > ().text = ""+(ApplicationModel.counterFruitVeggiesValue-ApplicationModel.counterFruitVeggies);
		} else {
			counterFruitVeggiesObject.GetComponent < Text > ().text = "0";
			checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [0];
		}
		if (((ApplicationModel.counterMeatFishMax - ApplicationModel.counterMeatFishMin) - ApplicationModel.counterMeatFish) > 0) {
			counterMeatFishObject.GetComponent < Text > ().text = ""+((ApplicationModel.counterMeatFishMax-ApplicationModel.counterMeatFishMin)-ApplicationModel.counterMeatFish);
		} else {
			counterMeatFishObject.GetComponent < Text > ().text = "0";
			checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [0];
			if(ApplicationModel.counterMeatFish > ApplicationModel.counterMeatFishMax){
				// GAME OVER
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [1];
				ApplicationModel.gameOver = true;
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}
		if ((ApplicationModel.counterMilkCheeseValue-ApplicationModel.counterMilkCheese) > 0) {
			counterMilkCheeseObject.GetComponent < Text > ().text = ""+(ApplicationModel.counterMilkCheeseValue-ApplicationModel.counterMilkCheese);
		} else {
			counterMilkCheeseObject.GetComponent < Text > ().text = "0";
			checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [0];
		}
		if ((ApplicationModel.counterSweetSaltyValue-ApplicationModel.counterSweetSalty) > 0) {
			counterSweetSaltyObject.GetComponent < Text > ().text = ""+(ApplicationModel.counterSweetSaltyValue-ApplicationModel.counterSweetSalty);
		} else {
			counterSweetSaltyObject.GetComponent < Text > ().text = "0";
			if(ApplicationModel.counterSweetSalty > ApplicationModel.counterSweetSaltyValue){
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [1];
				// GAME OVER
				ApplicationModel.gameOver = true;
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}
	}

	void updateCounter(string type, int value){
		if (type == "breadPasta") {
			ApplicationModel.counterBreadPasta += value;
		}
		else if(type == "fruitVeggies"){
			ApplicationModel.counterFruitVeggies += value;
		}
		else if(type == "meatFish"){
			ApplicationModel.counterMeatFish += value;
		}
		else if(type == "milkCheese"){
			ApplicationModel.counterMilkCheese += value;
		}
		else if(type == "sweetSalty"){
			ApplicationModel.counterSweetSalty += value;
		}
	}

	IEnumerator hidePopUp(){
		yield return new WaitForSeconds(2);
		PopUpObject.SetActive (false);
	}

	IEnumerator decreaseTimer(){

		if (ApplicationModel.timerSlices > 0) {

			ApplicationModel.timerSlices -= 1;

			if (ApplicationModel.timerSlices == 6) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [6];
			} else if (ApplicationModel.timerSlices == 5) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [5];
			} else if (ApplicationModel.timerSlices == 4) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [4];
			} else if (ApplicationModel.timerSlices == 3) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [3];
			} else if (ApplicationModel.timerSlices == 2) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [2];
			} else if (ApplicationModel.timerSlices == 1) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [1];
			}
			else if (ApplicationModel.timerSlices == 0) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites[0];

				// SHOW RESULTS PANEL

				TimeUpObject.SetActive(true);
				CheckProgressObject.SetActive(true);
				GameOverObject.SetActive (false);

				gameObject.SendMessage("HandleTimeup");
			}
		}
		return null;
	}
}