using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour {

	Vector3 startPos;
	Vector3 velocity;
	public float gravityValue;
	Vector3 gravity;

	static List<FallingBall> fallingBalls = new List<FallingBall>();

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		print (startPos);
		velocity = Vector3.zero;
		if (gravityValue >= 0) {
			gravity = -gravityValue * Vector3.up;
		} else {
			gravity = Physics.gravity;
		}

		fallingBalls.Add (this);
	}
	
	// Update is called once per frame
	void Update () {
		velocity += Time.deltaTime * gravity;
		transform.position += Time.deltaTime * velocity;
		//print (transform.position);
	}

	public void Reset () {
		transform.position = startPos;
		velocity = Vector3.zero;
		if (gravityValue < 0) {
			gravity = Physics.gravity;
		}
	}

	public static void ResetAll () {
		foreach (FallingBall fallingBall in fallingBalls) {
			fallingBall.Reset ();
		}
		print ("Reset");
	}
}
