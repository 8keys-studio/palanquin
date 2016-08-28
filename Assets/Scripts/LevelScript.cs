//PURPOSE: add to GameObject of each level to handle necessary functions needed for game as a whole.

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Scene currentScene = SceneManager.GetActiveScene();
		GlobalControl.Instance.lastLevel = currentScene.buildIndex;
		Debug.Log("The last level loaded is: Level" +  GlobalControl.Instance.lastLevel);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
