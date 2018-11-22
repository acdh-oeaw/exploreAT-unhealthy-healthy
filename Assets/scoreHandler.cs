using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ap = ApplicationModel;

public class scoreHandler : MonoBehaviour {

	public GameObject character;
	public GameObject CaloriesObject;
	public Sprite[] sprites;
	public Text congratsObjectText;
	public Text congratsCaloriesObjectText;
	public Text shareTwitterObjectText;

	// Use this for initialization
	void Start () {
		if (ap.language == "en") {
			congratsObjectText.text = ap.en_scoreHandler_congratsObjectText;
			congratsCaloriesObjectText.text = ap.en_scoreHandler_congratsCaloriesObjectText;
			shareTwitterObjectText.text = ap.en_scoreHandler_shareTwitterObjectText;
		}
		else if(ap.language == "es") {
			congratsObjectText.text = ap.es_scoreHandler_congratsObjectText;
			congratsCaloriesObjectText.text = ap.es_scoreHandler_congratsCaloriesObjectText;
			shareTwitterObjectText.text = ap.es_scoreHandler_shareTwitterObjectText;
		}
		else if(ap.language == "de") {
			congratsObjectText.text = ap.de_scoreHandler_congratsObjectText;
			congratsCaloriesObjectText.text = ap.de_scoreHandler_congratsCaloriesObjectText;
			shareTwitterObjectText.text = ap.de_scoreHandler_shareTwitterObjectText;
		}

		character.GetComponent<SpriteRenderer> ().sprite = sprites[ap.spriteNum];
		CaloriesObject.GetComponent < Text >().text = ap.totalCalories.ToString();
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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)){
			ShareToTW ();
		}
	}
}
