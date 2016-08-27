using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	public double maxJumpHeight = 0.5;
	public double currentHeight = 0;
	public bool jumped = false;
	public float inputY = -1;
	public bool grounded;
	public float jumpspeed = 150f;
	private Rigidbody2D rb2d;


	// store the movement
	private Vector2 movement;

	// Use this for initialization
	void Start () {

		rb2d = gameObject.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

		// retrieve axis info
		float inputX = Input.GetAxis("Horizontal");
		//float inputY = Input.GetAxis("Vertical"); - no free vertical movement in a platformer

		//if(grounded == false)
			//inputY = -1;

		if((Input.GetButtonDown("Jump")) && (grounded == true))
		{
			rb2d.AddForce(Vector2.up * jumpspeed);


				//double playerGrounded = transform.position.y;
				//inputY = 1;
			//grounded = false;
		}
			

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
