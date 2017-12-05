using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour {

	static Transform[] types; // converts Ogmo csv numbers to Unity transforms
	public Transform green;
	public Transform red;
	public Transform Platform;
	public Transform bg;

	public static int mode; // -1 for start screen, 0 for tutorial mode, 1 for advanced mode

	public List<string> textureNames; // list of planet names
	public List<Texture2D> textures; // list of planet textures

	public static List<string> statTextureNames; // static versions of the previous variables
	public static List<Texture2D> statTextures;

	public Texture2D startBackgroundImage; // background for the start screen

	public List<GameObject> neededForGame; // objects needing reenabling after start screen.
	public static List<GameObject> statNeededForGame; // a static version

	static Texture2D image; // current image

	public static Transform background;

    private static AudioSource levelSource;
	private static AudioSource levelSourceFail;
	private static bool holding;
	private static float timer;
	private static float maxTime;

	public static int NUM_LEVELS;

	static int level;

	// Use this for initialization
	void OnEnable () {
		mode = -1; // start at start screen
		timer = 0f;
		maxTime = 1.6f;

		NUM_LEVELS = 18;

		level = -1; // start so that first next level goes to level 0.

		statTextureNames = textureNames;
		statTextures = textures;
		statNeededForGame = neededForGame;

		holding = false;
		Cursor.visible = false; // don't show mouse on screen
        levelSource = GetComponents<AudioSource>()[0];
		levelSourceFail = GetComponents<AudioSource>()[1];
		types = new Transform[] { Platform, Platform, red, green };  // In ogmo, 0,1 are platform, 2 is red, 3 is green 
		background = bg;
		background.GetComponent<Renderer> ().material.mainTexture = startBackgroundImage;
		//NextLevel();


	}

	void StartGame () {
		mode = (Input.mousePosition.x < Screen.width / 2) ? 0 : 1;  //use ternary to get slider's selected mode
		foreach (GameObject obj in statNeededForGame) { // set all necessary objects to active
			obj.SetActive (true);
		}
		foreach (GameObject obj in StartButton.buttons) { // disable the buttons
			obj.SetActive (false);
		}
		NextLevel (); // start the first level
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)) {
			ResetLevel (); // reset on R (not mapped on controller)
		}
		if (Input.GetKeyDown (KeyCode.S)) { // restart game on S (mapped to blue button)
			mode = -1;
			Application.LoadLevel(0);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) { // quick cheat
			NextLevel ();
		}
		if (mode == -1 && Input.GetMouseButtonDown (0)) { //start game on button press
			StartGame();
		}
		if (holding == true) {
			timer += Time.deltaTime; // show level complete for all of timer
			if (timer >= maxTime) {
				LevelComplete.hideLevelComplete ();
				Setup ("level" + level.ToString ());
				holding = false;
			}
		}
	}

	public static void NextLevel (){
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable")) {
			Destroy (obj); // destroy all temporary objects
		}
		//print ("In NextLevel");
        levelSource.Play(); // play sound
		level = (level+1) % NUM_LEVELS; // modularly increment level
		Green.num = 0; // reset number of greens on screen
		if (level == 0) {
			Setup ("level" + level.ToString ()); // back to start
		} else {
			LevelComplete.showLevelComplete (); // run level complete sequence
			timer = 0f;
			holding = true;
		}
	}

	public static void ResetLevel() {
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable")) {
			Destroy (obj); // destroy all temporary objects
		}
		levelSourceFail.Play();
		Setup ("level" + level.ToString ()); // setup the next level
		Green.num = 0;
	}

	static void Setup(string levelName) {
		var text = Resources.Load<TextAsset>("tilemaps/csv/"+levelName) as TextAsset; // import csv info

		string[] lines = text.text.Split (new char[]{ '\n' }); // separate lines

		string imageFile = lines [0]; // get image name
		LevelText.setLevelText (imageFile); // set GUI level text
		PlanetText.setPlanetText (imageFile); // set GUI planet text
		GravText.setGravText (lines [1]); // set gravity numbers
		image = statTextures[statTextureNames.FindIndex(x => x.CompareTo(imageFile.Trim())==0)]; // find first texture matching the name
		background.GetComponent<Renderer> ().material.mainTexture = image; // set the background

		Physics.gravity = float.Parse (lines [1]) * Vector3.down; // set the game gravity

		float y = 0; // PARSE THE CSV FILE
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

		FallingBall.ResetAll (); // reset the example balls
	}
}
