using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {

	static public int spriteNum;
	static public int lives;
	static public int totalScore;
	static public float totalTime;
	static public int totalCalories;

	// Use this for initialization
	void Start () {
		spriteNum = 0;
		lives = 3;
		totalScore = 0;
		totalTime = 0f;
		totalCalories = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
