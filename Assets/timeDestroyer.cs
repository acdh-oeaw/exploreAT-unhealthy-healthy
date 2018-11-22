using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ap = ApplicationModel;

public class timeDestroyer : MonoBehaviour {

	public float aliveTimer;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, aliveTimer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
