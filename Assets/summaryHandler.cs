using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class summaryHandler : MonoBehaviour {

	public GameObject character;
	public Sprite[] spritesBoys;
	public Sprite[] spritesGirls;
	public GameObject waterBar;
	public Sprite[] spritesWaterBar;
	public Text waterMsg;
	public GameObject sportBar;
	public Sprite[] spritesSportBar;
	public Text sportMsg;

	public GameObject successMsg;

	// Use this for initialization
	void Start () {

		successMsg.SetActive (false);

		bool isWaterOk = false;
		bool isSportOk = false;
		bool isFoodOk = false;

		if (ApplicationModel.language == null)
			ApplicationModel.language = "en";

		// Change avatar
		if (ApplicationModel.spriteGender == 0) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesGirls [ApplicationModel.spriteNum];
		} else if (ApplicationModel.spriteGender == 1) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesBoys [ApplicationModel.spriteNum];
		}

		// Check water
		waterBar.GetComponent<SpriteRenderer> ().sprite = spritesWaterBar [ApplicationModel.totalWater];
		if (ApplicationModel.totalWater == 6) {
			isWaterOk = true;
			if (ApplicationModel.language == "en") {
				waterMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_waterGoodMsgText;
			} else if (ApplicationModel.language == "es") {
				waterMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_waterGoodMsgText;
			} else if (ApplicationModel.language == "de") {
				waterMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_waterGoodMsgText;
			}
		} else {
			isWaterOk = false;
			if (ApplicationModel.language == "en") {
				waterMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_waterBadMsgText;
			} else if (ApplicationModel.language == "es") {
				waterMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_waterBadMsgText;
			} else if (ApplicationModel.language == "de") {
				waterMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_waterBadMsgText;
			}
		}

		// Check sports
		sportBar.GetComponent<SpriteRenderer> ().sprite = spritesSportBar [ApplicationModel.totalSport];
		if (ApplicationModel.totalSport == 7) {
			isSportOk = true;
			if (ApplicationModel.language == "en") {
				sportMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_sportGoodMsgText;
			} else if (ApplicationModel.language == "es") {
				sportMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_sportGoodMsgText;
			} else if (ApplicationModel.language == "de") {
				sportMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_sportGoodMsgText;
			}
		} else {
			isSportOk = false;
			if (ApplicationModel.language == "en") {
				sportMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_sportBadMsgText;
			} else if (ApplicationModel.language == "es") {
				sportMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_sportBadMsgText;
			} else if (ApplicationModel.language == "de") {
				sportMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_sportBadMsgText;
			}
		}

		// Check foods
		if (ApplicationModel.counterBreadPasta >= 28 && ApplicationModel.counterBreadPasta <= 35 &&
		    ApplicationModel.counterFruitVeggies >= 35 &&
			ApplicationModel.counterMeatFish >= 8 && ApplicationModel.counterMeatFish <= 11 &&
		    ApplicationModel.counterMilkCheese >= 21 &&
		    ApplicationModel.counterSweetSalty <= 7) {
			isFoodOk = true;
		} else {
			isFoodOk = false;
		}

		// Update global levelCleared var
		if (isWaterOk && isSportOk && isFoodOk) {
			ApplicationModel.levelCleared = true;
		} else {
			ApplicationModel.levelCleared = false;
		}

		// Check if level was cleared and inform the user
		if (ApplicationModel.levelCleared) {
			if (ApplicationModel.language == "en") {
				successMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_successGoodMsgText;
			} else if (ApplicationModel.language == "es") {
				successMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_successGoodMsgText;
			} else if (ApplicationModel.language == "de") {
				successMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_successGoodMsgText;
			}
		} else {
			if (ApplicationModel.language == "en") {
				successMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_successBadMsgText;
			} else if (ApplicationModel.language == "es") {
				successMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_successBadMsgText;
			} else if (ApplicationModel.language == "de") {
				successMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_successBadMsgText;
			}
		}

		successMsg.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)){
			if (ApplicationModel.levelCleared) {
				if (ApplicationModel.level < 2) {
					ApplicationModel.level++;
				}
			}

			// Reset counters
			ApplicationModel.counterBreadPasta = 0;
			ApplicationModel.counterFruitVeggies = 0;
			ApplicationModel.counterMeatFish = 0;
			ApplicationModel.counterMilkCheese = 0;
			ApplicationModel.counterSweetSalty = 0;

			// Change scene
			SceneManager.LoadScene("scene"); // Regenate Scene
		}
	}
}
