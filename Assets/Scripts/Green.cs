using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour {

	public static int num = 0;
	float MAP_BOTTOM = -5f;

	// Use this for initialization
	void Start () {
		num++;
	}
	
	// Update is called once per frame
	void Update () {
		if(!ControlUtility.insidePlayArea(transform.position)) {
			num--;
			if(num<=0) {
				CreateLevel.NextLevel ();
			}
			Destroy (gameObject);
		}
	}
}
