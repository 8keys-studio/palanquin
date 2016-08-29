using UnityEngine;
using System.Collections;

public class Player1Script2TEST : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	public double maxJumpHeight = 0.5;
	public double currentHeight = 0;
	public bool jumped = false;
	public float inputY = -1;
	public bool lWheelGrounded;
	public float jumpspeed = 150f;
	private Rigidbody2D rb2d;

	public int jumpTimer;

//	private int buttonDownCounter = 0;
//	private float jumpButtonHeld = 0.0f;
//	private float testJump = 0.0f;

	//add canJump bool
	//add moveLeft bool
	//add moveRight bool


	// store the movement
	//private Vector2 movement;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		// retrieve axis info
		float inputX = Input.GetAxis("HorizontalP1");

		/*
		if (GameObject.Find("leftWheel").GetComponent<leftWheelScript>().Lgrounded == true){
			lWheelGrounded = true;
		}
		*/

		//lWheelGrounded = GameObject.Find ("leftWheel").GetComponent<leftWheelScript> ().Lgrounded;
		if (GetComponentInParent<CharacterController>().isGrounded == true)	{
			lWheelGrounded = true;
		}

		//--- static jump code ---

		if ((Input.GetButtonDown ("JumpP1")) && (lWheelGrounded == true)) {
			Debug.Log ("L1 Jumped: " + lWheelGrounded);
			jumped = true;
			//rb2d.AddForce(Vector2.up * jumpspeed);

			//invoke jump reset timer
			Invoke("resetJump", jumpTimer);

		}

	}

	void resetJump(){
	
		jumped = false;

	}

}
