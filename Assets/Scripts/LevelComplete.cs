using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	private static Text completeText;
	private static float timer = 0f;
	private static float maxTime = 2f;

	// Use this for initialization
	void Start () {
		completeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (completeText.text != ""){
			if (timer >= maxTime) {
				completeText.text = "";
			}
		}
	}

	public static void showLevelComplete() {
		completeText.text = "Level Complete";
		timer = 0f;
	}
}
