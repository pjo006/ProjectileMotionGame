using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	private static Text levelText;

	// Use this for initialization
	void Awake () {
		levelText = GetComponent<Text> ();
	}

	public static void setLevelText(string text){
		levelText.text = text.ToUpper();
	}
}
