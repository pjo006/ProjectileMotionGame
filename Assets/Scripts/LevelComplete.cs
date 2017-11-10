using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	private static Text completeText;

	// Use this for initialization
	void Start () {
		print ("Start Method for LevelComplete");
		completeText = GetComponent<Text> ();
		print (completeText.ToString ());
	}

	public static void showLevelComplete() {
		completeText.text = "Level Complete";
	}

	public static void hideLevelComplete() {
		completeText.text = "";
	}
}
