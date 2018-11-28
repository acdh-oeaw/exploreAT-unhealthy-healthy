using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class playerInitializer : MonoBehaviour {

	public GameObject GameOverObject; 
	public GameObject PopUpObject; 
	public GameObject TimeUpObject; 
	public GameObject CheckProgressObject; 
	public GameObject character;
	public Sprite[] spritesBoys;
	public Sprite[] spritesGirls;
	public GameObject seasonBackground;
	public Sprite[] spritesBackground;
	public GameObject ground;
	public Sprite[] spritesGround;

	// Use this for initialization
	void Start () {

		// Reset timer
		ap.timerSlices = 7;

		Color zm = GameOverObject.GetComponent < Text >().color;  //  makes a new color zm
		zm.a = 0.0f; // makes the color zm transparent
		if(ap.spriteGender == 0){
			character.GetComponent<SpriteRenderer> ().sprite = spritesGirls[ap.spriteNum];
		}
		else if(ap.spriteGender == 1){
			character.GetComponent<SpriteRenderer> ().sprite = spritesBoys[ap.spriteNum];
		}
		Vector2 S = character.GetComponent<SpriteRenderer>().sprite.bounds.size;
		//character.GetComponent<BoxCollider2D>().size = S;
		character.GetComponent<BoxCollider2D>().size = new Vector3(S.x/2,S.y);
		//character.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);

		// Change sky colour, season background and season ground
		if (ap.season == 0) {
			Camera.main.GetComponent<Camera>().backgroundColor = new Color(100f/255f,200f/255f,250f/255f,0f);
			ground.GetComponent<SpriteRenderer> ().sprite = spritesGround[0];
			seasonBackground.GetComponent<SpriteRenderer> ().sprite = spritesBackground[0];
		}
		else if (ap.season == 1) {
			Camera.main.GetComponent<Camera>().backgroundColor = new Color(185f/255f,215f/255f,230f/255f,0f);
			ground.GetComponent<SpriteRenderer> ().sprite = spritesGround[1];
			seasonBackground.GetComponent<SpriteRenderer> ().sprite = spritesBackground[1];
		}

		seasonBackground.transform.SetAsFirstSibling ();

		// Message language change
		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			if (ap.language == "en") {
				GameOverObject.GetComponent < Text >().text = ap.en_scene_gameOverText;
				TimeUpObject.GetComponent < Text >().text = ap.en_scene_timeupText;
				CheckProgressObject.GetComponent < Text >().text = ap.en_scene_checkProgressText;
			}
			else if (ap.language == "es") {
				GameOverObject.GetComponent < Text >().text = ap.es_scene_gameOverText;
				TimeUpObject.GetComponent < Text >().text = ap.es_scene_timeupText;
				CheckProgressObject.GetComponent < Text >().text = ap.es_scene_checkProgressText;
			}
			else if (ap.language == "de") {
				GameOverObject.GetComponent < Text >().text = ap.de_scene_gameOverText;
				TimeUpObject.GetComponent < Text >().text = ap.de_scene_timeupText;
				CheckProgressObject.GetComponent < Text >().text = ap.de_scene_checkProgressText;
			}
		}

		ResetFoodCounters ();
	}

	void ResetFoodCounters(){
		// Reset stuff (from 0 to value - model)
				ap.counterBreadPasta = 0;
				ap.counterFruitVeggies = 0;
				ap.counterMeatFish = 0;
				ap.counterMilkCheese = 0;
				ap.counterSweetSalty = 0;
		// Reset stuff (from value to 0 - model)
//		ap.counterBreadPasta = (ap.counterBreadPastaMax-ap.counterBreadPastaMin);
//		ap.counterFruitVeggies = ap.counterFruitVeggiesValue;
//		ap.counterMeatFish = (ap.counterMeatFishMax-ap.counterMeatFishMin);
//		ap.counterMilkCheese = ap.counterMilkCheeseValue;
//		ap.counterSweetSalty = ap.counterSweetSaltyValue;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			// Game scene actions
			if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
				// If we've lost (Energy drink), restart
				if (ap.gameOver) {
					ResetFoodCounters ();
					ap.totalWater = 0;
					ap.totalSport = 0;
					ap.isJumping = false;
					ap.gameOver = false;
					SceneManager.LoadScene ("scene"); // Regenerate Scene
				}
				// If time is up, go to Summary
				else if (ap.timerSlices == 0) {
					SceneManager.LoadScene ("summary_scene");
				}
			}
			// Boss Level actions
			else if (string.Equals (SceneManager.GetActiveScene ().name, "sceneBoss")) {
				// If we've beat the boss restart the game
				if (ap.bossFinished) {
					ResetFoodCounters ();
					// Rest of resets
					ap.totalWater = 0;
					ap.totalSport = 0;
					ap.isJumping = false;
					ap.gameOver = false;
					ap.level = 1;
					ap.bossFinished = false;

					SceneManager.LoadScene("splash_scene");
				}
				else if (ap.gameOver) {
					ResetFoodCounters ();
					// Rest of resets
					ap.totalWater = 0;
					ap.totalSport = 0;
					ap.isJumping = false;
					ap.gameOver = false;
					SceneManager.LoadScene ("sceneBoss"); // Regenerate Scene
				}
			}
		}
		/*
		if (Input.GetKeyDown (KeyCode.T)){
			ShareToTW ();
		}
		*/
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";
	public static string descriptionParam;

	public void ShareToTW()
	{
		if (ap.language == "en") {
			string text = ap.en_scoreHandler_twitterText1;//this is limited in text length 
			text += ap.en_scoreHandler_twitterText2;
			Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
		}
		else if(ap.language == "es") {
			string text = ap.es_scoreHandler_twitterText1;//this is limited in text length 
			text += ap.es_scoreHandler_twitterText2;
			Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
		}
		else if(ap.language == "de") {
			string text = ap.de_scoreHandler_twitterText1;//this is limited in text length 
			text += ap.de_scoreHandler_twitterText2;
			Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
		}
	}
}
