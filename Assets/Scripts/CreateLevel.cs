﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateLevel : MonoBehaviour {

	static Transform[] types;
	public Transform green;
	public Transform red;
	public Transform Platform;
	public Transform bg;

	public static Transform background;

    private static AudioSource levelSource;
	private static AudioSource levelSourceFail;

	static int level = -1;

	// Use this for initialization
	void Start () {
        levelSource = GetComponents<AudioSource>()[0];
		levelSourceFail = GetComponents<AudioSource>()[1];
		types = new Transform[] { Platform, Platform, red, green };
		background = bg;
		NextLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void NextLevel (){
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable")) {
			Destroy (obj);
		}
        levelSource.Play();
		level++;
		Green.num = 0;
		Setup ("level" + level.ToString ());
	}

	public static void ResetLevel() {
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable")) {
			Destroy (obj);
		}
		levelSourceFail.Play();
		Setup ("level" + level.ToString ());
		Green.num = 0;
	}

	static void Setup(string levelName) {
		var sr = new StreamReader(Application.dataPath+"/Tilemaps/"+levelName+".csv");

		string imageFile = sr.ReadLine ();
		Texture image = Resources.Load("images/"+imageFile/*+".jpg"*/) as Texture;
		//print (image);
		background.GetComponent<Renderer> ().material.mainTexture = image;
		Physics.gravity = float.Parse (sr.ReadLine()) * Vector3.down;

		float y = 0;
		string line;
		char[] delims = new char[] { ',' };
		while ((line=sr.ReadLine())!=null) {
			float x = 0;
			string[] positions = line.Split (delims, System.StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < positions.Length; i++) {
				if(positions[i]!="-1"){
					Instantiate( types[int.Parse(positions[i])], new Vector3(x,y+30f,0), Quaternion.identity );
				}
				x+=1;
			}
			y-=1;
		}
	}
}
