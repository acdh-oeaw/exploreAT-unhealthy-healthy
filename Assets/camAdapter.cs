using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ap = ApplicationModel;

public class CamAdapter : MonoBehaviour 
{
	[Header("Reference Size")]
	public float width;        // Width of the game in units
	public float height;    // Width of the game in units

	public float pixelsPerUnit;        // PPU

	[Header(" ")]
	public bool detectFullscreenMode = false;    // Should the script re-trigger when the game is sent into fullscreen mode? (ie: in WebGL browser)

	private bool lastFullscreenState = false;


	void Awake()
	{
		SetSizer();
	}

	void SetSizer()
	{
		float aspectRatio = (float)Screen.width / (float)Screen.height;
		float newCameraHeight = (width/pixelsPerUnit) / aspectRatio;
		float targetAspectRatio = width/height;

		if(aspectRatio < targetAspectRatio)
			GetComponent<Camera>().orthographicSize = newCameraHeight/2f;

		lastFullscreenState = Screen.fullScreen;
	}


	void Update()
	{
		if(detectFullscreenMode){
			if(Screen.fullScreen != lastFullscreenState)
				SetSizer();
		}
	}

}