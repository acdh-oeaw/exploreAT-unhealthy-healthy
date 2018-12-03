using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ap = ApplicationModel;

public class openURL : MonoBehaviour, IPointerClickHandler {

	public Text sourceText;

	// Use this for initialization
	void Start () {
		if (ap.language == "en") {
			sourceText.text = ap.en_pyramid_source;
		}
		else if (ap.language == "es") {
			sourceText.text = ap.es_pyramid_source;
		}
		else if (ap.language == "de") {
			sourceText.text = ap.de_pyramid_source;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {ap.language = "en";}
		else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {ap.language = "es";}
		else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad2)) {ap.language = "de";}

		if(Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1) ||
			Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2) ||
			Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3)){
			if (ap.language == "en") {
				sourceText.text = ap.en_pyramid_source;
			}
			else if (ap.language == "es") {
				sourceText.text = ap.es_pyramid_source;
			}
			else if (ap.language == "de") {
				sourceText.text = ap.de_pyramid_source;
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("Clicked on: " + gameObject.name);
		string url = "https://www.gesundheit.gv.at/leben/ernaehrung/info/ernaehrungspyramide/ernaehrungspyramide";
		Application.OpenURL(url);
	}

	void onMouseDown()
	{
		Debug.Log("Mouse down on: " + gameObject.name);
		string url = "https://www.gesundheit.gv.at/leben/ernaehrung/info/ernaehrungspyramide/ernaehrungspyramide";
		Application.OpenURL(url);
	}
}
