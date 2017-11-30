using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CreateLevel : MonoBehaviour {

	static Transform[] types;
	public Transform green;
	public Transform red;
	public Transform Platform;
	public Transform bg;

	public static int mode = -1;

	public List<string> textureNames;
	public List<Texture2D> textures;

	public static List<string> statTextureNames;
	public static List<Texture2D> statTextures;

	public Texture2D startBackgroundImage;

	public List<GameObject> neededForGame;
	public static List<GameObject> statNeededForGame;

	static Texture2D image;

	public static Transform background;

    private static AudioSource levelSource;
	private static AudioSource levelSourceFail;
	private static bool holding;
	private static float timer = 0f;
	private static float maxTime = 1.6f;

	public static int NUM_LEVELS = 18;

	static int level = -1;

	// Use this for initialization
	void Start () {
		statTextureNames = textureNames;
		statTextures = textures;
		statNeededForGame = neededForGame;

		holding = false;
		Cursor.visible = false;
        levelSource = GetComponents<AudioSource>()[0];
		levelSourceFail = GetComponents<AudioSource>()[1];
		types = new Transform[] { Platform, Platform, red, green };
		background = bg;
		background.GetComponent<Renderer> ().material.mainTexture = startBackgroundImage;
		//NextLevel();


	}

	void StartGame () {
		mode = (Input.mousePosition.x < Screen.width / 2) ? 0 : 1;
		foreach (GameObject obj in statNeededForGame) {
			obj.SetActive (true);
		}
		foreach (GameObject obj in StartButton.buttons) {
			obj.SetActive (false);
		}
		NextLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)) {
			ResetLevel ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			level = 0;
			ResetLevel ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			NextLevel ();
		}
		if (mode == -1 && Input.GetMouseButtonDown (0)) {
			StartGame();
		}
		if (holding == true) {
			timer += Time.deltaTime;
			//print (timer.ToString ());
			if (timer >= maxTime) {
				LevelComplete.hideLevelComplete ();
				Setup ("level" + level.ToString ());
				holding = false;
			}
		}
	}

	public static void NextLevel (){
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable")) {
			Destroy (obj);
		}
		//print ("In NextLevel");
        levelSource.Play();
		level = (level+1) % NUM_LEVELS;
		Green.num = 0;
		if (level == 0) {
			Setup ("level" + level.ToString ());
		} else {
			LevelComplete.showLevelComplete ();
			timer = 0f;
			holding = true;
		}
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
		LevelText.setLevelText (imageFile);
		image = statTextures[statTextureNames.FindIndex(x => x.CompareTo(imageFile.Trim())==0)];
		//print (image);
		//image = Resources.Load("images/jupiter") as Texture;
		//print (image);
		background.GetComponent<Renderer> ().material.mainTexture = image;

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

		FallingBall.ResetAll ();
	}
}
