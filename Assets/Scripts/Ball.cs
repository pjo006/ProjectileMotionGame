using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public static int num = 0;

	// Use this for initialization
	void Start () {
		num++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy () {
		num--;
	}
}
