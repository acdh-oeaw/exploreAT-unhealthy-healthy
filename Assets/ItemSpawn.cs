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
		int elemType = Random.Range (0, items.Length);
		GameObject newObject = Instantiate (items [elemType], pos, gameObject.transform.rotation);
		if (elemType == 0) { // If fruit, random sprite
			int num = 0;
			// As we advance we see more/different items appear
			if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
				num = UnityEngine.Random.Range (0, 2);
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
				num = UnityEngine.Random.Range (0, 4);
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
				num = UnityEngine.Random.Range (0, fruitSprites.Length);
			}
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = fruitSprites [num];

		} else {
			int num = 0;
			num = UnityEngine.Random.Range(0, fastFoodSprites.Length);
			// As we advance we see more/different items appear
			if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
				num = UnityEngine.Random.Range (0, 2);
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
				num = UnityEngine.Random.Range (0, 4);
			}
			else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
				num = UnityEngine.Random.Range (0, fastFoodSprites.Length);
			}
			newObject.AddComponent<SpriteRenderer>();
			newObject.GetComponent<SpriteRenderer>().sprite = fastFoodSprites[num];
		}

		// Each time a spawn occur, the objects fall faster
		if (string.Equals(SceneManager.GetActiveScene ().name,"scene")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.25f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene2")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.5f;
		}
		else if (string.Equals(SceneManager.GetActiveScene ().name,"scene3")) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.75f;
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
