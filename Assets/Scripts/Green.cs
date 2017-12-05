using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour {

	public static int num = 0;

	// Use this for initialization
	void Start () {
		num++; // this is one more green block
	}
	
	// Update is called once per frame
	void Update () {
		if(!ControlUtility.insidePlayArea(transform.position)) {
			num--;
			if(num<=0) { // if no more greens, you completed the level
				CreateLevel.NextLevel ();
			}
			Destroy (gameObject); // destroy onesself
		}
	}
}
