using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public Transform Block;

	// Use this for initialization
	void Start () {
		float width = transform.localScale.x;
		for (float i = 0; i < width; i++) {
			for (float j = 1; j < width - i; j++) {
				Instantiate (Block, transform.position + (i + 1.5f) * Vector3.up + (j+0.5f*i - width/2) * Vector3.right, Quaternion.identity);
	
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
