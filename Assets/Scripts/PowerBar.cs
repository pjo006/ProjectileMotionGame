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
		powerBar.value = (ControlUtility.GetVelocity()/ControlUtility.VELOCITY_SCALE) / 1400f;
		Fill.color = Color.Lerp (Color.green,Color.red,powerBar.value);
	}
}
