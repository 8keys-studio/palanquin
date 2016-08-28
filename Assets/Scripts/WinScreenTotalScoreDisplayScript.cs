using UnityEngine;
using System.Collections;

public class WinScreenTotalScoreDisplayScript : MonoBehaviour {

	private int totalScore;
	private GUIText scoreDisplay;

	// Use this for initialization
	void Start () {

		scoreDisplay = gameObject.GetComponent<GUIText>();;

		try
		{
			totalScore = GlobalControl.Instance.globalScore;
			scoreDisplay.text = "SCORE: " + totalScore;
		}
		catch (System.NullReferenceException ex)
		{
			scoreDisplay.text = "NO TOTAL SCORE \r\n (how did you get to this screen?)";
			Debug.Log(ex.Message);
		}


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
