using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

	const float THRESHOLD = 1f;

	Vector3 lastVelocity;
	public AudioClip cannonSound;
	private AudioSource source;

	private void Awake()
	{
		//source = GetComponent<AudioSource>();
		//lastVelocity = rigidbody.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		/*float acceleration = (rigidbody.velocity - lastVelocity).magnitude () / Time.deltaTime
			- (Physics.gravity / rigidbody.mass);
		lastVelocity = rigidbody.velocity;
		}*/
	}

}
