using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FareGoal : MonoBehaviour
{

	private Rigidbody2D rb;
	private AudioSource audio_player;
	public AudioClip goalSound;
	private bool firstTime = true;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		audio_player = GetComponent<AudioSource>();
	}
		
	// Update is called once per frame
	void Update ()
	{
	}

	//void OnCollisionEnter2D(Collision2D other){
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("goal"))
		{

			if (firstTime){
				Debug.Log("Goal Reached");
				firstTime = false;
				audio_player.PlayOneShot(goalSound, 0.7F);
				Debug.Log("Audiowhore sucking on sound.");
				try {
					float fadeTime = GameObject.Find("GlobalController").GetComponent<FaderScript>().BeginFade(1);
					Debug.Log(fadeTime);
					Invoke("GoalReached", fadeTime);
				}
				catch (System.NullReferenceException ex)
				{
					Debug.Log(ex.Message);
					Invoke("GoalReached", 2);
				}
			}
		}
	}

		void GoalReached ()
		{
			SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
		}
	
	}


