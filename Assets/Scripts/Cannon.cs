using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public Transform Ball;

	const float ANGLE_SCALE = 0.004f;
	const float VELOCITY_SCALE = 0.1f;

	private float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		angle = GetAngle ();
		transform.rotation = Quaternion.Euler (0f, 0f, Mathf.Rad2Deg * angle + 90);
		if(Input.GetMouseButtonDown(0)) {
			Transform newBall = Instantiate(Ball, Vector3.zero, Quaternion.identity);
			newBall.GetComponent<Rigidbody> ().velocity = GetVelocity() * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);
		}
	}

	float GetAngle() {
		return ANGLE_SCALE * Input.mousePosition.y;
	}
	float GetVelocity() {
		return VELOCITY_SCALE * Input.mousePosition.x;
	}

}
