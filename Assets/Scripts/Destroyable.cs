using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(!ControlUtility.insidePlayArea(transform.position)) { // Destory if out of play area
			Destroy (gameObject);
		}
	}
}
