﻿using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class BossMovementHandler : MonoBehaviour {

	int speed;
	public Sprite[] spritesBoss;

	// Use this for initialization
	void Start () {
		speed = 130;
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed,0,0);
		Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
		gameObject.GetComponent<BoxCollider2D>().size = S;
		//character.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (ap.bossPoints > -1 && ap.bossPoints < 3) {speed = 200;}
		else if (ap.bossPoints >=3 && ap.bossPoints < 6) {speed = 300;}
		else if (ap.bossPoints >=6) {speed = 400;}

		if (gameObject.transform.position.x < 70) {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (speed, 0, 0);
			gameObject.GetComponent<SpriteRenderer> ().sprite = spritesBoss[1];
		} else if(gameObject.transform.position.x > 700){
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-speed, 0, 0);
			gameObject.GetComponent<SpriteRenderer> ().sprite = spritesBoss[0];
		}
	}
}
