using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

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


	// Boss level
	public GameObject FoodGroup1IconObject;
	public GameObject FoodGroup1BarObject;
	public GameObject FoodGroup2IconObject;
	public GameObject FoodGroup2BarObject;
	public GameObject FoodGroup3IconObject;
	public GameObject FoodGroup3BarObject;
	public Sprite[] foodGroupSprites;
	public Sprite[] foodBarSprites;

	// Use this for initialization
	IEnumerator Start () {

		if (string.Equals (SceneManager.GetActiveScene ().name, "scene")) {
			return StartScene ();
		} else if (string.Equals (SceneManager.GetActiveScene ().name, "sceneBoss")) {
			return StartSceneBoss ();
		}

		// Should never reach this point - hacky fix
		return StartScene ();
	}
	

	IEnumerator StartScene(){
		
		elemType_lastFoodTypeValue = elemType_SweetSalty;

		startDelay = 0.5f;

		indexSummer = new List<int>();
		indexWinter = new List<int>();

		while(true)
		{
			// Easier (slower falling objects) as the user advances
			repeatRate = 0.4f+(float)(1)/10;//(ap.level/10);
			yield return new WaitForSeconds(repeatRate);
			SpawnScene();
		}
	}

	void SpawnScene() {

		indexSummer.Clear ();
		indexWinter.Clear ();

		// Generate a random food, then flip a coin to see if something not a food pops out
		Vector3 pos = new Vector3 (UnityEngine.Random.Range (gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, -40); 
		int elemType = UnityEngine.Random.Range (0, elemType_lastFoodTypeValue+1);

		// Distribute the spawining depending on varying percentages
		elemType = UnityEngine.Random.Range (0,100);
		if ((elemType -= ap.pctBreadPasta) < 0) {
			elemType = elemType_BreadPasta;
		}
		else if ((elemType -= ap.pctFruitVeggies) < 0) {
			elemType = elemType_FruitVeggies;
		}
		else if ((elemType -= ap.pctMeatFish) < 0) {
			elemType = elemType_MeatFish;
		}
		else if ((elemType -= ap.pctMilkCheese) < 0) {
			elemType = elemType_MilkCheese;
		}
		else if ((elemType -= ap.pctSweetSalty) < 0) {
			elemType = elemType_SweetSalty;
		}

		// Randomly, something not food will spawn
		if (ap.totalSport < ap.counterSportValue) {
			if (UnityEngine.Random.Range (0, 100) > 80) {elemType = elemType_Bycicle;} // Bicycle generation
		}
		if (ap.totalWater < ap.counterWaterValue) {
			if (UnityEngine.Random.Range (0, 100) > 80) {elemType = elemType_Water;} // Water generation
		}
		if (UnityEngine.Random.Range (0, 100) > 91+ap.level) {elemType = elemType_EnergyDrink;} // Energy Drink generation

		GameObject newObject = Instantiate (items [elemType], pos, Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range (-55, 55))));
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodBreadPastaSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodFruitVeggiesSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMeatFishSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMilkCheeseSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodSweetSaltySprites [indexSummer[num]];
			} else if (ap.season == 1) {
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

		// Each time a spawn occur, the objects fall faster
		newObject.GetComponent<Rigidbody2D>().gravityScale = 15;
		/*
		if (ap.level == 1) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.015f;
		}
		else if (ap.level == 2) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.3f;
		}
		else if (ap.level == 3) {
			newObject.GetComponent<Rigidbody2D>().gravityScale += (float)0.45f;
		}
		*/

		newObject.transform.SetAsLastSibling ();


		// Also, object appear faster each time one is spawned
		if(repeatRate>0.5)
		if (ap.level == 1) {
			repeatRate -= (float).05f;
		}
		else if (ap.level == 2) {
			repeatRate -= (float).075f;
		}
		else if (ap.level == 3) {
			repeatRate -= (float).1f;
		}

		else if (ap.level > 3) {
			repeatRate -= (float).125f;
		}
	}

	public void addToArray(List<int> theList, int[] indexToAdd){
		for (int i = 0; i < indexToAdd.Length; i++) {
			theList.Add (indexToAdd [i]);
		}
	}







	IEnumerator StartSceneBoss(){

		System.Random rnd = new System.Random();
		ap.selectedFoodGroups = Enumerable.Range(0, 5).OrderBy(c => rnd.Next()).ToArray();
		FoodGroup1IconObject.GetComponent<SpriteRenderer> ().sprite = foodGroupSprites [ap.selectedFoodGroups[0]];
		FoodGroup2IconObject.GetComponent<SpriteRenderer> ().sprite = foodGroupSprites [ap.selectedFoodGroups[1]];
		FoodGroup3IconObject.GetComponent<SpriteRenderer> ().sprite = foodGroupSprites [ap.selectedFoodGroups[2]];

		if(ap.selectedFoodGroups[0] == elemType_BreadPasta){ap.bossFoodGroup1type = "FoodBreadPasta";}
		else if(ap.selectedFoodGroups[0] == elemType_FruitVeggies){ap.bossFoodGroup1type = "FoodFruitVeggies";}
		else if(ap.selectedFoodGroups[0] == elemType_MeatFish){ap.bossFoodGroup1type = "FoodMeatFish";}
		else if(ap.selectedFoodGroups[0] == elemType_MilkCheese){ap.bossFoodGroup1type = "FoodMilkCheese";}
		else if(ap.selectedFoodGroups[0] == elemType_SweetSalty){ap.bossFoodGroup1type = "FoodSweetSalty";}
		ap.bossCurrentFoodGroupType = ap.bossFoodGroup1type;

		if(ap.selectedFoodGroups[1] == elemType_BreadPasta){ap.bossFoodGroup2type = "FoodBreadPasta";}
		else if(ap.selectedFoodGroups[1] == elemType_FruitVeggies){ap.bossFoodGroup2type = "FoodFruitVeggies";}
		else if(ap.selectedFoodGroups[1] == elemType_MeatFish){ap.bossFoodGroup2type = "FoodMeatFish";}
		else if(ap.selectedFoodGroups[1] == elemType_MilkCheese){ap.bossFoodGroup2type = "FoodMilkCheese";}
		else if(ap.selectedFoodGroups[1] == elemType_SweetSalty){ap.bossFoodGroup2type = "FoodSweetSalty";}

		if(ap.selectedFoodGroups[2] == elemType_BreadPasta){ap.bossFoodGroup3type = "FoodBreadPasta";}
		else if(ap.selectedFoodGroups[2] == elemType_FruitVeggies){ap.bossFoodGroup3type = "FoodFruitVeggies";}
		else if(ap.selectedFoodGroups[2] == elemType_MeatFish){ap.bossFoodGroup3type = "FoodMeatFish";}
		else if(ap.selectedFoodGroups[2] == elemType_MilkCheese){ap.bossFoodGroup3type = "FoodMilkCheese";}
		else if(ap.selectedFoodGroups[2] == elemType_SweetSalty){ap.bossFoodGroup3type = "FoodSweetSalty";}

		FoodGroup1IconObject.SetActive (true);
		FoodGroup1BarObject.SetActive (true);
		FoodGroup2IconObject.SetActive (false);
		FoodGroup2BarObject.SetActive (false);
		FoodGroup3IconObject.SetActive (false);
		FoodGroup3BarObject.SetActive (false);

		// Every bar goes empty at the start of the round
		FoodGroup1BarObject.GetComponent<SpriteRenderer> ().sprite = foodBarSprites [0];
		FoodGroup2BarObject.GetComponent<SpriteRenderer> ().sprite = foodBarSprites [0];
		FoodGroup3BarObject.GetComponent<SpriteRenderer> ().sprite = foodBarSprites [0];

		elemType_lastFoodTypeValue = elemType_SweetSalty;

		startDelay = 0.5f;

		indexSummer = new List<int>();
		indexWinter = new List<int>();


		while(true)
		{
			// Easier (slower falling objects) as the user advances
			repeatRate = 0.4f+(float)(ap.level/20);
			yield return new WaitForSeconds(repeatRate);
			SpawnSceneBoss();
		}
	}

	void SpawnSceneBoss(){

		indexSummer.Clear ();
		indexWinter.Clear ();

		// Generate a random food, then flip a coin to see if something not a food pops out
		Vector3 pos = new Vector3 (UnityEngine.Random.Range (gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, -40); 
		int elemType = UnityEngine.Random.Range (0, elemType_lastFoodTypeValue+1);

		// Distribute the spawining depending on varying percentages
		elemType = UnityEngine.Random.Range (0,100);
		int pct = 20;
		if ((elemType -= pct) < 0) {elemType = elemType_BreadPasta;}
		else if ((elemType -= pct) < 0) {elemType = elemType_FruitVeggies;}
		else if ((elemType -= pct) < 0) {elemType = elemType_MeatFish;}
		else if ((elemType -= pct) < 0) {elemType = elemType_MilkCheese;}
		else if ((elemType -= pct) < 0) {elemType = elemType_SweetSalty;}

		GameObject newObject = Instantiate (items [elemType], pos, Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range (-55, 55))));
		float scaleFood = 55.0f;
		float scaleZ = -30;
		if (elemType == elemType_BreadPasta) {
			newObject.transform.localScale += new Vector3(scaleFood, scaleFood, scaleZ);
			int num = 0;

			addToArray(indexSummer,new int[] {0,1,2,3});
			addToArray(indexWinter,new int[] {0,1,2,3});

			// Different items depending on the season
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodBreadPastaSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodFruitVeggiesSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMeatFishSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodMilkCheeseSprites [indexSummer[num]];
			} else if (ap.season == 1) {
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
			if (ap.season == 0) {
				num = UnityEngine.Random.Range (0, indexSummer.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodSweetSaltySprites [indexSummer[num]];
			} else if (ap.season == 1) {
				num = UnityEngine.Random.Range (0, indexWinter.Count);
				newObject.AddComponent<SpriteRenderer> ();
				newObject.GetComponent<SpriteRenderer> ().sprite = foodSweetSaltySprites [indexWinter[num]];
			}
		}

		// Change collision bounds
		Vector2 S = newObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
		newObject.GetComponent<BoxCollider2D>().size = S;
		newObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);

		// Each time a spawn occur, the objects fall faster
		newObject.GetComponent<Rigidbody2D>().gravityScale = 15;

		newObject.transform.SetAsLastSibling ();

		// Also, object appear faster each time one is spawned
		if(repeatRate>0.5)
		if (ap.level == 1) {
			repeatRate -= (float).05f;
		}
		else if (ap.level == 2) {
			repeatRate -= (float).075f;
		}
		else if (ap.level == 3) {
			repeatRate -= (float).1f;
		}
		else if (ap.level > 3) {
			repeatRate -= (float).125f;
		}
	}
}

