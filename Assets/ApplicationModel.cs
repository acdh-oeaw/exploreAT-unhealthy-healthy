using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModel {

	static public int spriteNum;
	static public int lives;
	static public int totalScore;
	static public float totalTime;
	static public int totalCalories;
	static public bool isJumping;
	static public bool isPowered;

	// Use this for initialization
	void Start () {
		spriteNum = 0;
		lives = 3;
		totalScore = 0;
		totalTime = 0f;
		totalCalories = 0;
		isJumping = false;
		isPowered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
