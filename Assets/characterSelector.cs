using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelector : MonoBehaviour {

	public GameObject character;
	public GameObject genderArrows;
	public GameObject raceArrows;
	public Sprite[] spritesBoys;
	public Sprite[] spritesGirls;
	public Sprite spriteArrows;
	public Sprite spriteActiveArrows;
	public int activeArrows;

	// Use this for initialization
	void Start () {
		activeArrows = 0;
		ApplicationModel.spriteGender = 0;
		ApplicationModel.spriteNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// UP-DOWN - Change selected arrows (pick genre or race)
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
			if (activeArrows == 0) {activeArrows = 1;}
			else {activeArrows = 0;}
		}

		if (activeArrows == 0) {
			raceArrows.GetComponent<SpriteRenderer> ().sprite = spriteActiveArrows;
			genderArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
		}
		else if (activeArrows == 1) {
			genderArrows.GetComponent<SpriteRenderer> ().sprite = spriteActiveArrows;
			raceArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
		}

		// LEFT-RIGHT - Change genre or race
		if (Input.GetKeyDown (KeyCode.LeftArrow)){
			if (activeArrows == 0) { // Change race
				if (ApplicationModel.spriteGender == 0) { // if GIRL
					if (ApplicationModel.spriteNum == 0) {
						ApplicationModel.spriteNum = spritesGirls.Length-1;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum - 1;
					}
				} else if (ApplicationModel.spriteGender == 1){ // if BOY
					if (ApplicationModel.spriteNum == 0) {
						ApplicationModel.spriteNum = spritesBoys.Length-1;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum - 1;
					}
				}

			}
			else if (activeArrows == 1) { // Change genre
				if(ApplicationModel.spriteGender == 0){ApplicationModel.spriteGender = 1;}
				else if(ApplicationModel.spriteGender == 1){ApplicationModel.spriteGender = 0;}
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)){
			if (activeArrows == 0) { // Change race
				if (ApplicationModel.spriteGender == 0) { // if GIRL
					if (ApplicationModel.spriteNum == spritesGirls.Length-1) {
						ApplicationModel.spriteNum = 0;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum + 1;
					}
				} else if (ApplicationModel.spriteGender == 1){ // if BOY
					if (ApplicationModel.spriteNum == spritesBoys.Length-1) {
						ApplicationModel.spriteNum = 0;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum + 1;
					}
				}

			}
			else if (activeArrows == 1) { // Change genre
				if(ApplicationModel.spriteGender == 0){ApplicationModel.spriteGender = 1;}
				else if(ApplicationModel.spriteGender == 1){ApplicationModel.spriteGender = 0;}
			}
		}

		if (ApplicationModel.spriteGender == 0) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesGirls[ApplicationModel.spriteNum];
		}
		else if(ApplicationModel.spriteGender == 1) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesBoys[ApplicationModel.spriteNum];
		}
			

	}
}
