using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelector : MonoBehaviour {

	public GameObject character;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		ApplicationModel.spriteNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)){
			if (ApplicationModel.spriteNum == 0) {
				ApplicationModel.spriteNum = sprites.Length-1;
			} else {
				ApplicationModel.spriteNum = ApplicationModel.spriteNum - 1;
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)){
			if (ApplicationModel.spriteNum == sprites.Length-1) {
				ApplicationModel.spriteNum = 0;
			} else {
				ApplicationModel.spriteNum = ApplicationModel.spriteNum + 1;
			}
		}

		character.GetComponent<SpriteRenderer> ().sprite = sprites[ApplicationModel.spriteNum];
	}
}
