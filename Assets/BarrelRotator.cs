using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotator : MonoBehaviour {

	int speed;

	void Update()
	{
		if (tag == "Roller") {
			if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
				transform.Rotate (new Vector3 (0, 0, -speed) * Time.deltaTime * -speed);
			} else {
				transform.Rotate (new Vector3 (0, 0, -speed) * Time.deltaTime * speed);
			}
		} else if (tag == "ItemChanger") {
			transform.Rotate (new Vector3 (0, 0, -speed) * Time.deltaTime * speed);
		}

	}

	// Use this for initialization
	void Start () {
		speed = 15;
	}
}
