﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	Button button;
	Text text;
	RectTransform rectTransform;
	string initialText;
	bool selected = false;
	AudioSource voice;

	public const float waitTime = 8.5f; // 8 sec of instructions
	float timer = waitTime;

	public static List<GameObject> buttons = new List<GameObject>();

	public int mode;

	// Use this for initialization
	void OnEnable () {
		voice = GetComponent<AudioSource> ();
		text = transform.GetChild(0).GetComponent<Text> (); // set text
		initialText = text.text; // get initial text
		rectTransform = GetComponent<RectTransform> ();
		button = GetComponent<Button> ();
		if (mode == 0) { // left side of screen
			rectTransform.anchoredPosition = new Vector2 (Screen.width / 4, 0);
		} else { // right side of screen
			rectTransform.anchoredPosition = new Vector2 (-Screen.width / 4, 0);
		}
		rectTransform.sizeDelta = new Vector2 (0.8f * Screen.width/2, 0.8f * Screen.height); // set size

		button.image.color = button.colors.normalColor; // init button style
		text.text = initialText;

		buttons.Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if ((mode == 0 && Input.mousePosition.x < Screen.width/2) || (mode == 1 && Input.mousePosition.x > Screen.width/2)) { // will be selected
			if (!selected) {
				button.image.color = button.colors.highlightedColor; // selected style
				text.text = "\u25B6 " + initialText.Replace ("\n", " \u25C0\n");
				selected = true;
				if (timer < 0f) {
					voice.Play ();
				}
			}
		} else {
			if (selected) {
				button.image.color = button.colors.normalColor; // unselected style
				text.text = initialText;
				selected = false;
			}
		}
	}

	void OnDestroy() {
		buttons = new List<GameObject> ();
	}
}
