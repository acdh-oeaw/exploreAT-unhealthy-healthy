using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerInitializer : MonoBehaviour {

	public GameObject GameOverObject; 
	Text gameOverText;
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
		ApplicationModel.timerSlices = 7;

		gameOverText = GameOverObject.GetComponent < Text >();
		Color zm = gameOverText.color;  //  makes a new color zm
		zm.a = 0.0f; // makes the color zm transparent
		if(ApplicationModel.spriteGender == 0){
			character.GetComponent<SpriteRenderer> ().sprite = spritesGirls[ApplicationModel.spriteNum];
		}
		else if(ApplicationModel.spriteGender == 1){
			character.GetComponent<SpriteRenderer> ().sprite = spritesBoys[ApplicationModel.spriteNum];
		}
		Vector2 S = character.GetComponent<SpriteRenderer>().sprite.bounds.size;
		character.GetComponent<BoxCollider2D>().size = S;
		character.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);

		// Change sky colour, season background and season ground
		if (ApplicationModel.season == 0) {
			Camera.main.GetComponent<Camera>().backgroundColor = new Color(100f/255f,200f/255f,250f/255f,0f);
			ground.GetComponent<SpriteRenderer> ().sprite = spritesGround[0];
			seasonBackground.GetComponent<SpriteRenderer> ().sprite = spritesBackground[0];
		}
		else if (ApplicationModel.season == 1) {
			Camera.main.GetComponent<Camera>().backgroundColor = new Color(185f/255f,215f/255f,230f/255f,0f);
			ground.GetComponent<SpriteRenderer> ().sprite = spritesGround[1];
			seasonBackground.GetComponent<SpriteRenderer> ().sprite = spritesBackground[1];
		}

		seasonBackground.transform.SetAsFirstSibling ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)){
			if (ApplicationModel.gameOver) {
				ApplicationModel.counterBreadPasta = 0;
				ApplicationModel.counterFruitVeggies = 0;
				ApplicationModel.counterMeatFish = 0;
				ApplicationModel.counterMilkCheese = 0;
				ApplicationModel.counterSweetSalty = 0;
				ApplicationModel.totalWater = 0;
				ApplicationModel.totalSport = 0;
				ApplicationModel.isJumping = false;
				ApplicationModel.gameOver = false;
				SceneManager.LoadScene("scene"); // Regenate Scene
			}
			else {
				SceneManager.LoadScene("summary_scene"); // Regenate Scene
			}
		}
		if (Input.GetKeyDown (KeyCode.N)){
			if (ApplicationModel.levelCleared) {
				if (ApplicationModel.level < 2) {
					ApplicationModel.level++;
				}
			}
			SceneManager.LoadScene("scene"); // Regenate Scene
		}
		if (Input.GetKeyDown (KeyCode.T)){
			ShareToTW ();
		}
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";
	public static string descriptionParam;

	public void ShareToTW()
	{
		if (ApplicationModel.language == "en") {
			string text = ApplicationModel.en_scoreHandler_twitterText1;//this is limited in text length 
			text += ApplicationModel.en_scoreHandler_twitterText2;
			Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
		}
		else if(ApplicationModel.language == "es") {
			string text = ApplicationModel.es_scoreHandler_twitterText1;//this is limited in text length 
			text += ApplicationModel.es_scoreHandler_twitterText2;
			Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
		}
		else if(ApplicationModel.language == "de") {
			string text = ApplicationModel.de_scoreHandler_twitterText1;//this is limited in text length 
			text += ApplicationModel.de_scoreHandler_twitterText2;
			Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
		}
	}
}
