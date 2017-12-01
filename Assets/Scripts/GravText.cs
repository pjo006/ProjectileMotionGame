﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravText : MonoBehaviour {

	private static Text gravText;

	// Use this for initialization
	void Awake () {
		gravText = GetComponent<Text> ();
	}

	public static void setGravText(string text){
		gravText.text = text + " m/s^2";
	}
}
