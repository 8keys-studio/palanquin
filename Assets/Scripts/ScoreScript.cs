using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	private int levelScore;
	private int totalScore;
	private GUIText scoreDisplay;

	// Use this for initialization
	void Start () {

		scoreDisplay = gameObject.GetComponent<GUIText>();
		totalScore = GlobalControl.Instance.globalScore;
		levelScore = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (levelScore < 1000000)
		{
			addToScore(11);
		}
		
	}

	void addToScore (int addition) {
	
		levelScore += addition;
		scoreDisplay.text = "SCORE: " + levelScore;

	}
}
