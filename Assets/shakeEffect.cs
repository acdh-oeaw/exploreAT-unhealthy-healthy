using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ShakeEffect : MonoBehaviour {

	// vars
	private bool shakeOn = false;
	private float shakePower = 0;

	// sprite original position
	private Vector3 originPosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// if shake is enabled
		if(shakeOn) {

			// reset original position
			transform.position = originPosition;

			// generate random position in a 1 unit circle and add power
			Vector2 ShakePos = Random.insideUnitCircle * shakePower;

			// transform to new position adding the new coordinates
			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z); 
		}
	}

	// shake on
	public void ShakeCameraOn(float sPower){

		//save position before start shake, 
		//this it's really important otherwise 
		//the sprite can goes away and will not return 
		//in native position
		originPosition = transform.position;

		//enable shaking and setting power
		shakeOn = true;
		shakePower = sPower;
	}

	// shake off
	public void ShakeCameraOff(){

		// shake off
		shakeOn = false;

		// set original position after 
		transform.position = originPosition;
	}

}