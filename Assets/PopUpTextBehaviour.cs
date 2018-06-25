using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextBehaviour : MonoBehaviour {

	public GameObject popUpObject;

	void Start()
	{
		//StartCoroutine(DestroyPopUp());
	}

	IEnumerator DestroyPopUp()
	{
		yield return new WaitForSeconds(2);
		//Destroy (popUpObject);
	}
}
