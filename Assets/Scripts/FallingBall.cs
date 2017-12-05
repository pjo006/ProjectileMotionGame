using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingBall : MonoBehaviour {

	Vector3 startPos;
	Vector3 velocity;
	public float gravityValue;
	Vector3 gravity;

	static List<FallingBall> fallingBalls = new List<FallingBall> ();

	// Use this for initialization
	void OnEnable () {
		startPos = transform.position; // get the initial position
		velocity = Vector3.zero;
		if (gravityValue >= 0) {
			gravity = -gravityValue * Vector3.up; // set  gravity if necessary
		} else {
			gravity = Physics.gravity;
		}

		fallingBalls.Add (this); // add this to the list of falling balls
	}


	void OnDisable() {
		fallingBalls.Remove (this); // remove this if it is disabled
	}
	
	// Update is called once per frame
	void Update () {
		velocity += Time.deltaTime * gravity; // manually update velocity and position to avoid needing RigidBody
		transform.position += Time.deltaTime * velocity;
	}

	public void Reset () {
		transform.position = startPos; //set the position to where it started
		velocity = Vector3.zero;
		if (gravityValue < 0) { // reset gravity if necessary
			gravity = Physics.gravity;
		}
	}

	public static void ResetAll () {
		foreach (FallingBall fallingBall in fallingBalls) {
			fallingBall.Reset (); // reset all falling balls
		}
	}
}
