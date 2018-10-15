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

	public GameObject GameOverObject;
	public GameObject LevelObject;
	public GameObject NextLevelObject;
	public GameObject TweetObject;

		public Sprite[] barWaterSprites;
		public Sprite[] barSportSprites;
		public Sprite[] timerSprites;

	public Sprite[] fruitSprites;

	// Use this for initialization
	void Start () {
		GameOverObject.SetActive(false);
		NextLevelObject.SetActive(false);
		TweetObject.SetActive(false);
		PopUpObject.SetActive(false);

		if (ApplicationModel.language == "en") {
			GameOverObject.GetComponent < Text >().text = ApplicationModel.en_scene_gameOverText;
			TweetObject.GetComponent < Text >().text = ApplicationModel.en_scene_TweetObjectText;
			PopUpObject.GetComponent < Text >().text = ApplicationModel.en_scene_popUpText;
			LevelObject.GetComponent < Text >().text = ApplicationModel.en_scene_levelText;
			NextLevelObject.GetComponent < Text >().text = ApplicationModel.en_scene_nextLevelText;
		}
		else if (ApplicationModel.language == "es") {
			GameOverObject.GetComponent < Text >().text = ApplicationModel.es_scene_gameOverText;
			TweetObject.GetComponent < Text >().text = ApplicationModel.es_scene_TweetObjectText;
			PopUpObject.GetComponent < Text >().text = ApplicationModel.es_scene_popUpText;
			LevelObject.GetComponent < Text >().text = ApplicationModel.es_scene_levelText;
			NextLevelObject.GetComponent < Text >().text = ApplicationModel.es_scene_nextLevelText;
		}
		else if (ApplicationModel.language == "de") {
			GameOverObject.GetComponent < Text >().text = ApplicationModel.de_scene_gameOverText;
			TweetObject.GetComponent < Text >().text = ApplicationModel.de_scene_TweetObjectText;
			PopUpObject.GetComponent < Text >().text = ApplicationModel.de_scene_popUpText; 
			LevelObject.GetComponent < Text >().text = ApplicationModel.de_scene_levelText;
			NextLevelObject.GetComponent < Text >().text = ApplicationModel.de_scene_nextLevelText;
		}

		LevelObject.GetComponent < Text > ().text += ApplicationModel.level;

		InvokeRepeating("decreaseTimer", 5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		ApplicationModel.totalTime += Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) { 
		
		if (other.gameObject.tag == "Good") {

			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Bicycle") {

			Destroy (other.gameObject);

			// Update the SPORTS BAR

			ApplicationModel.totalSport += 5;

			if (ApplicationModel.totalSport == 5) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[1];}
			else if (ApplicationModel.totalSport == 10) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[2];}
			else if (ApplicationModel.totalSport == 15) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[3];}
			else if (ApplicationModel.totalSport == 20) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[4];}
			else if (ApplicationModel.totalSport == 25) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[5];}
			else if (ApplicationModel.totalSport == 30) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[6];}
			else if (ApplicationModel.totalSport == 35) {BarSportObject.GetComponent<SpriteRenderer>().sprite = barSportSprites[7];}

			gameObject.SendMessage("HandleBicycleItemCollision");
		}

		if (other.gameObject.tag == "Water") {
			Destroy (other.gameObject);

			// Update the WATER BAR

			ApplicationModel.totalWater += 5;

			if (ApplicationModel.totalWater == 5) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[1];}
			else if (ApplicationModel.totalWater == 10) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[2];}
			else if (ApplicationModel.totalWater == 15) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[3];}
			else if (ApplicationModel.totalWater == 20) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[4];}
			else if (ApplicationModel.totalWater == 25) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[5];}
			else if (ApplicationModel.totalWater == 30) {BarWaterObject.GetComponent<SpriteRenderer>().sprite = barWaterSprites[6];}


			gameObject.SendMessage("HandleWaterItemCollision");
		}

		if (other.gameObject.tag == "EnergyDrink") {

			ApplicationModel.gameOver = true;

			// GAME OVER

			Destroy (other.gameObject);

			// End game, call for Restart
			GameOverObject.SetActive(true);
			//TweetObject.SetActive(true);

			gameObject.SendMessage("HandleEnergyDrinkItemCollision");
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

				NextLevelObject.SetActive(true);

				gameObject.SendMessage("HandleTimeout");
			}
		}
		return null;
	}
}