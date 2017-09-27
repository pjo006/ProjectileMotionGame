using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour {

	public static int num = 0;

	// Use this for initialization
	void Start () {
		num++;
	}

	void OnDestroy () {
		num--;
		if(num<=0) {
			CreateLevel.NextLevel ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
