using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SuicideButtonScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.A))
		{
			float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
			Debug.Log(fadeTime);
			Invoke("Suicide", fadeTime);
		}

		if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.X) && Input.GetKeyDown(KeyCode.S))
		{
			float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
			Debug.Log(fadeTime);
			Invoke("InstantWin", fadeTime);
		}
	}

	void Suicide () {
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}

	void InstantWin () {
		SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
	}
}
