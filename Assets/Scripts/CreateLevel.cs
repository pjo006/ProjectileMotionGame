using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateLevel : MonoBehaviour {

	static Transform[] types;
	public Transform Green;
	public Transform Red;
	public Transform Platform;

	static int level = -1;

	// Use this for initialization
	void Start () {
		types = new Transform[] { Platform, Platform, Red, Green };
		NextLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void NextLevel (){
		Debug.Log (Object.FindObjectsOfType<Destroyable> ());
		Debug.Log (Object.FindObjectsOfType<Destroyable> ().Length);
		foreach(Destroyable obj in Object.FindObjectsOfType<Destroyable> ()) {
			Debug.Log (obj.GetComponent<GameObject>());
			Destroy (obj.GetComponent<GameObject>());
		}
		level++;
		Setup ("level" + level.ToString ());
	}

	static void Setup(string levelName) {
		var sr = new StreamReader(Application.dataPath+"/Tilemaps/"+levelName+".csv");
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
