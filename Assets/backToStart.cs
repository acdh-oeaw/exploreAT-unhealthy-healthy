using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class backToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {

			ResetFoodCounters ();
			// Rest of resets
			ap.totalWater = 0;
			ap.totalSport = 0;
			ap.isJumping = false;
			ap.gameOver = false;
			ap.bossFinished = false;
			ap.bossPoints = 0;
			ap.level = 1;

			SceneManager.LoadScene ("splash_scene");
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			SceneManager.LoadScene ("sceneBoss");
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
}
