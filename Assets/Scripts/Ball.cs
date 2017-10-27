using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public static int num = 0;
	public AudioClip greenHitSound;
	public AudioClip redHitSound;
	public AudioClip platformHitSound;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		num++;
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Green(Clone)") {
			source.PlayOneShot(greenHitSound, 1.0f);
		}
		else if (collision.gameObject.name == "Red(Clone)") {
			source.PlayOneShot(redHitSound, 1.0f);
		}
		else if (collision.gameObject.name == "Platform(Clone)") {
			source.PlayOneShot(platformHitSound, 1.0f);
		}

	}

	void OnDestroy () {
		num--;
	}
}
