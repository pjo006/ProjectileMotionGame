using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetText : MonoBehaviour {

	private static Text planetText;

	// Use this for initialization
	void Awake () {
		planetText = GetComponent<Text> ();
	}

	public static void setPlanetText(string text){
		planetText.text = text[0].ToString().ToUpper() + text.Substring(1) + "'s Gravity";
	}
}
