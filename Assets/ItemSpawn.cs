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
	public Sprite[] bicycleSprites;
	public Sprite[] waterSprites;
	public Sprite[] energyDrinkSprites;


	// Use this for initialization
	IEnumerator Start () {
		while(true)
		{
			if (ApplicationModel.level == 1) {
				startDelay = 0.5f;
				repeatRate = 2f;
			}
			else if (ApplicationModel.level == 2) {
				startDelay = 0.5f;
				repeatRate = 1.5f;
			}
			else if (ApplicationModel.level == 3) {
				startDelay = 0.5f;
				repeatRate = 1f;
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

		// Randomly, something not food will spawn
		if (Random.Range (0, 20) > 12) {elemType = 2;} // Bicycle generation
		if (Random.Range (0, 20) > 14) {elemType = 3;} // Water generation
		if (Random.Range (0, 20) > 17) {elemType = 4;} // Energy Drink generation

		GameObject newObject = Instantiate (items [elemType], pos, Quaternion.Euler(new Vector3(0,0,Random.Range (-55, 55))));
		if (elemType == 0) { // If fruit, random sprite
			int num = 0;
			// As we advance we see more/different items appear
			if (ApplicationModel.level == 0) {
				num = UnityEngine.Random.Range (0, fruitSprites.Length);//2);
			} else if (ApplicationModel.level == 1) {
				num = UnityEngine.Random.Range (0, fruitSprites.Length);//4);
			} else if (ApplicationModel.level == 2) {
				num = UnityEngine.Random.Range (0, fruitSprites.Length);
			}
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = fruitSprites [num];

		} else if (elemType == 1) { // fastFood sprite
			int num = 0;
			num = UnityEngine.Random.Range (0, fastFoodSprites.Length);
			// As we advance we see more/different items appear
			if (ApplicationModel.level == 0) {
				num = UnityEngine.Random.Range (0, fastFoodSprites.Length);//2);
			} else if (ApplicationModel.level == 1) {
				num = UnityEngine.Random.Range (0, fastFoodSprites.Length);//4);
			} else if (ApplicationModel.level == 2) {
				num = UnityEngine.Random.Range (0, fastFoodSprites.Length);
			}
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = fastFoodSprites [num];
		} else if(elemType == 2){ // bicycle sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = bicycleSprites [0];
		} else if(elemType == 3){ // water sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = waterSprites [0];
		} else if(elemType == 4){ // energy drink sprite
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = energyDrinkSprites [0];
		}

		// Each time a spawn occur, the objects fall faster
		if (ApplicationModel.level == 1) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.15f;
		}
		else if (ApplicationModel.level == 2) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.3f;
		}
		else if (ApplicationModel.level == 3) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.45f;
		}


		// Also, object appear faster each time one is spawned
		if(repeatRate>0.5)
		if (ApplicationModel.level == 1) {
			repeatRate -= (float).05f;
		}
		else if (ApplicationModel.level == 2) {
			repeatRate -= (float).075f;
		}
		else if (ApplicationModel.level == 3) {
			repeatRate -= (float).1f;
		}
	} 
}
