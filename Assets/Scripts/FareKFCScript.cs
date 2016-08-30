using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FareKFCScript : MonoBehaviour {

	private AudioSource audio_player;
	public AudioClip displeasedSound;
	private bool firstTime = true;

	// Use this for initialization
	void Start () {

		audio_player = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag("ground"))
		{
			if (firstTime){
				Debug.Log("King - OnCollisionEnter2D");
				firstTime = false;
				audio_player.PlayOneShot(displeasedSound, 0.7F);
				try {
					float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
					Debug.Log(fadeTime);
					Invoke("GameOver", fadeTime);
				}
				catch (System.NullReferenceException ex)
				{
					Debug.Log(ex.Message);
					Invoke("GameOver", 2);
				}
			}

		}



	}

	void GameOver()
	{
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}
}
