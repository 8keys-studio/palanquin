using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
/// 



public class MenuScript : MonoBehaviour
{

	public string firstLevelName = "";
	public AudioClip startSound;
	AudioSource audio_player;

	void OnGUI()
	{
		audio_player = GetComponent<AudioSource>();


		int buttonWidth = Screen.width / 12;
		int buttonHeight = Screen.height / 10;

		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			(buttonWidth * 9),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		);

		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!") || Input.GetButtonDown("Submit")) //click button or press Return - for testing purposes
		{

			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			audio_player.PlayOneShot(startSound, 0.7F);
			Invoke("LoadLevel", 1);

		}
	}

	void LoadLevel() {
		Application.LoadLevel(firstLevelName);
	}

}
