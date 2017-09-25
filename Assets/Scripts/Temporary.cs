using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	float MAP_BOTTOM = -0f;

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
