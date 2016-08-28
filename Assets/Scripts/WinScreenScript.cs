﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Restart the level or quit the game
/// </summary>
public class WinScreenScript : MonoBehaviour
{
	public string retryStage = "scene1";
	public string startMenu = "StartMenu";


	void OnGUI()
	{

		int buttonWidth = new int();
		int buttonHeight = new int();

		if (((Screen.width / 12) > 120) && ((Screen.height / 10) > 60))
		{
			buttonWidth = Screen.width / 12;
			buttonHeight = Screen.height / 10;
		}
		else
		{
			buttonWidth = 120;
			buttonHeight = 60;
		}
//		if (
//			GUI.Button(
//				// Center in X, 1/3 of the height in Y
//				new Rect(
//					Screen.width / 2 - (buttonWidth / 2),
//					(1 * Screen.height / 3) - (buttonHeight / 2),
//					buttonWidth,
//					buttonHeight
//				),
//				"Retry!"
//			)
//		)
//		{
//			// Reload the level
//			//Application.LoadLevel(retryStage);
//			SceneManager.LoadScene(GlobalControl.Instance.lastLevel, LoadSceneMode.Single);
//		}

		if (
			GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(2 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"Back to Start"
			)
		)
		{
			// Clear the global score
			GlobalControl.Instance.globalScore = 0;
			// Back to start screen
			//Application.LoadLevel(startMenu);
			SceneManager.LoadScene(startMenu, LoadSceneMode.Single);
		}
	}
}