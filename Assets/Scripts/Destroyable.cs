using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	float MAP_TOP = 30f;
	float MAP_BOTTOM = -5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(!ControlUtility.insidePlayArea(transform.position)) {
			Destroy (gameObject);
		}
	}
}
