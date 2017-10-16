using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public Transform ball;
    public AudioClip cannonSound;
	const float frrt = 1f;
	public float timer = 0f;

	public Vector3 top;

	public float FORWARD;

	private float angle;
    private AudioSource source;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		angle = Mathf.Deg2Rad * ControlUtility.GetAngle();
		transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Rad2Deg*(angle));
		if(Input.GetMouseButtonDown(0) && Ball.num<3 && timer<=0) {
            source.PlayOneShot(cannonSound, 1.0f);
			Vector3 dir = new Vector3(Mathf.Cos(-angle), Mathf.Sin(-angle), 0f);
			Transform newBall = Instantiate(ball, top + FORWARD * dir, Quaternion.identity);
			newBall.GetComponent<Rigidbody> ().velocity = ControlUtility.GetVelocity() * dir;
			timer = 1f / frrt;
		}
	}

}
