using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	float MAP_BOTTOM = -20f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y < MAP_BOTTOM) {
			Destroy (gameObject);
		}
	}
}
