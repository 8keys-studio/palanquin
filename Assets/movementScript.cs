using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	//****NOTES - might need to rearrange which player is which

	public GameObject l1;
	public GameObject l2;
	public GameObject r1;
	public GameObject r2;

	public bool lGrounded; 
	public bool rGrounded; 

	private float leftPalPos;
	private float rightPalPos;

	public bool leftJumped = false; //add timers to player scripts?
	public bool rightJumped = false;

	public float palVel; // pal's velocity


	// Use this for initialization
	void Start () {


		// call pal left y transform - moved from Update?
		// call pal right y transform

	}
	
	// Update is called once per frame
	void Update () {




//		Transform l1Position = l1.GetComponent<Transform>();
//		Transform l2Position = l2.GetComponent<Transform>();
//		Transform r1Position = r1.GetComponent<Transform>();
//		Transform r2Position = r2.GetComponent<Transform>();

//		l1Position + l2Position == leftPalPos; //move this based on jump status?
//		r1Position + r2Position == rightPalPos; //change this to y value only?

		//define pal's transform rotation by #1 compared to #2
	}

	void FixedUpdate(){
		leftJump ();
		rightJump ();
	} 

	void leftJump ()
	{
		if (l1.GetComponent<Player1Script> ().jumped == true && l2.GetComponent<Player2Script> ().jumped == true) {
			// if both l hitting jump, left jumping. bool called by pal script?
			//add bool to all player scripts called canJump?
			Debug.Log ("leftJumped Start");
			leftJumped = true;
		} else {
			if (leftJumped == true) {
				leftJumped = false;
				Debug.Log ("leftJumped Reset");
			}
		}
	}

	void rightJump ()
	{
		if (r1.GetComponent<Player3Script> ().jumped == true && r2.GetComponent<Player4Script> ().jumped == true) {
			// if both l hitting jump, left jumping. bool called by pal script?
			//add bool to all player scripts called canJump?
			//
			Debug.Log ("rightJumped Start");
			rightJumped = true;
		} else {
			if (rightJumped == true) {
				rightJumped = false;
				Debug.Log ("rightJumped Reset");
			}
		}
		// if both r hitting jump, right jumping

	}

	void movement (){
		//if player moves right, add to velocity
		//calculate velocity based on combination of inputs

		//Player L1
		if (Input.GetAxis("HorizontalP1") > 0){
			// add vel
			Debug.Log("L1 Right");
		}

		if (Input.GetAxis("HorizontalP1") < 0){
			// reduce vel
			Debug.Log("L1 Left");
		} 

		//Player L2
		if (Input.GetAxis("HorizontalP2") > 0){
			// add vel
			Debug.Log("L2 Right");
		}

		if (Input.GetAxis("HorizontalP2") < 0){
			// reduce vel
			Debug.Log("L2 Left");

		} 

		//Plater R1
		if (Input.GetAxis("HorizontalP3") > 0){
			// add vel
			Debug.Log("R1 Right");
		}

		if (Input.GetAxis("HorizontalP3") < 0){
			// reduce vel
			Debug.Log("R1 Left");
		}

		//Plater R2
		if (Input.GetAxis("HorizontalP4") > 0){
			// add vel
			Debug.Log("R2 Right");
		}

		if (Input.GetAxis("HorizontalP4") < 0){
			// reduce vel
			Debug.Log("R2 Left");
		} 
	
	}
}
