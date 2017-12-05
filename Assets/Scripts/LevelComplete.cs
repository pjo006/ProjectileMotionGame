using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	private static Text completeText;

	// Use this for initialization
	void OnEnable () {
		completeText = GetComponent<Text> (); // set text
	}

	public static void showLevelComplete() {
		completeText.text = "Level Complete"; // show when needed
	}

	public static void hideLevelComplete() {
		completeText.text = ""; // hide when not needed
	}
}
