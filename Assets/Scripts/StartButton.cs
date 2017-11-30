using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	Button button;
	RectTransform rectTransform;

	public static List<GameObject> buttons = new List<GameObject>();

	public int mode;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
		button = GetComponent<Button> ();
		if (mode == 0) {
			rectTransform.anchoredPosition = new Vector2 (Screen.width / 4, 0);
		} else {
			rectTransform.anchoredPosition = new Vector2 (-Screen.width / 4, 0);
		}
		rectTransform.sizeDelta = new Vector2 (0.8f * Screen.width/2, 0.8f * Screen.height);

		buttons.Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		button.image.color = button.colors.normalColor;
		if ((mode == 0 && Input.mousePosition.x < Screen.width/2) || (mode == 1 && Input.mousePosition.x > Screen.width/2)) {
			button.image.color = button.colors.highlightedColor;
		}
	}
}
