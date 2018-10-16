using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelector : MonoBehaviour {

	public GameObject character;
	public GameObject genderArrows;
	public GameObject raceArrows;
	public GameObject seasonArrows;
	public GameObject seasonObject;
	public Sprite[] spritesBoys;
	public Sprite[] spritesGirls;
	public Sprite[] spritesSeason;
	public Sprite spriteArrows;
	public Sprite spriteActiveArrows;
	public int activeArrows;

	// Use this for initialization
	void Start () {
		ApplicationModel.level = 1;
		activeArrows = 0;
		ApplicationModel.spriteGender = 0;
		ApplicationModel.spriteNum = 0;
		ApplicationModel.season = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// UP-DOWN - Change selected arrows (pick genre or race)
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (activeArrows == 0) {activeArrows = 2;}
			else if (activeArrows == 1) {activeArrows = 0;}
			else if (activeArrows == 2) {activeArrows = 1;}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (activeArrows == 0) {activeArrows = 1;}
			else if (activeArrows == 1) {activeArrows = 2;}
			else if (activeArrows == 2) {activeArrows = 0;}
		}

		if (activeArrows == 0) {
			raceArrows.GetComponent<SpriteRenderer> ().sprite = spriteActiveArrows;
			genderArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
			seasonArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
		}
		else if (activeArrows == 1) {
			raceArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
			genderArrows.GetComponent<SpriteRenderer> ().sprite = spriteActiveArrows;
			seasonArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
		}
		else if (activeArrows == 2) {
			raceArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
			genderArrows.GetComponent<SpriteRenderer> ().sprite = spriteArrows;
			seasonArrows.GetComponent<SpriteRenderer> ().sprite = spriteActiveArrows;
		}

		// LEFT-RIGHT - Change genre or race
		if (Input.GetKeyDown (KeyCode.LeftArrow)){
			if (activeArrows == 0) { // Change race
				if (ApplicationModel.spriteGender == 0) { // if GIRL
					if (ApplicationModel.spriteNum == 0) {
						ApplicationModel.spriteNum = spritesGirls.Length - 1;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum - 1;
					}
				} else if (ApplicationModel.spriteGender == 1) { // if BOY
					if (ApplicationModel.spriteNum == 0) {
						ApplicationModel.spriteNum = spritesBoys.Length - 1;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum - 1;
					}
				}

			} else if (activeArrows == 1) { // Change genre
				if (ApplicationModel.spriteGender == 0) {
					ApplicationModel.spriteGender = 1;
				} else if (ApplicationModel.spriteGender == 1) {
					ApplicationModel.spriteGender = 0;
				}
			} else if (activeArrows == 2) { // Change season
				if(ApplicationModel.season == 0){
					ApplicationModel.season = 1;
				}
				else if(ApplicationModel.season == 1){
					ApplicationModel.season = 0;
				}
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)){
			if (activeArrows == 0) { // Change race
				if (ApplicationModel.spriteGender == 0) { // if GIRL
					if (ApplicationModel.spriteNum == spritesGirls.Length - 1) {
						ApplicationModel.spriteNum = 0;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum + 1;
					}
				} else if (ApplicationModel.spriteGender == 1) { // if BOY
					if (ApplicationModel.spriteNum == spritesBoys.Length - 1) {
						ApplicationModel.spriteNum = 0;
					} else {
						ApplicationModel.spriteNum = ApplicationModel.spriteNum + 1;
					}
				}

			} else if (activeArrows == 1) { // Change genre
				if (ApplicationModel.spriteGender == 0) {
					ApplicationModel.spriteGender = 1;
				} else if (ApplicationModel.spriteGender == 1) {
					ApplicationModel.spriteGender = 0;
				}
			} else if (activeArrows == 2) { // Change season
				if (ApplicationModel.season == 0) {
					ApplicationModel.season = 1;
				} else if (ApplicationModel.season == 1) {
					ApplicationModel.season = 0;
				}
			}
		}

		if (ApplicationModel.spriteGender == 0) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesGirls[ApplicationModel.spriteNum];
		}
		else if(ApplicationModel.spriteGender == 1) {
			character.GetComponent<SpriteRenderer> ().sprite = spritesBoys[ApplicationModel.spriteNum];
		}
			
		if (ApplicationModel.season == 0) {
			seasonObject.GetComponent<SpriteRenderer> ().sprite = spritesSeason[0];
		}
		else if(ApplicationModel.season == 1) {
			seasonObject.GetComponent<SpriteRenderer> ().sprite = spritesSeason[1];
		}
	}
}
