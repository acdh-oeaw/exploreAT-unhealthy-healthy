using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class HorizontalSpawn : MonoBehaviour {

	public GameObject RightSide;
	public GameObject SpawnerHorizontal;
	public GameObject Roller;
	public GameObject Cloud;
	public PhysicsMaterial2D noFrictMaterial;
	public float startDelay, repeatRate;
	public System.Random rand;
	public Sprite[] cloudSprites;


	// Use this for initialization
	IEnumerator Start () {

		rand = new System.Random ();

		while(true)
		{
			yield return new WaitForSeconds(2f);
			Spawn();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn () {

		bool goingLeft = true;
		if (rand.NextDouble () >= 0.5) {
			goingLeft = false;
		}

		int posX = 800; if (!goingLeft) {posX = -100;}

		Vector3 pos = new Vector3 (posX, UnityEngine.Random.Range (250,370), 0); 
		GameObject newObject = null;
		if (!goingLeft) {
			newObject = Instantiate (Cloud, pos, gameObject.transform.rotation);
		} else {
			newObject = Instantiate (Cloud, pos, gameObject.transform.rotation);
		}

		newObject.transform.localScale += new Vector3(20.0f, 20.0f, 0);
		int randomSpeed = UnityEngine.Random.Range (50,100);
		if (!goingLeft) {randomSpeed = -randomSpeed;}
		newObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-randomSpeed,0,0);

		newObject.GetComponent<SpriteRenderer> ().sprite = cloudSprites [UnityEngine.Random.Range (0,cloudSprites.Length)];

		Color tmp = newObject.GetComponent<SpriteRenderer>().color;
		tmp.a = 0.0f+(float)UnityEngine.Random.Range (40,70)/100f;
		newObject.GetComponent<SpriteRenderer>().color = tmp;
	} 
}
