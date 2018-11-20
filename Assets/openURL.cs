using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class openURL : MonoBehaviour, IPointerClickHandler {

	public Text sourceText;

	// Use this for initialization
	void Start () {
		if (ApplicationModel.language == "en") {
			sourceText.text = ApplicationModel.en_pyramid_source;
		}
		else if (ApplicationModel.language == "es") {
			sourceText.text = ApplicationModel.es_pyramid_source;
		}
		else if (ApplicationModel.language == "de") {
			sourceText.text = ApplicationModel.de_pyramid_source;
		}
	}
	
	// Update is called once per frame
	void Update () {

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
