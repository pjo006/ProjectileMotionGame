using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	public static Text levelText;
	private static int level = 0;

	// Use this for initialization
	void Start () {
		levelText = GetComponent<Text> ();
		levelText.text = "Level " + level.ToString();
	}

	public static void incrementLevel(){
		level++;
		levelText.text = "Level " + level.ToString ();
	}
}
