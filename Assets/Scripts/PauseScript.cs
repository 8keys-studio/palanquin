using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<SpriteRenderer>().enabled = false;


	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				AudioListener.pause = true;
				GetComponent<SpriteRenderer>().enabled = true;
			}
			else
			{
				Time.timeScale = 1;
				AudioListener.pause = false;
				GetComponent<SpriteRenderer>().enabled = false;
			}
		}

	}
}