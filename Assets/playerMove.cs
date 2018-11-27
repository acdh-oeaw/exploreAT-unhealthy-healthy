using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class playerMove : MonoBehaviour {

	public float speed; 
	float x; 
	Vector2 move; 

	bool movesBlocked;

	Rigidbody2D rb;

	public AudioClip soundJump, soundGood, soundBad, soundBg;
	public AudioSource audioSource;
	public AudioSource audioSourceBg;

	public GameObject pausePanel;

	// Use this for initialization
	void Start () {
		rb = GetComponent < Rigidbody2D > (); 
		movesBlocked = false;
		ap.paused = false;
		pausePanel.SetActive(false);

		if (ap.language == "en") {
			pausePanel.GetComponent < Text > ().text = ap.en_scene_pauseText;
		}
		else if (ap.language == "es") {
			pausePanel.GetComponent < Text > ().text = ap.es_scene_pauseText;
		}
		else if (ap.language == "de") {
			pausePanel.GetComponent < Text > ().text = ap.de_scene_pauseText;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!movesBlocked){
			x = Input.GetAxis ("Horizontal"); 
			move = new Vector2 (x * speed, rb.velocity.y); 
			rb.velocity = move;

			if ((Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) &&
				!ap.isJumping) {  //makes player jump
				audioSource.PlayOneShot(soundJump, 1.0f);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,60), ForceMode2D.Impulse);
				ap.isJumping = true;
			}
		}

		if (GetComponent<Rigidbody2D>().velocity.y <= 0.1 &&
			GetComponent<Rigidbody2D>().velocity.y >= -0.1) {
			ap.isJumping = false;
		}

		if (string.Equals(SceneManager.GetActiveScene ().name,"scene") ||
			string.Equals(SceneManager.GetActiveScene ().name,"sceneBoss")) {
			if (Input.GetKeyDown (KeyCode.P)) {
				if (!ap.paused) 
				{
					PauseGame();
				}
				else {
					ContinueGame ();   
				}
			}
		}
	}

	private void PauseGame()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		ap.paused = true;
		//Disable scripts that still work while timescale is set to 0
	} 
	private void ContinueGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		ap.paused = false;
		//enable the scripts again
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
		if (ap.gameOver) {
			audioSource.PlayOneShot(soundBad, 1.0f);
			movesBlocked = true;
		}
	}

	void HandleBossCollision(){
		audioSource.PlayOneShot(soundBad, 1.0f);
	}

	void HandleTimeup(){
		audioSource.PlayOneShot (soundBad, 1.0f);
	}

	//

	void fixedUpdate() {
	
	}
}
