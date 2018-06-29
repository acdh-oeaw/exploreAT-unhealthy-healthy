using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public float speed; 
	float x; 
	Vector2 move; 

	bool movesBlocked;

	Rigidbody2D rb;

	public AudioClip soundJump, soundGood, soundBad, soundBg, soundStar;
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

			if ((Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) &&
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

	void HandleBadItemCollision(float lives){

		//audioSource.PlayOneShot(soundBad, 1.0f);

		if (!movesBlocked) {
			transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
			audioSource.PlayOneShot(soundBad, 1.0f);
		}

		if (lives == 0) {
			movesBlocked = true;
		}
	}

	void HandleGoodItemCollision(float score){

		if (score >= 30) { //nextLevelScore == 30 BUT SHOULD BE HANDLED IN ItemChecker.cs !!!
			movesBlocked = true;
		}
		if(score <= 30){
			audioSource.PlayOneShot (soundGood, 1.0f);
		}
	}

	void HandleStarItemCollision(bool removePower){

		if (!removePower) {
			audioSource.PlayOneShot (soundStar, 1.0f);
			audioSourceBg.Stop ();
		} else {
			audioSourceBg.Play ();
		}	

	}

	void fixedUpdate() {
	
	}
}
