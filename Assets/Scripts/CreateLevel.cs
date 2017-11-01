using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateLevel : MonoBehaviour {

	static Transform[] types;
	public Transform green;
	public Transform red;
	public Transform Platform;
	public Transform bg;

	static Texture2D image;

	public static Transform background;

    private static AudioSource levelSource;
	private static AudioSource levelSourceFail;

	public static int NUM_LEVELS = 9;

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
		if(Input.GetKeyDown(KeyCode.R)) {
			ResetLevel ();
		}
	}

	public static void NextLevel (){
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable")) {
			Destroy (obj);
		}
        levelSource.Play();
		level = (level+1) % NUM_LEVELS;
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
		var text = Resources.Load<TextAsset>("tilemaps/csv/"+levelName) as TextAsset;

		string[] lines = text.text.Split (new char[]{ '\n' });

		string imageFile = lines [0];
		print ('"'+imageFile+'"');
		image = Resources.Load<Texture2D>("images/"+imageFile) as Texture2D;
		print (image);
		//image = Resources.Load("images/jupiter") as Texture;
		//print (image);
		background.GetComponent<Renderer> ().material.mainTexture = image;

		image = Resources.Load<Texture2D>("images/"+imageFile) as Texture2D;
		print (image);

		Physics.gravity = float.Parse (lines [1]) * Vector3.down;

		float y = 0;
		string line;
		char[] delims = new char[] { ',' };
		for (int j=2; j<lines.Length; j++) {
			line = lines[j];
			float x = 0;
			int blockType;
			string[] positions = line.Split (delims, System.StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < positions.Length; i++) {
				blockType = int.Parse (positions [i]);
				if(blockType >= 0){
					Instantiate( types[blockType], new Vector3(x,y+30f,0), Quaternion.identity );
				}
				x+=1;
			}
			y-=1;
		}
	}
}
