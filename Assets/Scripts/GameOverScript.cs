using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Restart the level or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
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
		if (
			GUI.Button(
				// Center in X, 1/3 of the height in Y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(1 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"Retry!"
			)
		)
		{
			// Reload the level
			//Application.LoadLevel(retryStage);
//			SceneManager.LoadScene(GlobalControl.Instance.lastLevel, LoadSceneMode.Single);
			audio_player.Stop();
			audio_player.PlayOneShot(startSound, 0.7F);
			try
			{
				float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
				Debug.Log(fadeTime);
				Invoke("LoadLastLevel", fadeTime);
			}
			catch (System.NullReferenceException ex)
			{
				Debug.Log(ex.Message);
				LoadLastLevel();
			}

		}

		if (
			GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(2 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"Back to menu"
			)
		)
		{
			// Clear the global score
			try
			{
				GlobalControl.Instance.globalScore = 0;
			}
			catch (System.NullReferenceException ex)
			{
				Debug.Log(ex.Message);
			}

			// Back to start screen
			//Application.LoadLevel(startMenu);
//			SceneManager.LoadScene(startMenu, LoadSceneMode.Single);
			audio_player.Stop();
			audio_player.PlayOneShot(startSound, 0.7F);
			try
			{
				float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
				Debug.Log(fadeTime);
				Invoke("LoadStartMenu", fadeTime);
			}
			catch (System.NullReferenceException ex)
			{
				Debug.Log(ex.Message);
				LoadStartMenu();
			}

		}
	}

	void LoadLastLevel() {
		//Application.LoadLevel(firstLevelName);
		Debug.Log("Got to LoadLastLevel coroutine.");
		try
		{
			SceneManager.LoadScene(GlobalControl.Instance.lastLevel, LoadSceneMode.Single);
		}
		catch (System.NullReferenceException ex)
		{
			Debug.Log(ex.Message);
		}
	}

	void LoadStartMenu() {
		//Application.LoadLevel(firstLevelName);
		Debug.Log("Got to LoadStartMenu coroutine.");
		SceneManager.LoadScene(startMenu, LoadSceneMode.Single);
	}
}