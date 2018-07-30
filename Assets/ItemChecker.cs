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
	public GameObject BarLiveObject;
	public GameObject GameOverObject;
	public GameObject LevelObject;
	public GameObject NextLevelObject;
	public GameObject TweetObject;
	public Sprite heart1,heart2,heart3,heart4,heart5;
	public Sprite bar0,bar5,bar10,bar15,bar20,bar25,bar30;
	public Sprite barLive0,barLive5,barLive10,barLive15,barLive20,barLive25,barLive30;
	public int barLiveState;
	public Sprite poweredCharacterSprite;
	public Sprite[] sprites;
	public float nextLevelScore;
	public Sprite[] fruitSprites;


	// Use this for initialization
	void Start () {
		scoreText = ScoreObject.GetComponent < Text >();
		lives = 5; ApplicationModel.lives = lives;
		barLiveState = 0;
		score = 0;
		ApplicationModel.isPowered = false;
		nextLevelScore = 30;
		GameOverObject.SetActive(false);
		TweetObject.SetActive(false);
		ScoreObject.SetActive(true);
		PopUpObject.SetActive(false);


		// Free lives bar decreases its filling speed depending on the level
		if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
			InvokeRepeating("increaseLiveBar", 0, 2);
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene2")) {
			InvokeRepeating("increaseLiveBar", 0, 4);
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene3")) {
			InvokeRepeating("increaseLiveBar", 0, 6);
		}


		if (ApplicationModel.language == "en") {
			scoreText.text = ApplicationModel.totalScore.ToString()+ApplicationModel.en_scene_scoreText; 
			GameOverObject.GetComponent < Text >().text = ApplicationModel.en_scene_gameOverText;
			TweetObject.GetComponent < Text >().text = ApplicationModel.en_scene_TweetObjectText;
			PopUpObject.GetComponent < Text >().text = ApplicationModel.en_scene_popUpText;
			LevelObject.GetComponent < Text >().text = ApplicationModel.en_scene_levelText;
			NextLevelObject.GetComponent < Text >().text = ApplicationModel.en_scene_nextLevelText;
		}
		else if (ApplicationModel.language == "es") {
			scoreText.text = ApplicationModel.totalScore.ToString()+ApplicationModel.es_scene_scoreText; 
			GameOverObject.GetComponent < Text >().text = ApplicationModel.es_scene_gameOverText;
			TweetObject.GetComponent < Text >().text = ApplicationModel.es_scene_TweetObjectText;
			PopUpObject.GetComponent < Text >().text = ApplicationModel.es_scene_popUpText;
			LevelObject.GetComponent < Text >().text = ApplicationModel.es_scene_levelText;
			NextLevelObject.GetComponent < Text >().text = ApplicationModel.es_scene_nextLevelText;
		}
		else if (ApplicationModel.language == "de") {
			scoreText.text = ApplicationModel.totalScore.ToString()+ApplicationModel.de_scene_scoreText; 
			GameOverObject.GetComponent < Text >().text = ApplicationModel.de_scene_gameOverText;
			TweetObject.GetComponent < Text >().text = ApplicationModel.de_scene_TweetObjectText;
			PopUpObject.GetComponent < Text >().text = ApplicationModel.de_scene_popUpText; 
			LevelObject.GetComponent < Text >().text = ApplicationModel.de_scene_levelText;
			NextLevelObject.GetComponent < Text >().text = ApplicationModel.de_scene_nextLevelText;
		}

		if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
			LevelObject.GetComponent < Text > ().text += 1;
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene2")) {
			LevelObject.GetComponent < Text > ().text += 2;
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene3")) {
			LevelObject.GetComponent < Text > ().text += 3;
		}

	}
	
	// Update is called once per frame
	void Update () {
		ApplicationModel.totalTime += Time.deltaTime;
		if (lives > 5) {
			lives = 5;
			ApplicationModel.lives = lives;
		}
	}

	void updateScoreText(){
		if (ApplicationModel.language == "en") {
			scoreText.text = ApplicationModel.totalScore.ToString () + ApplicationModel.en_scene_scoreText; 
		}
		else if (ApplicationModel.language == "es") {
			scoreText.text = ApplicationModel.totalScore.ToString()+ApplicationModel.es_scene_scoreText; 
		}
		else if (ApplicationModel.language == "de") {
			scoreText.text = ApplicationModel.totalScore.ToString()+ApplicationModel.de_scene_scoreText; 
		}
	}

	void OnTriggerEnter2D (Collider2D other) { 
		
		if (other.gameObject.tag == "Good") {

			Destroy (other.gameObject);

			if (lives > 0 && score < nextLevelScore) {

				changeCaloriesPopUpText (other.gameObject.GetComponent<SpriteRenderer> ().sprite.name);
				updateScoreText ();

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
					updateScoreText ();

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

					if (lives == 5) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart4; lives -= 1;}
					else if (lives == 4) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart3; lives -= 1;}
					else if (lives == 3) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart2; lives -= 1;}
					else if (lives == 2) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart1; lives -= 1;}
					else {LivesObject.GetComponent<SpriteRenderer>().sprite = null; lives -= 1;}

					// Unfill the free lives bar
					BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive0;
					barLiveState = 0;

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

			if (lives < 5) {
				lives += 1;
				ApplicationModel.lives = lives;
				if (lives == 5) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart5;}
				else if (lives == 4) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart4;}
				else if (lives == 3) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart3;}
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
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}
		else if (item == "fruits_1") { // pineapple
			value = 50;
			PopUpObject.GetComponent < Text > ().text = "+" + value;
		}
		else if (item == "fruits_2") { // watermelon
			value = 30;
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}
		else if (item == "fruits_3") { // strawberry
			value = 35;
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}
		else if (item == "fruits_4") { // pear
			value = 55;
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}
		else if (item == "fruits_5") { // orange
			value = 45;
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}
		else if (item == "fruits_6") { // cherry
			value = 50;
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}
		else if (item == "fruits_7") { // banana
			value = 90;
			PopUpObject.GetComponent < Text >().text = "+"+value;
		}

		else if (item == "fastfood_0") { // egg
			value = -190;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "fastfood_1") { // fries
			value = -300;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "fastfood_2") { // pizza
			value = -260;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "fastfood_3") { // steak
			value = -80;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "fastfood_4") { // bacon
			value = -350;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "fastfood_5") { // hotdog
			value = -290;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "fastfood_6") { // burger
			value = -275;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}
		else if (item == "roller") { // pizza roll
			value = -130;
			PopUpObject.GetComponent < Text >().text = ""+value;
		}

		if (ApplicationModel.language == "en") {
			PopUpObject.GetComponent < Text >().text += ApplicationModel.en_scene_popUpText;
		}
		else if (ApplicationModel.language == "es") {
			PopUpObject.GetComponent < Text >().text += ApplicationModel.es_scene_popUpText;
		}
		else if (ApplicationModel.language == "de") {
			PopUpObject.GetComponent < Text >().text += ApplicationModel.de_scene_popUpText; 
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

	IEnumerator increaseLiveBar(){
		if (lives < 5) {
			if (barLiveState == 0) {BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive5; barLiveState = 5;}
			else if (barLiveState == 5) {BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive10; barLiveState = 10;}
			else if (barLiveState == 10) {BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive15; barLiveState = 15;}
			else if (barLiveState == 15) {BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive20; barLiveState = 20;}
			else if (barLiveState == 20) {BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive25; barLiveState = 25;}
			else if (barLiveState == 25) {BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive30; barLiveState = 30;}
			else if (barLiveState == 30) {
				BarLiveObject.GetComponent<SpriteRenderer>().sprite = barLive0;
				barLiveState = 0;
				if (lives == 4) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart5; lives += 1;}
				else if (lives == 3) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart4; lives += 1;}
				else if (lives == 2) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart3; lives += 1;}
				else if (lives == 1) {LivesObject.GetComponent<SpriteRenderer>().sprite = heart2; lives += 1;}
				ApplicationModel.lives = lives;
			}
		}
		return null;
	}
}