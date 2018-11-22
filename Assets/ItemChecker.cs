using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

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
		counterBreadPastaObject.GetComponent < Text > ().text = ""+((ap.counterBreadPastaMin)-ap.counterBreadPasta);
		counterFruitVeggiesObject.GetComponent < Text > ().text = ""+(ap.counterFruitVeggiesValue-ap.counterFruitVeggies);
		counterMeatFishObject.GetComponent < Text > ().text = ""+((ap.counterMeatFishMin)-ap.counterMeatFish);
		counterMilkCheeseObject.GetComponent < Text > ().text = ""+(ap.counterMilkCheeseValue-ap.counterMilkCheese);
		counterSweetSaltyObject.GetComponent < Text > ().text = ""+(ap.counterSweetSaltyValue-ap.counterSweetSalty);

		if (ap.language == "en") {
			GameOverObject.GetComponent < Text > ().text = ap.en_scene_gameOverText;
			TimeUpObject.GetComponent < Text >().text = ap.en_scene_timeupText;
			CheckProgressObject.GetComponent < Text >().text = ap.en_scene_checkProgressText;
		}
		else if (ap.language == "es") {
			GameOverObject.GetComponent < Text > ().text = ap.es_scene_gameOverText;
			TimeUpObject.GetComponent < Text >().text = ap.es_scene_timeupText;
			CheckProgressObject.GetComponent < Text >().text = ap.es_scene_checkProgressText;
		}
		else if (ap.language == "de") {
			GameOverObject.GetComponent < Text > ().text = ap.de_scene_gameOverText;
			TimeUpObject.GetComponent < Text >().text = ap.de_scene_timeupText;
			CheckProgressObject.GetComponent < Text >().text = ap.de_scene_checkProgressText;
		}

		LevelObject.GetComponent < Text > ().text += ap.level;

		//InvokeRepeating("decreaseTimer", 5, 5);
		InvokeRepeating("decreaseTimer", 8, 8); // 1 minute rounds
	}
	
	// Update is called once per frame
	void Update () {
		ap.totalTime += Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) { 

		if (TimeUpObject.activeSelf || GameOverObject.activeSelf) {
			return;
		}

		if (other.gameObject.tag == "Good") {
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "FoodBreadPasta") {
			updateCounter ("breadPasta", ap.valueBreadPasta);
//			counterBreadPastaObject.GetComponent < Text > ().text = ""+ap.counterBreadPasta;
			if (ap.counterBreadPasta >= ap.counterBreadPastaMin && ap.counterBreadPasta <= ap.counterBreadPastaMax) {
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [0];
			} else {
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodFruitVeggies") {
			updateCounter ("fruitVeggies", ap.valueFruitVeggies);		
//			counterFruitVeggiesObject.GetComponent < Text > ().text = ""+ap.counterFruitVeggies;
			if (ap.counterFruitVeggies >= ap.counterFruitVeggiesValue) {
				checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [0];
			} else {
				checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodMeatFish") {
			updateCounter ("meatFish", ap.valueMeatFish);
//			counterMeatFishObject.GetComponent < Text > ().text = ""+ap.counterMeatFish;
			if (ap.counterMeatFish >= ap.counterMeatFishMin && ap.counterMeatFish <= ap.counterMeatFishMax) {
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [0];
			} else {
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodMilkCheese") {
			updateCounter ("milkCheese", ap.valueMilkCheese);
//			counterMilkCheeseObject.GetComponent < Text > ().text = ""+ap.counterMilkCheese;
			if (ap.counterMilkCheese >= ap.counterMilkCheeseValue) {
				checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [0];
			} else {
				checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [1];
			}
			Destroy (other.gameObject);
		}

		else if (other.gameObject.tag == "FoodSweetSalty") {
			updateCounter ("sweetSalty", ap.valueSweetSalty);
//			counterSweetSaltyObject.GetComponent < Text > ().text = ""+ap.counterSweetSalty;
			if (ap.counterSweetSalty <= ap.counterSweetSaltyValue) {
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [0];
			} else {
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [1];
			}
			Destroy (other.gameObject);

			// Check for game over
			if (ap.counterSweetSalty > ap.counterSweetSaltyValue) {
				// GAME OVER
				ap.gameOver = true;
				Destroy (other.gameObject);
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}

		else if (other.gameObject.tag == "Bicycle") {

			Destroy (other.gameObject);

			// Update the SPORTS BAR

			if (ap.totalSport >= ap.counterSportValue)
				return;
			
			ap.totalSport += ap.valueSport;

			if (ap.totalSport == 1) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[1];}
			else if (ap.totalSport == 2) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[2];}
			else if (ap.totalSport == 3) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[3];}
			else if (ap.totalSport == 4) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[4];}
			else if (ap.totalSport == 5) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[5];}
			else if (ap.totalSport == 6) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[6];}
			else if (ap.totalSport == 7) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[7];}

			gameObject.SendMessage("HandleBicycleItemCollision");
		}

		else if (other.gameObject.tag == "Water") {
			Destroy (other.gameObject);

			// Update the WATER BAR

			if (ap.totalWater >= ap.counterWaterValue)
				return;

			ap.totalWater += ap.valueWater;

			if (ap.totalWater == 1) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[1];}
			else if (ap.totalWater == 2) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[2];}
			else if (ap.totalWater == 3) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[3];}
			else if (ap.totalWater == 4) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[4];}
			else if (ap.totalWater == 5) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[5];}
			else if (ap.totalWater == 6) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[6];}


			gameObject.SendMessage("HandleWaterItemCollision");
		}

		else if (other.gameObject.tag == "EnergyDrink") {
			// GAME OVER
			ap.gameOver = true;
			Destroy (other.gameObject);
			GameOverObject.SetActive(true);
			gameObject.SendMessage("HandleEnergyDrinkItemCollision");
		}

		// Update counter values and green/red/yellow graphics
		if ((ap.counterBreadPasta) < ap.counterBreadPastaMin) {
			counterBreadPastaObject.GetComponent < Text > ().text = ""+((ap.counterBreadPastaMin)-ap.counterBreadPasta);
			if ((ap.counterBreadPasta) > (ap.counterBreadPastaMin-(ap.counterBreadPastaMax - ap.counterBreadPastaMin))/2) {
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [2];
			}
		} else {
			counterBreadPastaObject.GetComponent < Text > ().text = "0";
			checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [0];
			if(ap.counterBreadPasta >= ap.counterBreadPastaMax){
				// GAME OVER
				checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [1];
				ap.gameOver = true;
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}
		if ((ap.counterFruitVeggiesValue - ap.counterFruitVeggies) > 0) {
			counterFruitVeggiesObject.GetComponent < Text > ().text = ""+(ap.counterFruitVeggiesValue-ap.counterFruitVeggies);
			if ((ap.counterFruitVeggies) > ap.counterFruitVeggiesValue/2) {
				checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [2];
			}
		} else {
			counterFruitVeggiesObject.GetComponent < Text > ().text = "0";
			checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [0];
		}
		if ((ap.counterMeatFish) < ap.counterMeatFishMin) {
			counterMeatFishObject.GetComponent < Text > ().text = ""+((ap.counterMeatFishMin)-ap.counterMeatFish);
			if ((ap.counterMeatFish) > (ap.counterMeatFishMin-(ap.counterMeatFishMax - ap.counterMeatFishMin))/2) {
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [2];
			}
		} else {
			counterMeatFishObject.GetComponent < Text > ().text = "0";
			checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [0];
			if(ap.counterMeatFish >= ap.counterMeatFishMax){
				// GAME OVER
				checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [1];
				ap.gameOver = true;
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}
		if ((ap.counterMilkCheeseValue-ap.counterMilkCheese) > 0) {
			counterMilkCheeseObject.GetComponent < Text > ().text = ""+(ap.counterMilkCheeseValue-ap.counterMilkCheese);
			if ((ap.counterMilkCheese) > ap.counterMilkCheeseValue/2) {
				checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [2];
			}
		} else {
			counterMilkCheeseObject.GetComponent < Text > ().text = "0";
			checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [0];
		}
		if ((ap.counterSweetSaltyValue-ap.counterSweetSalty) > 0) {
			counterSweetSaltyObject.GetComponent < Text > ().text = ""+(ap.counterSweetSaltyValue-ap.counterSweetSalty);
			if ((ap.counterSweetSalty) > ap.counterSweetSaltyValue/2) {
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [2];
			}
		} else {
			counterSweetSaltyObject.GetComponent < Text > ().text = "0";
			if(ap.counterSweetSalty > ap.counterSweetSaltyValue){
				checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [1];
				// GAME OVER
				ap.gameOver = true;
				GameOverObject.SetActive(true);
				gameObject.SendMessage("HandleEnergyDrinkItemCollision");
			}
		}
	}

	void updateCounter(string type, int value){
		if (type == "breadPasta") {
			ap.counterBreadPasta += value;
		}
		else if(type == "fruitVeggies"){
			ap.counterFruitVeggies += value;
		}
		else if(type == "meatFish"){
			ap.counterMeatFish += value;
		}
		else if(type == "milkCheese"){
			ap.counterMilkCheese += value;
		}
		else if(type == "sweetSalty"){
			ap.counterSweetSalty += value;
		}
	}

	IEnumerator hidePopUp(){
		yield return new WaitForSeconds(2);
		PopUpObject.SetActive (false);
	}

	IEnumerator decreaseTimer(){

		if (ap.timerSlices > 0) {

			ap.timerSlices -= 1;

			if (ap.timerSlices == 6) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [6];
			} else if (ap.timerSlices == 5) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [5];
			} else if (ap.timerSlices == 4) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [4];
			} else if (ap.timerSlices == 3) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [3];
			} else if (ap.timerSlices == 2) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [2];
			} else if (ap.timerSlices == 1) {
				TimerObject.GetComponent<SpriteRenderer> ().sprite = timerSprites [1];
			}
			else if (ap.timerSlices == 0) {
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