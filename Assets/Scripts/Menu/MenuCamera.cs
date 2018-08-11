using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

	public Camera cam;
	public float hue = 0f;
	// unity functions
	void Start () {
		cam = GetComponent<Camera>();
		hue = Random.Range(0.000f, 1.000f);
	}
	
	void Update() {
		hue += 0.001f;
		if(hue >= 1) hue = 0;

		cam.backgroundColor = Color.HSVToRGB(hue, 0.7f, 0.5f);
	}
	
}
