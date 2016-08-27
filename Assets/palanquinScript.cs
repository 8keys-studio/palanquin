using UnityEngine;
using System.Collections;

public class palanquinScript : MonoBehaviour {

	//********NOTES**********:
	// - May need to move some individual checks (angle, speed) to character objs, or else create bools for each condition based
	//   on fare type

	public int fareAmount; //the current/displayed fare
	public int fareHitAmount; //the # fare is reduced by when pal takes a hit

	public GUIText fareText; //create GUI to display total fare

	// Use this for initialization
	void Start () {
		fareAmount = 10; //make this a pass through variable read by picked up fare
		UpdateFare ();
	}

	// Update is called once per frame
	void Update () {

		// check for angles
		if (transform.rotation.eulerAngles.y > 90) //make # variable (change per character), confirm axis is correct. make || condition?
			//Debug.Log(transform.eulerAngles.y); //testing
		{
			fareAmount = fareAmount - fareHitAmount;
			UpdateFare ();
		}

		// check for speed

	}

	void OnTriggerEnter (Collider other) { //if pal hits a tagged obstacle, score is reduced
		if (other.tag == "Obstacle")
		{
			fareAmount = fareAmount - fareHitAmount;
			UpdateFare ();
		}
	}

	void UpdateFare () //display current fare value
	{
		fareText.text = "Fare: " + fareAmount;
	}


}

