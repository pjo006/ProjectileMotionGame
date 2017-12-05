using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public Transform ball;
    public AudioClip cannonSound;
	const float frrt = 1f; // one ball per second
	public float timer = 0f;

	public Vector3 top; // public vars set in editor

	public float FORWARD;

	private float angle;
    private AudioSource source;

	private LineRenderer line;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
		line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
	void Update () {
		timer -= Time.deltaTime; // count down shot timer
		angle = Mathf.Deg2Rad * ControlUtility.GetAngle(); // get the angle
		transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Rad2Deg*(angle)); // set the angle
		if(Input.GetMouseButtonDown(0) && timer<=0) { // if the fire button was pressed
            source.PlayOneShot(cannonSound, 1.0f); // play sound
			Vector3 dir = new Vector3(Mathf.Cos(-angle), Mathf.Sin(-angle), 0f); // set the direction
			Transform newBall = Instantiate(ball, top + FORWARD * dir, Quaternion.identity); // create the projectile
			newBall.GetComponent<Rigidbody> ().velocity = ControlUtility.GetVelocity() * dir; // set Physics velocity
			timer = 1f / frrt; // reset timer
		}
		float g = Physics.gravity.magnitude; // setup the vars for the predictive path equation
		float vx = -ControlUtility.GetVelocity() * Mathf.Cos(angle);
		float vy = ControlUtility.GetVelocity() * Mathf.Sin(angle);
		float x0 = top.x + FORWARD*Mathf.Cos(angle);
		float y0 = top.y - FORWARD*Mathf.Sin(angle);
		float x;
		float granularity = 0.1f; // set the equation step
		if (CreateLevel.mode == 0) {
			for (int i = 0; i < line.positionCount; i++) {
				x = granularity * i;
				line.SetPosition (i, new Vector3 (x, -0.5f * Physics.gravity.magnitude * (x - x0) * (x - x0) / (vx * vx) + vy * (x - x0) / vx + y0, 0f));
				// plot the point at position x
			}
		}
	}

}
