using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerInitializer : MonoBehaviour {

	public GameObject GameOverObject; 
	Text gameOverText;
	public GameObject character;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		gameOverText = GameOverObject.GetComponent < Text >();
		Color zm = gameOverText.color;  //  makes a new color zm
		zm.a = 0.0f; // makes the color zm transparent
		character.GetComponent<SpriteRenderer> ().sprite = sprites[ApplicationModel.spriteNum];
		Vector2 S = character.GetComponent<SpriteRenderer>().sprite.bounds.size;
		character.GetComponent<BoxCollider2D>().size = S;
		character.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)){
			Time.timeScale = 1f;
			ApplicationModel.totalScore = 0;
			SceneManager.LoadScene("scene"); // Restart back to Level 1
		}
		if (Input.GetKeyDown (KeyCode.N)){
			if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
				SceneManager.LoadScene("scene2"); // Move to Level 2
			} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene2")) {
				SceneManager.LoadScene("scene3"); // Move to Level 3
			}
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
		string text = "I've just played the game consuming ";//this is limited in text length 
		text += ApplicationModel.totalScore;
		text += " calories !!! #VeggieGame #ExploreAT!";
		Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
	}
}
