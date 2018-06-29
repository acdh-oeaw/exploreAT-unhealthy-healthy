using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemChecker : MonoBehaviour {

	public int score;
	public int lives;
	public GameObject ScoreObject; 
	public GameObject PopUpObject;
	Text scoreText; 
	public GameObject LivesObject;
	public GameObject BarPointsObject;
	public GameObject GameOverObject;
	public GameObject NextLevelObject;
	public GameObject TweetObject;
	public Sprite heart1,heart2,heart3;
	public Sprite bar0,bar5,bar10,bar15,bar20,bar25,bar30;
	public Sprite poweredCharacterSprite;
	public Sprite[] sprites;
	public float nextLevelScore;
	public Sprite[] fruitSprites;


	// Use this for initialization
	void Start () {
		scoreText = ScoreObject.GetComponent < Text >();
		lives = 3; ApplicationModel.lives = lives;
		score = 0;
		ApplicationModel.isPowered = false;
		nextLevelScore = 30;
		GameOverObject.SetActive(false);
		TweetObject.SetActive(false);
		ScoreObject.SetActive(true);
		PopUpObject.SetActive(false);

		scoreText.text = ApplicationModel.totalScore.ToString()+" Total Calories"; 
	}
	
	// Update is called once per frame
	void Update () {
		ApplicationModel.totalTime += Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) { 
		
		if (other.gameObject.tag == "Good") {

			Destroy (other.gameObject);

			if (lives > 0 && score < nextLevelScore) {

				changeCaloriesPopUpText (other.gameObject.GetComponent<SpriteRenderer> ().sprite.name);
				scoreText.text = ApplicationModel.totalScore.ToString()+" Total Calories"; 

				if (other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_0" ||
					other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_1" ||
					other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_2" ||
					other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_3") {
					score = score + 5;
				}
				else if (other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_4" ||
					other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_5" ||
					other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_6" ||
					other.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "fruits_7") {
					score = score + 10;
				}

				PopUpObject.GetComponent < Text >().color = new Color(48f/255.0f,128f/255.0f,41f/255.0f);
				PopUpObject.SetActive(true);
				StartCoroutine (hidePopUp ());

				// Update the points bar

				if (score == 0) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar0;}
				else if (score == 5) {BarPointsObject.GetComponent<SpriteRenderer> ().sprite = bar5;}
				else if (score == 10) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar10;}
				else if (score == 15) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar15;}
				else if (score == 20) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar20;}
				else if (score == 25) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar25;}
				else if (score == 30) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar30;}

				// Check if we cleared the level

				if (score == nextLevelScore) {
					NextLevelObject.SetActive(true);
					//gameObject.SendMessage("HandleGoodItemCollision",score);
				}
				gameObject.SendMessage("HandleGoodItemCollision",score);
			}
		}
		if (other.gameObject.tag == "Bad" || other.gameObject.tag == "Roller") {

			// If the player is powered nothing bad happens
			if (!ApplicationModel.isPowered) {

				// Destroy on contact

				Destroy (other.gameObject);

				// Handle bad interaction getting points/lives from the player

				if (lives > 0 && score < nextLevelScore) {

					changeCaloriesPopUpText (other.gameObject.GetComponent<SpriteRenderer> ().sprite.name);
					scoreText.text = ApplicationModel.totalScore.ToString()+" Total Calories"; 

					score = score - 10;

					PopUpObject.GetComponent < Text >().color = new Color(188f/255.0f,11f/255.0f,11f/255.0f);
					PopUpObject.SetActive(true);
					StartCoroutine (hidePopUp ());

					if (score < 0) {
						score = 0;
					}

					// Update the points bar

					if (score == 0) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar0;}
					else if (score == 5) {BarPointsObject.GetComponent<SpriteRenderer> ().sprite = bar5;}
					else if (score == 10) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar10;}
					else if (score == 15) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar15;}
					else if (score == 20) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar20;}
					else if (score == 25) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar25;}
					else if (score == 30) {BarPointsObject.GetComponent<SpriteRenderer>().sprite = bar30;}

					// Update the lives

					if (lives == 3) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart2; lives -= 1;}
					else if (lives == 2) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart1; lives -= 1;}
					else {LivesObject.GetComponent<SpriteRenderer>().sprite = null; lives -= 1;}

					ApplicationModel.lives = lives;

					// End game, call for Restart
					if (lives == 0) {
						GameOverObject.SetActive(true);
						TweetObject.SetActive(true);
					}

					gameObject.SendMessage("HandleBadItemCollision",lives);
				}
			}
		}	

		if (other.gameObject.tag == "Live") {

			Destroy (other.gameObject);

			if (lives < 3) {
				lives += 1;
				ApplicationModel.lives = lives;
				if (lives == 3) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart3;}
				else if (lives == 2) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart2;}
				else {LivesObject.GetComponent<SpriteRenderer>().sprite = heart1;}
			}

			gameObject.SendMessage("HandleGoodItemCollision",score);
		}

		if (other.gameObject.tag == "Star") {

			Destroy (other.gameObject);

			ApplicationModel.isPowered = true;
			GetComponent<SpriteRenderer> ().sprite = poweredCharacterSprite;
			Vector2 S = GetComponent<SpriteRenderer>().sprite.bounds.size;
			GetComponent<BoxCollider2D>().size = S;
			GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
			StartCoroutine (removePower());

			gameObject.SendMessage("HandleGoodItemCollision",score);
			gameObject.SendMessage("HandleStarItemCollision",false);
		}

		if (other.gameObject.tag == "Bomb") {

			Destroy (other.gameObject);

			GameObject[] badObjects = GameObject.FindGameObjectsWithTag("Bad");
			foreach(GameObject badObject in badObjects)
				GameObject.Destroy(badObject);
			GameObject[] rollerObjects = GameObject.FindGameObjectsWithTag("Roller");
			foreach(GameObject rollerObject in rollerObjects)
				GameObject.Destroy(rollerObject);

			gameObject.SendMessage("HandleGoodItemCollision",score);
		}

		if (other.gameObject.tag == "Bicycle") {

			Destroy (other.gameObject);

			transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

			gameObject.SendMessage("HandleGoodItemCollision",score);
		}

		if (other.gameObject.tag == "ItemChanger") {

			Destroy (other.gameObject);

			GameObject[] badObjects = GameObject.FindGameObjectsWithTag("Bad");
			foreach (GameObject badObject in badObjects) {
				badObject.tag = "Good";
				int num = 0;
				if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
					num = UnityEngine.Random.Range (0, 2);
				} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene2")) {
					num = UnityEngine.Random.Range (0, 4);
				} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene3")) {
					num = UnityEngine.Random.Range (0, fruitSprites.Length);
				}
				badObject.GetComponent<SpriteRenderer> ().sprite = fruitSprites [num];
			}

			GameObject[] rollerObjects = GameObject.FindGameObjectsWithTag("Roller");
			foreach(GameObject rollerObject in rollerObjects)
				GameObject.Destroy(rollerObject);

			gameObject.SendMessage("HandleGoodItemCollision",score);
		}
	}

	void changeCaloriesPopUpText(string item){
		int value = 0;
		if (item == "fruits_0") { // apple
			value = 55;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_1") { // pineapple
			value = 50;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_2") { // watermelon
			value = 30;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_3") { // strawberry
			value = 35;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_4") { // pear
			value = 55;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_5") { // orange
			value = 45;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_6") { // cherry
			value = 50;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}
		else if (item == "fruits_7") { // banana
			value = 90;
			PopUpObject.GetComponent < Text >().text = "+"+value+" Calories !!!";
		}

		else if (item == "fastfood_0") { // egg
			value = -190;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "fastfood_1") { // fries
			value = -300;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "fastfood_2") { // pizza
			value = -260;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "fastfood_3") { // steak
			value = -80;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "fastfood_4") { // bacon
			value = -350;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "fastfood_5") { // hotdog
			value = -290;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "fastfood_6") { // burger
			value = -275;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}
		else if (item == "roller") { // pizza roll
			value = -130;
			PopUpObject.GetComponent < Text >().text = ""+value+" Calories !!!";
		}

		updateTotalScore (value);
	}

	void updateTotalScore(int value){
		ApplicationModel.totalScore += value;
	}

	IEnumerator hidePopUp(){
		yield return new WaitForSeconds(2);
		PopUpObject.SetActive (false);
	}

	IEnumerator removePower(){
		yield return new WaitForSeconds(10);
		ApplicationModel.isPowered = false;
		GetComponent<SpriteRenderer> ().sprite = sprites[ApplicationModel.spriteNum];
		Vector2 S = GetComponent<SpriteRenderer>().sprite.bounds.size;
		GetComponent<BoxCollider2D>().size = S;
		GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
		gameObject.SendMessage("HandleStarItemCollision",true);
	}
}