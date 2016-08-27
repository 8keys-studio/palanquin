using UnityEngine;
using System.Collections;

public class Player4Script : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	public double maxJumpHeight = 0.5;
	public double currentHeight = 0;
	public bool jumped = false;
	public float inputY = -1;
	public bool grounded;
	public float jumpspeed = 150f;
	private Rigidbody2D rb2d;
	private int buttonDownCounter = 0;
	private float jumpButtonHeld = 0.0f;
	private float testJump = 0.0f;


	// store the movement
	private Vector2 movement;

	// Use this for initialization
	void Start () {

		rb2d = gameObject.GetComponent<Rigidbody2D>();

	
	}
	
	// Update is called once per frame
	void Update () {

		// retrieve axis info
		float inputX = Input.GetAxis("HorizontalP4");

		//--- static jump code ---
		if((Input.GetButtonDown("JumpP4")) && (grounded == true))
		{

			jumped = true;
			rb2d.AddForce(Vector2.up * jumpspeed);


		}
//  --- testing for jump acceleration ---
//		if((Input.GetButton("Jump")) && jumped)
//		{
//			buttonDownCounter++;
//			jumpButtonHeld += Time.deltaTime;
//
//		}
//
//		if (jumped)
//		{
//
//			Debug.Log("If jumped");
//			testJump = (jumpspeed * jumpButtonHeld) * 2;
//			//testJump = buttonDownCounter;
//
//			if(testJump < 120)
//			{
//				Debug.Log("Got to the while loop.");
//				rb2d.AddForce(Vector2.up * testJump);
//			}
//			
//		}
//
//		if(Input.GetButtonUp("Jump"))
//		{
//			//Debug.Log("buttonDownCounter =" + buttonDownCounter);
//			Debug.Log("jumpButtonHeld =" + jumpButtonHeld);
//			jumpButtonHeld = 0.0f;
//			jumped = false;
//			testJump = 0.0f;
//		}
// --- jump acceleration block end --- 
			

		// movement per direction
		//movement = new Vector2(
		//	speed.x * inputX,
		//	speed.y * inputY);
		movement = new Vector2(speed.x * inputX, rb2d.velocity.y);

			
	
	}

	void OnTriggerStay2d(Collider2D other){
		if (other.tag == ("ground"))
		{
			grounded = true;
		}
	}

//	void OnCollisionEnter2D(Collision2D collision){
	
//		if (collision.tag == ("ground"))
//		{
//			grounded = true;
//		}
//	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("ground")) {
			grounded = true;
		}
	}
		

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.CompareTag("ground")) {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.CompareTag("ground")) {
			grounded = false;
		}
	}

	void FixedUpdate()
	{
		//move the game object
		rb2d.velocity= movement;

	}
}
