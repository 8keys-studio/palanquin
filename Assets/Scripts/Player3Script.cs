using UnityEngine;
using System.Collections;

public class Player3Script : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	public double maxJumpHeight = 0.5;
	public double currentHeight = 0;
	public bool jumped = false;
	public float inputY = -1;
	public bool rWheelGrounded;
	public float jumpspeed = 150f;
	private Rigidbody2D rb2d;

	public int jumpTimer;


//	private int buttonDownCounter = 0;
//	private float jumpButtonHeld = 0.0f;
//	private float testJump = 0.0f;


	// store the movement
	private Vector2 movement;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		// retrieve axis info
		float inputX = Input.GetAxis("HorizontalP3");

		/*
		if (GameObject.Find("rightWheel").GetComponent<rightWheelScript>().Rgrounded == true){
			rWheelGrounded = true;
		}
		*/

		rWheelGrounded = GameObject.Find ("rightWheel").GetComponent<rightWheelScript> ().Rgrounded == true;
			

		//--- static jump code ---
		if((Input.GetButtonDown("JumpP3")) && (rWheelGrounded == true))
		{
			Debug.Log("R1 Jumped");
			jumped = true;
			//rb2d.AddForce(Vector2.up * jumpspeed);
			Invoke("resetJump", jumpTimer);

		} 

	}
	void resetJump(){

		jumped = false;

	}
}