using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(!ControlUtility.insidePlayArea(transform.position)) {
			CreateLevel.ResetLevel (); // reset a level if any reds exit the area
			Destroy (gameObject);
		}
	}
}

