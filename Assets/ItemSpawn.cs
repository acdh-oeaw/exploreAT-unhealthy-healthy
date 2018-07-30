using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawn : MonoBehaviour {

	public GameObject RightSide;
	public GameObject[] items;
	public float startDelay, repeatRate;
	public Sprite[] fruitSprites;
	public Sprite[] fastFoodSprites;
	public Sprite[] liveSprites;
	public Sprite[] starSprites;
	public Sprite[] bombSprites;
	public Sprite[] bicycleSprites;
	public Sprite[] changerSprites;


	// Use this for initialization
	IEnumerator Start () {
		while(true)
		{
			if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
				startDelay = 0.5f;
				repeatRate = 3f;
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
				startDelay = 0.5f;
				repeatRate = 2.5f;
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
				startDelay = 0.5f;
				repeatRate = 2f;
			}

			yield return new WaitForSeconds(repeatRate);
			Spawn();
		}
		//InvokeRepeating ("Spawn", startDelay, repeatRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn () {
		Vector3 pos = new Vector3 (Random.Range (gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, 0); 
		int elemType = Random.Range (0, 2);

		if (Random.Range (0, 20) > 16 && ApplicationModel.lives < 3) {elemType = 2;} // Live generation
		if (Random.Range (0, 40) > 32 && !ApplicationModel.isPowered) {elemType = 3;} // Star generation
		//if (Random.Range (0, 40) > 32 && !ApplicationModel.isPowered) {elemType = 4;} // Bomb generation
		if (Random.Range (0, 20) > 16 && !ApplicationModel.isPowered) {elemType = 6;} // Changer generation
		if (Random.Range (0, 20) > 16 && transform.localScale.x > 0.6 && ApplicationModel.lives < 3) {elemType = 5;} // Bicycle generation

		GameObject newObject = Instantiate (items [elemType], pos, Quaternion.Euler(new Vector3(0,0,Random.Range (-55, 55))));
		if (elemType == 0) { // If fruit, random sprite
			int num = 0;
			// As we advance we see more/different items appear
			if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
				num = UnityEngine.Random.Range (0, 2);
			} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene2")) {
				num = UnityEngine.Random.Range (0, 4);
			} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene3")) {
				num = UnityEngine.Random.Range (0, fruitSprites.Length);
			}
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = fruitSprites [num];

		} else if (elemType == 1) { // fastFood sprite
			int num = 0;
			num = UnityEngine.Random.Range (0, fastFoodSprites.Length);
			// As we advance we see more/different items appear
			if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
				num = UnityEngine.Random.Range (0, 2);
			} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene2")) {
				num = UnityEngine.Random.Range (0, 4);
			} else if (string.Equals (SceneManager.GetActiveScene ().name, "scene3")) {
				num = UnityEngine.Random.Range (0, fastFoodSprites.Length);
			}
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = fastFoodSprites [num];
		} else if(elemType == 2){ // live sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = liveSprites [0];
		}
		else if(elemType == 3){ // star sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = starSprites [0];
		}
		else if(elemType == 4){ // bomb sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = bombSprites [0];
		}
		else if(elemType == 4){ // bicycle sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = bicycleSprites [0];
		}

		// Each time a spawn occur, the objects fall faster
		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.15f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.3f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.45f;
		}


		// Also, object appear faster each time one is spawned
		if(repeatRate>0.5)
		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			repeatRate -= (float).05f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
			repeatRate -= (float).075f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
			repeatRate -= (float).1f;
		}
	} 
}
