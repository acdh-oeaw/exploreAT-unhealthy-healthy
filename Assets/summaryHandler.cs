using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

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

	public GameObject checkBreadPastaObject;
	public GameObject checkFruitVeggiesObject;
	public GameObject checkMeatFishObject;
	public GameObject checkMilkCheeseObject;
	public GameObject checkSweetSaltyObject;
	public Sprite[] checkBreadPastaSprites;
	public Sprite[] checkFruitVeggiesSprites;
	public Sprite[] checkMeatFishSprites;
	public Sprite[] checkMilkCheeseSprites;
	public Sprite[] checkSweetSaltySprites;
	public Text checkBreadPastaMsg;
	public Text checkFruitVeggiesMsg;
	public Text checkMeatFishMsg;
	public Text checkMilkCheeseMsg;
	public Text checkSweetSaltyMsg;

	public GameObject successMsg;
	public GameObject infoMsg;

	// Use this for initialization
	void Start () {

		ap.maxLevel = 4;

		// Info MSG
		if (ap.language == "en") {
			infoMsg.GetComponent<Text> ().text = ap.en_summaryHandler_infoMsgText;
		} else if (ap.language == "es") {
			infoMsg.GetComponent<Text> ().text = ap.es_summaryHandler_infoMsgText;
		} else if (ap.language == "de") {
			infoMsg.GetComponent<Text> ().text = ap.de_summaryHandler_infoMsgText;
		}

		// Reset stuff
		successMsg.SetActive (false);
		infoMsg.SetActive (true);

		bool isWaterOk = false;
		bool isSportOk = false;
		bool isFoodOk = false;

		checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [1];
		checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [1];
		checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [1];
		checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [1];
		checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [1];

		if (ap.language == null)
			ap.language = "en";

		// Change avatar
		if (ap.spriteGender == 0) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesGirls [ap.spriteNum];
		} else if (ap.spriteGender == 1) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesBoys [ap.spriteNum];
		}

		// Check water
		waterBar.GetComponent<SpriteRenderer> ().sprite = spritesWaterBar [ap.totalWater];
		if (ap.totalWater == 6) {
			isWaterOk = true;
			if (ap.language == "en") {
				waterMsg.GetComponent<Text> ().text = ap.en_summaryHandler_waterGoodMsgText;
			} else if (ap.language == "es") {
				waterMsg.GetComponent<Text> ().text = ap.es_summaryHandler_waterGoodMsgText;
			} else if (ap.language == "de") {
				waterMsg.GetComponent<Text> ().text = ap.de_summaryHandler_waterGoodMsgText;
			}
		} else {
			isWaterOk = false;
			if (ap.language == "en") {
				waterMsg.GetComponent<Text> ().text = ap.en_summaryHandler_waterBadMsgText;
			} else if (ap.language == "es") {
				waterMsg.GetComponent<Text> ().text = ap.es_summaryHandler_waterBadMsgText;
			} else if (ap.language == "de") {
				waterMsg.GetComponent<Text> ().text = ap.de_summaryHandler_waterBadMsgText;
			}
		}

		// Check sports
		sportBar.GetComponent<SpriteRenderer> ().sprite = spritesSportBar [ap.totalSport];
		if (ap.totalSport == 7) {
			isSportOk = true;
			if (ap.language == "en") {
				sportMsg.GetComponent<Text> ().text = ap.en_summaryHandler_sportGoodMsgText;
			} else if (ap.language == "es") {
				sportMsg.GetComponent<Text> ().text = ap.es_summaryHandler_sportGoodMsgText;
			} else if (ap.language == "de") {
				sportMsg.GetComponent<Text> ().text = ap.de_summaryHandler_sportGoodMsgText;
			}
		} else {
			isSportOk = false;
			if (ap.language == "en") {
				sportMsg.GetComponent<Text> ().text = ap.en_summaryHandler_sportBadMsgText;
			} else if (ap.language == "es") {
				sportMsg.GetComponent<Text> ().text = ap.es_summaryHandler_sportBadMsgText;
			} else if (ap.language == "de") {
				sportMsg.GetComponent<Text> ().text = ap.de_summaryHandler_sportBadMsgText;
			}
		}

		// Check foods
		if (ap.counterBreadPasta >= ap.counterBreadPastaMin && ap.counterBreadPasta <= ap.counterBreadPastaMax &&
			ap.counterFruitVeggies >= ap.counterFruitVeggiesValue &&
			ap.counterMeatFish >= ap.counterMeatFishMin && ap.counterMeatFish <= ap.counterMeatFishMax &&
			ap.counterMilkCheese >= ap.counterMilkCheeseValue &&
			ap.counterSweetSalty <= ap.counterSweetSaltyValue) {
			isFoodOk = true;
		} else {
			isFoodOk = false;
		}

		// Change food icons
		if (ap.counterBreadPasta >= ap.counterBreadPastaMin && ap.counterBreadPasta <= ap.counterBreadPastaMax) {
			checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [0];
		}
		if (ap.counterFruitVeggies >= ap.counterFruitVeggiesValue){
			checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [0];
		}
		if (ap.counterMeatFish >= ap.counterMeatFishMin && ap.counterMeatFish <= ap.counterMeatFishMax){
			checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [0];
		}
		if (ap.counterMilkCheese >= ap.counterMilkCheeseValue){
			checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [0];
		}
		if (ap.counterSweetSalty <= ap.counterSweetSaltyValue){
			checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [0];
		}

		// Change food texts
		if (ap.counterBreadPasta >= ap.counterBreadPastaMin && ap.counterBreadPasta <= ap.counterBreadPastaMax) {
			if (ap.language == "en") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ap.en_summaryHandler_breadPastaMsgTextGood;
				checkBreadPastaMsg.GetComponent<Text> ().text += " (Ate "+ap.counterBreadPasta+" units, need between "+ap.counterBreadPastaMin+" and "+ap.counterBreadPastaMax+")";
				} else if (ap.language == "es") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ap.es_summaryHandler_breadPastaMsgTextGood;
			} else if (ap.language == "de") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ap.de_summaryHandler_breadPastaMsgTextGood;
			}
		} else {
			if (ap.language == "en") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ap.en_summaryHandler_breadPastaMsgTextBad;
				checkBreadPastaMsg.GetComponent<Text> ().text += " (Ate "+ap.counterBreadPasta+" units, need between "+ap.counterBreadPastaMin+" and "+ap.counterBreadPastaMax+")";
			} else if (ap.language == "es") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ap.es_summaryHandler_breadPastaMsgTextBad;
			} else if (ap.language == "de") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ap.de_summaryHandler_breadPastaMsgTextBad;
			}
		}

		if (ap.counterFruitVeggies >= ap.counterFruitVeggiesValue) {
			if (ap.language == "en") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ap.en_summaryHandler_fruitVeggiesMsgTextGood;
				checkFruitVeggiesMsg.GetComponent<Text> ().text += " (Ate "+ap.counterFruitVeggies+" units, need at least "+ap.counterFruitVeggiesValue+")";
			} else if (ap.language == "es") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ap.es_summaryHandler_fruitVeggiesMsgTextGood;
			} else if (ap.language == "de") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ap.de_summaryHandler_fruitVeggiesMsgTextGood;
			}
		} else {
			if (ap.language == "en") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ap.en_summaryHandler_fruitVeggiesMsgTextBad;
				checkFruitVeggiesMsg.GetComponent<Text> ().text += " (Ate "+ap.counterFruitVeggies+" units, need at least "+ap.counterFruitVeggiesValue+")";
			} else if (ap.language == "es") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ap.es_summaryHandler_fruitVeggiesMsgTextBad;
			} else if (ap.language == "de") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ap.de_summaryHandler_fruitVeggiesMsgTextBad;
			}
		}

		if (ap.counterMeatFish >= ap.counterMeatFishMin && ap.counterMeatFish <= ap.counterMeatFishMax){
			if (ap.language == "en") {
				checkMeatFishMsg.GetComponent<Text> ().text = ap.en_summaryHandler_meatFishMsgTextGood;
				checkMeatFishMsg.GetComponent<Text> ().text += " (Ate "+ap.counterMeatFish+" units, need between "+ap.counterMeatFishMin+" and "+ap.counterMeatFishMax+")";
			} else if (ap.language == "es") {
				checkMeatFishMsg.GetComponent<Text> ().text = ap.es_summaryHandler_meatFishMsgTextGood;
			} else if (ap.language == "de") {
				checkMeatFishMsg.GetComponent<Text> ().text = ap.de_summaryHandler_meatFishMsgTextGood;
			}
		} else {
			if (ap.language == "en") {
				checkMeatFishMsg.GetComponent<Text> ().text = ap.en_summaryHandler_meatFishMsgTextBad;
				checkMeatFishMsg.GetComponent<Text> ().text += " (Ate "+ap.counterMeatFish+" units, need between "+ap.counterMeatFishMin+" and "+ap.counterMeatFishMax+")";
			} else if (ap.language == "es") {
				checkMeatFishMsg.GetComponent<Text> ().text = ap.es_summaryHandler_meatFishMsgTextBad;
			} else if (ap.language == "de") {
				checkMeatFishMsg.GetComponent<Text> ().text = ap.de_summaryHandler_meatFishMsgTextBad;
			}
		}
		if (ap.counterMilkCheese >= ap.counterMilkCheeseValue){
			if (ap.language == "en") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ap.en_summaryHandler_milkCheeseMsgTextGood;
				checkMilkCheeseMsg.GetComponent<Text> ().text += " (Ate "+ap.counterMilkCheese+" units, need at least "+ap.counterMilkCheeseValue+")";
			} else if (ap.language == "es") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ap.es_summaryHandler_milkCheeseMsgTextGood;
			} else if (ap.language == "de") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ap.de_summaryHandler_milkCheeseMsgTextGood;
			}
		} else {
			if (ap.language == "en") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ap.en_summaryHandler_milkCheeseMsgTextBad;
				checkMilkCheeseMsg.GetComponent<Text> ().text += " (Ate "+ap.counterMilkCheese+" units, need at least "+ap.counterMilkCheeseValue+")";
			} else if (ap.language == "es") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ap.es_summaryHandler_milkCheeseMsgTextBad;
			} else if (ap.language == "de") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ap.de_summaryHandler_milkCheeseMsgTextBad;
			}
		}
		if (ap.counterSweetSalty <= ap.counterSweetSaltyValue){
			if (ap.language == "en") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ap.en_summaryHandler_sweetSaltyMsgTextGood;
				checkSweetSaltyMsg.GetComponent<Text> ().text += " (Ate "+ap.counterSweetSalty+" units, need no more than "+ap.counterSweetSaltyValue+")";
			} else if (ap.language == "es") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ap.es_summaryHandler_sweetSaltyMsgTextGood;
			} else if (ap.language == "de") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ap.de_summaryHandler_sweetSaltyMsgTextGood;
			}
		} else {
			if (ap.language == "en") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ap.en_summaryHandler_sweetSaltyMsgTextBad;
				checkSweetSaltyMsg.GetComponent<Text> ().text += " (Ate "+ap.counterSweetSalty+" units, need no more than "+ap.counterSweetSaltyValue+")";
			} else if (ap.language == "es") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ap.es_summaryHandler_sweetSaltyMsgTextBad;
			} else if (ap.language == "de") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ap.de_summaryHandler_sweetSaltyMsgTextBad;
			}
		}

		// Update global levelCleared var
		if (isWaterOk && isSportOk && isFoodOk) {
			ap.levelCleared = true;
		} else {
			ap.levelCleared = false;
		}

		// Check if level was cleared and inform the user
		if (ap.levelCleared) {
			if (ap.language == "en") {
				successMsg.GetComponent<Text> ().text = ap.en_summaryHandler_successGoodMsgText;
			} else if (ap.language == "es") {
				successMsg.GetComponent<Text> ().text = ap.es_summaryHandler_successGoodMsgText;
			} else if (ap.language == "de") {
				successMsg.GetComponent<Text> ().text = ap.de_summaryHandler_successGoodMsgText;
			}
		} else {
			if (ap.language == "en") {
				successMsg.GetComponent<Text> ().text = ap.en_summaryHandler_successBadMsgText;
			} else if (ap.language == "es") {
				successMsg.GetComponent<Text> ().text = ap.es_summaryHandler_successBadMsgText;
			} else if (ap.language == "de") {
				successMsg.GetComponent<Text> ().text = ap.de_summaryHandler_successBadMsgText;
			}
		}

		successMsg.SetActive (true);

		if (ap.levelCleared) {
				ap.level++;
		}

		if (ap.level > ap.maxLevel) {
			if (ap.language == "en") {
				successMsg.GetComponent<Text> ().text = ap.en_summaryHandler_gameEndMsgText;
			} else if (ap.language == "es") {
				successMsg.GetComponent<Text> ().text = ap.es_summaryHandler_gameEndMsgText;
			} else if (ap.language == "de") {
				successMsg.GetComponent<Text> ().text = ap.de_summaryHandler_gameEndMsgText;
			}
		}
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
		if (Input.GetKeyDown (KeyCode.N)){

			if(ap.level <= ap.maxLevel){
				ResetFoodCounters ();
				// Rest of resets
				ap.totalWater = 0;
				ap.totalSport = 0;
				ap.isJumping = false;
				ap.gameOver = false;

				// Change scene to gameplay
				SceneManager.LoadScene("scene"); // Regenerate Scene
			}
			// After "maxLevel" levels we go to the boss
			else if(ap.level == ap.maxLevel+1){
				ResetFoodCounters ();
				// Rest of resets
				ap.totalWater = 0;
				ap.totalSport = 0;
				ap.isJumping = false;
				ap.gameOver = false;
				ap.level = 1;

				SceneManager.LoadScene("sceneBoss"); // Go to Boss Scene
			}
		}
	}
}
