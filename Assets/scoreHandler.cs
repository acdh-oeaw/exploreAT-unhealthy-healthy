using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour {

	public GameObject character;
	public GameObject CaloriesObject;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		character.GetComponent<SpriteRenderer> ().sprite = sprites[ApplicationModel.spriteNum];
		CaloriesObject.GetComponent < Text >().text = ApplicationModel.totalCalories.ToString();
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";
	public static string descriptionParam;

	public void ShareToTW()
	{
		string text = "I've just beaten the game consuming ";//this is limited in text length 
		text += ApplicationModel.totalScore;
		text += " calories !!! #VeggieGame #ExploreAT!";
		Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)){
			ShareToTW ();
		}
	}
}
