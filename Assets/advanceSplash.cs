using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class advanceSplash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)){
			if (string.Equals(SceneManager.GetActiveScene ().name,"splash_scene")) {
				SceneManager.LoadScene("tutorial_scene");
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"tutorial_scene")) {
				SceneManager.LoadScene("intro_scene");
			}
		}
	}
}
