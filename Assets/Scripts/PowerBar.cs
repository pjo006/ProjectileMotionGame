using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

	public Slider powerBar;
	public Image Fill;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		powerBar.value = Input.mousePosition.x / 1400f;
		if (powerBar.value < 0.33f) {
			Fill.color = Color.green;	
		} else if (powerBar.value < 0.66f) {
			Fill.color = Color.yellow;
		} else if (powerBar.value < 0.9f) {
			Fill.color = Color.red;
		}
	}
}
