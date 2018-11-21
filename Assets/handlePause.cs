using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlePause : MonoBehaviour {

	public GameObject pausePanel;

	// Use this for initialization
	void Start () {
		ApplicationModel.paused = false;
		pausePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Debug.Log ("PREALSDKFJASKD FASKDJF KASDJF KASDJFKADSJFKASDJFKA SDJFKA SDJFKASD FASDF");
			if (!ApplicationModel.paused) 
			{
				Debug.Log ("pause");
				PauseGame();
			}
			else {
				Debug.Log ("continue");
				ContinueGame ();   
			}
		}
	}

	private void PauseGame()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		ApplicationModel.paused = true;
		//Disable scripts that still work while timescale is set to 0
	} 
	private void ContinueGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		ApplicationModel.paused = false;
		//enable the scripts again
	}
}
