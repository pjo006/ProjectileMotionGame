using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public Transform Ball;

	const float ANGLE_SCALE = -0.2f;
	const float VELOCITY_SCALE = 0.1f;

	const float FORWARD = 3f;

	private float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		angle = Mathf.Deg2Rad * GetAngle ();
		transform.rotation = Quaternion.Euler(Mathf.Rad2Deg*(angle + 0.35f), 90f, 0f);
		if(Input.GetMouseButtonDown(0)) {
			Vector3 dir = new Vector3(Mathf.Cos(-angle), Mathf.Sin(-angle), 0f);
			Transform newBall = Instantiate(Ball, Vector3.zero + FORWARD * dir, Quaternion.identity);
			newBall.GetComponent<Rigidbody> ().velocity = GetVelocity () * dir;
		}
	}

	float GetAngle() {
		return ANGLE_SCALE * Input.mousePosition.y;
	}
	float GetVelocity() {
		return VELOCITY_SCALE * Input.mousePosition.x;
	}

}
