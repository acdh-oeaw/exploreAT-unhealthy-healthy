using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public float speed; 
	float x; 
	Vector2 move; 

	bool movesBlocked;

	Rigidbody2D rb;

	public AudioClip soundJump, soundGood, soundBad, soundBg;
	public AudioSource audioSource;
	public AudioSource audioSourceBg;

	// Use this for initialization
	void Start () {
		rb = GetComponent < Rigidbody2D > (); 
		movesBlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!movesBlocked){
			x = Input.GetAxis ("Horizontal"); 
			move = new Vector2 (x * speed, rb.velocity.y); 
			rb.velocity = move;

			if ((Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) &&
				!ApplicationModel.isJumping) {  //makes player jump
				audioSource.PlayOneShot(soundJump, 1.0f);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
				ApplicationModel.isJumping = true;
			}
		}

		if (GetComponent<Rigidbody2D>().velocity.y <= 0.1 &&
			GetComponent<Rigidbody2D>().velocity.y >= -0.1) {
			ApplicationModel.isJumping = false;
		}
	}

	void handleGameOver(){
		movesBlocked = true;
	}

	void HandleGoodItemCollision(){
		audioSource.PlayOneShot (soundGood, 1.0f);
	}

	//

	void HandleBicycleItemCollision(){
		audioSource.PlayOneShot (soundGood, 1.0f);
	}

	void HandleWaterItemCollision(){
		audioSource.PlayOneShot (soundGood, 1.0f);
	}

	void HandleEnergyDrinkItemCollision(){
		if (ApplicationModel.gameOver) {
			audioSource.PlayOneShot(soundBad, 1.0f);
			movesBlocked = true;
		}
	}

	void HandleTimeup(){
		audioSource.PlayOneShot (soundBad, 1.0f);
	}

	//

	void fixedUpdate() {
	
	}
}
