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

		ApplicationModel.maxLevel = 4;

		// Info MSG
		if (ApplicationModel.language == "en") {
			infoMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_infoMsgText;
		} else if (ApplicationModel.language == "es") {
			infoMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_infoMsgText;
		} else if (ApplicationModel.language == "de") {
			infoMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_infoMsgText;
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
		checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [0];

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
		if (ApplicationModel.counterBreadPasta >= ApplicationModel.counterBreadPastaMin && ApplicationModel.counterBreadPasta <= ApplicationModel.counterBreadPastaMax &&
			ApplicationModel.counterFruitVeggies >= ApplicationModel.counterFruitVeggiesValue &&
			ApplicationModel.counterMeatFish >= ApplicationModel.counterMeatFishMin && ApplicationModel.counterMeatFish <= ApplicationModel.counterMeatFishMax &&
			ApplicationModel.counterMilkCheese >= ApplicationModel.counterMilkCheeseValue &&
			ApplicationModel.counterSweetSalty <= ApplicationModel.counterSweetSaltyValue) {
			isFoodOk = true;
		} else {
			isFoodOk = false;
		}

		// Change food icons
		if (ApplicationModel.counterBreadPasta >= ApplicationModel.counterBreadPastaMin && ApplicationModel.counterBreadPasta <= ApplicationModel.counterBreadPastaMax) {
			checkBreadPastaObject.GetComponent<SpriteRenderer> ().sprite = checkBreadPastaSprites [0];
		}
		if (ApplicationModel.counterFruitVeggies >= ApplicationModel.counterFruitVeggiesValue){
			checkFruitVeggiesObject.GetComponent<SpriteRenderer> ().sprite = checkFruitVeggiesSprites [0];
		}
		if (ApplicationModel.counterMeatFish >= ApplicationModel.counterMeatFishMin && ApplicationModel.counterMeatFish <= ApplicationModel.counterMeatFishMax){
			checkMeatFishObject.GetComponent<SpriteRenderer> ().sprite = checkMeatFishSprites [0];
		}
		if (ApplicationModel.counterMilkCheese >= ApplicationModel.counterMilkCheeseValue){
			checkMilkCheeseObject.GetComponent<SpriteRenderer> ().sprite = checkMilkCheeseSprites [0];
		}
		if (ApplicationModel.counterSweetSalty <= ApplicationModel.counterSweetSaltyValue){
			checkSweetSaltyObject.GetComponent<SpriteRenderer> ().sprite = checkSweetSaltySprites [0];
		}

		// Change food texts
		if (ApplicationModel.counterBreadPasta >= ApplicationModel.counterBreadPastaMin && ApplicationModel.counterBreadPasta <= ApplicationModel.counterBreadPastaMax) {
			if (ApplicationModel.language == "en") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_breadPastaMsgTextGood;
				checkBreadPastaMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterBreadPasta+" units, need between "+ApplicationModel.counterBreadPastaMin+" and "+ApplicationModel.counterBreadPastaMax+")";
				} else if (ApplicationModel.language == "es") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_breadPastaMsgTextGood;
			} else if (ApplicationModel.language == "de") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_breadPastaMsgTextGood;
			}
		} else {
			if (ApplicationModel.language == "en") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_breadPastaMsgTextBad;
				checkBreadPastaMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterBreadPasta+"units, need between "+ApplicationModel.counterBreadPastaMin+" and "+ApplicationModel.counterBreadPastaMax+")";
			} else if (ApplicationModel.language == "es") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_breadPastaMsgTextBad;
			} else if (ApplicationModel.language == "de") {
				checkBreadPastaMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_breadPastaMsgTextBad;
			}
		}

		if (ApplicationModel.counterFruitVeggies >= ApplicationModel.counterFruitVeggiesValue) {
			if (ApplicationModel.language == "en") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_fruitVeggiesMsgTextGood;
				checkFruitVeggiesMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterFruitVeggies+" units, need at least "+ApplicationModel.counterFruitVeggiesValue+")";
			} else if (ApplicationModel.language == "es") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_fruitVeggiesMsgTextGood;
			} else if (ApplicationModel.language == "de") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_fruitVeggiesMsgTextGood;
			}
		} else {
			if (ApplicationModel.language == "en") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_fruitVeggiesMsgTextBad;
				checkFruitVeggiesMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterFruitVeggies+" units, need at least "+ApplicationModel.counterFruitVeggiesValue+")";
			} else if (ApplicationModel.language == "es") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_fruitVeggiesMsgTextBad;
			} else if (ApplicationModel.language == "de") {
				checkFruitVeggiesMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_fruitVeggiesMsgTextBad;
			}
		}

		if (ApplicationModel.counterMeatFish >= ApplicationModel.counterMeatFishMin && ApplicationModel.counterMeatFish <= ApplicationModel.counterMeatFishMax){
			if (ApplicationModel.language == "en") {
				checkMeatFishMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_meatFishMsgTextGood;
				checkMeatFishMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterMeatFish+" units, need between "+ApplicationModel.counterMeatFishMin+" and "+ApplicationModel.counterMeatFishMax+")";
			} else if (ApplicationModel.language == "es") {
				checkMeatFishMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_meatFishMsgTextGood;
			} else if (ApplicationModel.language == "de") {
				checkMeatFishMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_meatFishMsgTextGood;
			}
		} else {
			if (ApplicationModel.language == "en") {
				checkMeatFishMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_meatFishMsgTextBad;
				checkMeatFishMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterMeatFish+" units, need between "+ApplicationModel.counterMeatFishMin+" and "+ApplicationModel.counterMeatFishMax+")";
			} else if (ApplicationModel.language == "es") {
				checkMeatFishMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_meatFishMsgTextBad;
			} else if (ApplicationModel.language == "de") {
				checkMeatFishMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_meatFishMsgTextBad;
			}
		}
		if (ApplicationModel.counterMilkCheese >= ApplicationModel.counterMilkCheeseValue){
			if (ApplicationModel.language == "en") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_milkCheeseMsgTextGood;
				checkMilkCheeseMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterMilkCheese+" units, need at least "+ApplicationModel.counterMilkCheeseValue+")";
			} else if (ApplicationModel.language == "es") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_milkCheeseMsgTextGood;
			} else if (ApplicationModel.language == "de") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_milkCheeseMsgTextGood;
			}
		} else {
			if (ApplicationModel.language == "en") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_milkCheeseMsgTextBad;
				checkMilkCheeseMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterMilkCheese+" units, need at least "+ApplicationModel.counterMilkCheeseValue+")";
			} else if (ApplicationModel.language == "es") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_milkCheeseMsgTextBad;
			} else if (ApplicationModel.language == "de") {
				checkMilkCheeseMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_milkCheeseMsgTextBad;
			}
		}
		if (ApplicationModel.counterSweetSalty <= ApplicationModel.counterSweetSaltyValue){
			if (ApplicationModel.language == "en") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_sweetSaltyMsgTextGood;
				checkSweetSaltyMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterSweetSalty+" units, need no more than "+ApplicationModel.counterSweetSaltyValue+")";
			} else if (ApplicationModel.language == "es") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_sweetSaltyMsgTextGood;
			} else if (ApplicationModel.language == "de") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_sweetSaltyMsgTextGood;
			}
		} else {
			if (ApplicationModel.language == "en") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ApplicationModel.en_summaryHandler_sweetSaltyMsgTextBad;
				checkSweetSaltyMsg.GetComponent<Text> ().text += " (Ate "+ApplicationModel.counterSweetSalty+" units, need no more than "+ApplicationModel.counterSweetSaltyValue+")";
			} else if (ApplicationModel.language == "es") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ApplicationModel.es_summaryHandler_sweetSaltyMsgTextBad;
			} else if (ApplicationModel.language == "de") {
				checkSweetSaltyMsg.GetComponent<Text> ().text = ApplicationModel.de_summaryHandler_sweetSaltyMsgTextBad;
			}
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

		if (ApplicationModel.levelCleared) {
				ApplicationModel.level++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)){
			Debug.Log ("N pressed");
			Debug.Log (ApplicationModel.level);
			Debug.Log (ApplicationModel.maxLevel);
			Debug.Log (ApplicationModel.levelCleared);

			if(ApplicationModel.level <= ApplicationModel.maxLevel){
					// Reset stuff
					ApplicationModel.counterBreadPasta = 0;
					ApplicationModel.counterFruitVeggies = 0;
					ApplicationModel.counterMeatFish = 0;
					ApplicationModel.counterMilkCheese = 0;
					ApplicationModel.counterSweetSalty = 0;
					ApplicationModel.totalWater = 0;
					ApplicationModel.totalSport = 0;
					ApplicationModel.isJumping = false;
					ApplicationModel.gameOver = false;

					// Change scene to gameplay
					SceneManager.LoadScene("scene"); // Regenerate Scene
			}
			// After 4 levels the game is finished
			else {
				// Change scene to game's end
				SceneManager.LoadScene("final_scene");
			}
		}
	}
}
