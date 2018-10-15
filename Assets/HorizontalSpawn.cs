using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalSpawn : MonoBehaviour {

	public GameObject RightSide;
	public GameObject SpawnerHorizontal;
	public GameObject Roller;
	public PhysicsMaterial2D noFrictMaterial;
	public float startDelay, repeatRate;
	public System.Random rand;


	// Use this for initialization
	IEnumerator Start () {

		rand = new System.Random ();

		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			startDelay = 2.5f;
			repeatRate = 5.5f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
			startDelay = 2.0f;
			repeatRate = 4.5f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
			startDelay = 1.5f;
			repeatRate = 3.5f;
		}

		while(true)
		{
			yield return new WaitForSeconds(repeatRate);
			//Spawn();
		}
		//InvokeRepeating ("Spawn", startDelay, repeatRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn () {

		return;

		// Random pizza roller spawn from left or right
		bool goingLeft = true;
		if (rand.NextDouble () >= 0.5) {
			goingLeft = false;
		}

		int posX = 9; if (!goingLeft) {posX = -9;}
		float randomSpeed = 0f;

		Vector3 pos = new Vector3 (posX, -4.2f, 0); 
		GameObject newObject = null;
		if (!goingLeft) {
			newObject = Instantiate (Roller, pos, gameObject.transform.rotation);
		} else {
			newObject = Instantiate (Roller, pos, gameObject.transform.rotation);
		}

		// Each time a spawn occur, the objects rolls faster
		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.75;
			randomSpeed = UnityEngine.Random.Range (3,7);
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)1.25;
			randomSpeed = UnityEngine.Random.Range (8,14);
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)1.75;
			randomSpeed = UnityEngine.Random.Range (15,21);
		}

		if (!goingLeft) {randomSpeed = -randomSpeed;}
		newObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-randomSpeed,0,0);
		//newObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4 * -4 * Time.deltaTime * 1 * -8, 0f));

		// Also, object appear faster each time one is spawned
		if(repeatRate>0.5)
		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			repeatRate -= (float).025;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
			repeatRate -= (float).05;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
			repeatRate -= (float).075;
		}
	} 
}
