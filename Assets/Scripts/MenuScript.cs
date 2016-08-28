using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
/// 



public class MenuScript : MonoBehaviour
{

	public string firstLevelName = "";

	void OnGUI()
	{


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
		if(GUI.Button(buttonRect,"Start!"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel(firstLevelName);
		}
	}
}
