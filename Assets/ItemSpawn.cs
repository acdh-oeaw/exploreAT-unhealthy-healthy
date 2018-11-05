using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawn : MonoBehaviour {

	public static int elemType_BreadPasta = 0;
	public static int elemType_FruitVeggies = 1;
	public static int elemType_MeatFish = 2;
	public static int elemType_MilkCheese = 3;
	public static int elemType_SweetSalty = 4;
	public static int elemType_lastFoodTypeValue = 0;

	public static int elemType_Bycicle = 5;
	public static int elemType_Water = 6;
	public static int elemType_EnergyDrink = 7;

	public GameObject RightSide;
	public GameObject[] items;
	public float startDelay, repeatRate;

	public Sprite[] bicycleSprites;
	public Sprite[] waterSprites;
	public Sprite[] energyDrinkSprites;

	public Sprite[] foodBreadPastaSprites;
	public Sprite[] foodFruitVeggiesSprites;
	public Sprite[] foodMeatFishSprites;
	public Sprite[] foodMilkCheeseSprites;
	public Sprite[] foodSweetSaltySprites;

	public List<int> indexSummer;
	public List<int> indexWinter;


	// Use this for initialization
	IEnumerator Start () {

		elemType_lastFoodTypeValue = elemType_SweetSalty;

		startDelay = 0.5f;

		indexSummer = new List<int>();
		indexWinter = new List<int>();

		while(true)
		{
			// Easier (slower falling objects) as the user advances
			repeatRate = 0.4f+(float)(ApplicationModel.level/10);
			yield return new WaitForSeconds(repeatRate);
			Spawn();
		}
		//InvokeRepeating ("Spawn", startDelay, repeatRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn () {

		indexSummer.Clear ();
		indexWinter.Clear ();

		// Generate a random food, then flip a coin to see if something not a food pops out
		Vector3 pos = new Vector3 (Random.Range (gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, -40); 
		int elemType = Random.Range (0, elemType_lastFoodTypeValue+1);

		// Distribute the spawining depending on varying percentages
		elemType = Random.Range (0,100);
		if ((elemType -= ApplicationModel.pctBreadPasta) < 0) {
			elemType = elemType_BreadPasta;
		}
		else if ((elemType -= ApplicationModel.pctFruitVeggies) < 0) {
			elemType = elemType_FruitVeggies;
		}
		else if ((elemType -= ApplicationModel.pctMeatFish) < 0) {
			elemType = elemType_MeatFish;
		}
		else if ((elemType -= ApplicationModel.pctMilkCheese) < 0) {
			elemType = elemType_MilkCheese;
		}
		else if ((elemType -= ApplicationModel.pctSweetSalty) < 0) {
			elemType = elemType_SweetSalty;
		}

		// Randomly, something not food will spawn
		if (ApplicationModel.totalSport < ApplicationModel.counterSportValue) {
			if (Random.Range (0, 100) > 80) {elemType = elemType_Bycicle;} // Bicycle generation
		}
		if (ApplicationModel.totalWater < ApplicationModel.counterWaterValue) {
			if (Random.Range (0, 100) > 80) {elemType = elemType_Water;} // Water generation
		}
		if (Random.Range (0, 100) > 91+ApplicationModel.level) {elemType = elemType_EnergyDrink;} // Energy Drink generation

		GameObject newObject = Instantiate (items [elemType], pos, Quaternion.Euler(new Vector3(0,0,Random.Range (-55, 55))));
		float scaleFood = 55.0f;
		float scaleWater = 23.0f;
		float scaleEnergy = 23.0f;
		float scaleBicycle = 26.0f;
		float scaleZ = -30;
		if (elemType == elemType_BreadPasta) {
			newObject.transform.localScale += new Vector3(scaleFood, scaleFood, scaleZ);
			int num = 0;

			addToArray(indexSummer,new int[] {0,1,2,3});
			addToArray(indexWinter,new int[] {0,1,2,3});

			// Different items depending on the season
			if (ApplicationModel.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodBreadPastaSprites [indexSummer[num]];
			} else if (ApplicationModel.season == 1) {
				num = UnityEngine.Random.Range (0, indexWinter.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodBreadPastaSprites [indexWinter[num]];
			}
		}
		else if (elemType == elemType_FruitVeggies) {
			newObject.transform.localScale += new Vector3(scaleFood, scaleFood, scaleZ);
			int num = 0;

			addToArray(indexSummer,new int[] {0,1,3,5,6,7,8,9});
			addToArray(indexWinter,new int[] {1,2,3,4,5,6,9});

			// Different items depending on the season
			if (ApplicationModel.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodFruitVeggiesSprites [indexSummer[num]];
			} else if (ApplicationModel.season == 1) {
				num = UnityEngine.Random.Range (0, indexWinter.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodFruitVeggiesSprites [indexWinter[num]];
			}
		}
		else if (elemType == elemType_MeatFish) {
			newObject.transform.localScale += new Vector3(scaleFood, scaleFood, scaleZ);
			int num = 0;

			addToArray(indexSummer,new int[] {0,1,2,3,4,5});
			addToArray(indexWinter,new int[] {0,1,2,3,4,5});

			// Different items depending on the season
			if (ApplicationModel.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMeatFishSprites [indexSummer[num]];
			} else if (ApplicationModel.season == 1) {
				num = UnityEngine.Random.Range (0, indexWinter.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMeatFishSprites [indexWinter[num]];
			}
		}
		else if (elemType == elemType_MilkCheese) {
			newObject.transform.localScale += new Vector3(scaleFood, scaleFood, scaleZ);
			int num = 0;

			addToArray(indexSummer,new int[] {0,1,2});
			addToArray(indexWinter,new int[] {0,1,2});

			// Different items depending on the season
			if (ApplicationModel.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMilkCheeseSprites [indexSummer[num]];
			} else if (ApplicationModel.season == 1) {
				num = UnityEngine.Random.Range (0, indexWinter.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMilkCheeseSprites [indexWinter[num]];
			}
		}
		else if (elemType == elemType_SweetSalty) {
			newObject.transform.localScale += new Vector3(scaleFood, scaleFood, scaleZ);
			int num = 0;

			addToArray(indexSummer,new int[] {0,2,3});
			addToArray(indexWinter,new int[] {1,2,3});

			// Different items depending on the season
			if (ApplicationModel.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodSweetSaltySprites [indexSummer[num]];
			} else if (ApplicationModel.season == 1) {
				num = UnityEngine.Random.Range (0, indexWinter.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodSweetSaltySprites [indexWinter[num]];
			}
		}
		else if(elemType == elemType_Bycicle){ // bicycle sprite
			newObject.transform.localScale += new Vector3(scaleBicycle, scaleBicycle, 0);
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = bicycleSprites [0];
		}
		else if(elemType == elemType_Water){ // water sprite
			newObject.transform.localScale += new Vector3(scaleWater, scaleWater, 0);
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = waterSprites [0];
		}
		else if(elemType == elemType_EnergyDrink){ // energy drink sprite
			newObject.transform.localScale += new Vector3(scaleEnergy, scaleEnergy, 0);
			newObject.AddComponent<SpriteRenderer> ();
			newObject.GetComponent<SpriteRenderer> ().sprite = energyDrinkSprites [0];
		}

		// Change collision bounds
		Vector2 S = newObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
		newObject.GetComponent<BoxCollider2D>().size = S;
		newObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);

		// Each time a spawn occur, the objects fall faster
		newObject.GetComponent<Rigidbody2D>().gravityScale = 15;
		/*
		if (ApplicationModel.level == 1) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.015f;
		}
		else if (ApplicationModel.level == 2) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.3f;
		}
		else if (ApplicationModel.level == 3) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.45f;
		}
		*/

		newObject.transform.SetAsLastSibling ();


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

	public void addToArray(List<int> theList, int[] indexToAdd){
		for (int i = 0; i < indexToAdd.Length; i++) {
			theList.Add (indexToAdd [i]);
		}
	}
}

