using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour {

	public GameObject character;
	public GameObject CaloriesObject;
	public Sprite[] sprites;
	public Text congratsObjectText;
	public Text congratsCaloriesObjectText;
	public Text shareTwitterObjectText;

	// Use this for initialization
	void Start () {
		if (ApplicationModel.language == "en") {
			congratsObjectText.text = ApplicationModel.en_scoreHandler_congratsObjectText;
			congratsCaloriesObjectText.text = ApplicationModel.en_scoreHandler_congratsCaloriesObjectText;
			shareTwitterObjectText.text = ApplicationModel.en_scoreHandler_shareTwitterObjectText;
		}
		else if(ApplicationModel.language == "es") {
			congratsObjectText.text = ApplicationModel.es_scoreHandler_congratsObjectText;
			congratsCaloriesObjectText.text = ApplicationModel.es_scoreHandler_congratsCaloriesObjectText;
			shareTwitterObjectText.text = ApplicationModel.es_scoreHandler_shareTwitterObjectText;
		}
		else if(ApplicationModel.language == "de") {
			congratsObjectText.text = ApplicationModel.de_scoreHandler_congratsObjectText;
			congratsCaloriesObjectText.text = ApplicationModel.de_scoreHandler_congratsCaloriesObjectText;
			shareTwitterObjectText.text = ApplicationModel.de_scoreHandler_shareTwitterObjectText;
		}

		character.GetComponent<SpriteRenderer> ().sprite = sprites[ApplicationModel.spriteNum];
		CaloriesObject.GetComponent < Text >().text = ApplicationModel.totalCalories.ToString();
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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)){
			ShareToTW ();
		}
	}
}
