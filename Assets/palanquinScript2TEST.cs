using UnityEngine;
using System.Collections;

public class palanquinScript2TEST : MonoBehaviour {

	//********NOTES**********:
	// - May need to move some individual checks (angle, speed) to character objs, or else create bools for each condition based
	//   on fare type

	//public Vector2 speed = new Vector2(50, 50);
	public float speed = 6.0f;
	private Vector2 movement;
	public float jumpspeed = 8.0f;
	public float gravity = 20.0f;
	public bool grounded;


	public GameObject leftWheel;
	public GameObject rightWheel;

//	public bool Lgrounded;
//	public bool Rgrounded;

	//private float baseInputSpeed;

	public float palSpeed; //speed of pal
	public float hitSpeed; //speed cap of fare character
	public int jumpForceInt;
	private Vector2 moveDirection = Vector2.zero;

	public bool stunCollide; // stunned by collision?
	public bool stunSpeed; //stunned by speeding?
	public bool stunRotation; //stunned by rotation?

	public int rotationStunTime; //amount of time stun invulnerability lasts
	public int speedStunTime;
	public int collideStunTime;

	public int fareAmount; //the current/displayed fare
	public int fareHitAmount; //the # fare is reduced by when pal takes a hit

	public GUIText fareText; //create GUI to display total fare

	private Rigidbody2D rb;
	public GameObject movementObj; //attach movement script's prefab obj
	public Vector3 com;

	public int xRotationLimit = 20;
	public int yRotationLimit = 20;
	public int zRotationLimit = 20;

	private Vector3 leftWheelPos;
	private Vector3 rightWheelPos;



	// Use this for initialization
	void Start () {
		//UpdateFare (); 
		stunCollide = false;
		stunSpeed = false;
		stunRotation = false;
		//rb = GetComponent<Rigidbody2D>();
		//rb.centerOfMass = com;

		leftWheelPos = leftWheel.transform.position;
		rightWheelPos = rightWheel.transform.position;
	}

	// Update is called once per frame
	void Update () {



		// check for angles
		if (transform.rotation.eulerAngles.y > 90) //make # variable (change per character), confirm axis is correct. make || condition?
			//Debug.Log(transform.eulerAngles.y); //testing
		{
			fareAmount = fareAmount - fareHitAmount;
			UpdateFare ();
			stunRotation = true;
			Invoke("resetColliderRotation", rotationStunTime);

		}

		// check for speed
		if (palSpeed > hitSpeed) //make # variable (change per character), confirm axis is correct. make || condition?
			//Debug.Log(transform.eulerAngles.y); //testing
		{
			fareAmount = fareAmount - fareHitAmount;
			UpdateFare ();
			stunSpeed = true;
			Invoke("resetColliderSpeed", speedStunTime);

		}

		if(transform.rotation.eulerAngles.x > xRotationLimit){ //fix this so it doesn't suddenly reset to zero (try local rotation?)
			transform.rotation = Quaternion.identity;
		}

		if(transform.rotation.eulerAngles.y > yRotationLimit){
			transform.rotation = Quaternion.identity;
		}

		if(transform.rotation.eulerAngles.z > zRotationLimit){
			transform.rotation = Quaternion.identity;
		}
	}

	void Movement (){

		CharacterController controller = GetComponent<CharacterController>();


//		Vector3 vel = rb.velocity; 
//		palSpeed = vel.magnitude;  
		float palVel = movementObj.GetComponent<movementScript2TEST>().palVel; // pull in global value via movement script 
		//baseInputSpeed = Input.GetAxis("HorizontalP1");
		//movement = new Vector2(speed.x * palVel, rb.velocity.y);

		if (grounded = true) {
			movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			movement = transform.TransformDirection (movement);
			movement *= speed; //palVel

			movement.y -= gravity * Time.deltaTime;
			controller.Move (movement * Time.deltaTime);
		}
	}
		

	void Jump(){


	
		if (movementObj.GetComponent<movementScript2TEST>().leftJumped == true){
				//rb.AddForce(Vector2.up * jumpspeed); //on LEFT side of Pal
			//rb.velocity = new Vector2(0,1) * jumpForceInt;
			                moveDirection.y = jumpspeed;

			//rb.AddForceAtPosition(new Vector2(0,jumpForceInt), leftWheelPos, ForceMode2D.Impulse); 
			movementObj.GetComponent<movementScript2TEST> ().leftJumped = false;
			Debug.Log ("final jump L firing" + leftWheelPos);
		}		

		if (movementObj.GetComponent<movementScript2TEST>().rightJumped == true){
			//rb.AddForce(Vector2.up * jumpspeed); //on RIGHT side of Pal
			moveDirection.y = jumpspeed;

			//rb.velocity = new Vector2(0,1) * jumpForceInt;
			//rb.AddForceAtPosition(new Vector2(0,jumpForceInt), rightWheelPos, ForceMode2D.Impulse);
			movementObj.GetComponent<movementScript2TEST> ().rightJumped = false;
			Debug.Log ("final jump R firing" + rightWheelPos);
		}	

	}

	void OnTriggerEnter (Collider other) { //if pal hits a tagged obstacle, score is reduced
		if (other.tag == "Obstacle" && stunCollide == false)
		{
			fareAmount = fareAmount - fareHitAmount;
			UpdateFare ();
			//**ADD invulnerability animation state
			stunCollide = true;
			Invoke("resetColliderStun", collideStunTime);
		}
	}

		void OnTriggerStay2d(Collider2D other){
			if (other.tag == ("ground"))
			{
				//Debug.Log("R1 Grounded");
	
				grounded = true;
			}
		}

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

	void UpdateFare () //display current fare value via GUI
	{
		//fareText.text = "Fare: " + fareAmount;
	}

	void resetColliderStun()
	{
		stunCollide = false;
	}

	void resetColliderSpeed()
	{
		stunSpeed = false;
	}

	void resetColliderRotation()
	{
		stunRotation = false;
	}

	void FixedUpdate()
	{
		//move the game object
		//rb.velocity= movement;
		Movement ();
		Jump ();

	}



}