using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotator : MonoBehaviour {

	void Update()
	{
		transform.Rotate (new Vector3 (0, 0, 20) * Time.deltaTime * 20);
	}

	// Use this for initialization
	void Start () {
		
	}
}
