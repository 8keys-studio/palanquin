using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Restart the level or quit the game
/// </summary>
public class WinScreenScript : MonoBehaviour
{
	public string retryStage = "scene1";
	public string startMenu = "StartMenu";
	public AudioClip startSound;
//	public AudioClip gameoverMusic;
	AudioSource audio_player;


	void OnGUI()
	{
		audio_player = GetComponent<AudioSource>();
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
			Debug.Log("Got here.");
			// Clear the global score
			try 
			{
				GlobalControl.Instance.globalScore = 0;
			}
			catch (System.NullReferenceException ex)
			{
				Debug.Log(ex.Message);
			}

			audio_player.Stop();
			audio_player.PlayOneShot(startSound, 0.7F);
			Debug.Log("Break point 1.");
			float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
			Debug.Log(fadeTime);
			Invoke("LoadLevel", fadeTime);
			// Back to start screen
			//Application.LoadLevel(startMenu);

		}
	}

	void LoadLevel() {
		//Application.LoadLevel(firstLevelName);
		Debug.Log("Got to coroutine.");
		SceneManager.LoadScene(startMenu, LoadSceneMode.Single);
	}
}