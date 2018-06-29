using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotator : MonoBehaviour {

	void Update()
	{
		if (tag == "Roller") {
			if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
				transform.Rotate (new Vector3 (0, 0, -20) * Time.deltaTime * -20);
			} else {
				transform.Rotate (new Vector3 (0, 0, -20) * Time.deltaTime * 20);
			}
		} else if (tag == "ItemChanger") {
			transform.Rotate (new Vector3 (0, 0, -20) * Time.deltaTime * 20);
		}

	}

	// Use this for initialization
	void Start () {
	}
}
