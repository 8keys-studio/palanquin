using UnityEngine;
using System.Collections;

public class palanquinScript : MonoBehaviour {

	//********NOTES**********:
	// - May need to move some individual checks (angle, speed) to character objs, or else create bools for each condition based
	//   on fare type

	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;
	public float jumpspeed;

	public GameObject leftWheel;
	public GameObject rightWheel;

//	public bool Lgrounded;
//	public bool Rgrounded;

	//private float baseInputSpeed;

	public float palSpeed; //speed of pal
	public float hitSpeed; //speed cap of fare character
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

	public int jumpForceInt;

	// Use this for initialization
	void Start () {
		UpdateFare (); 
		stunCollide = false;
		stunSpeed = false;
		stunRotation = false;
		rb = GetComponent<Rigidbody2D>();
		rb.centerOfMass = com;

		leftWheelPos = leftWheel.transform.position;
		rightWheelPos = rightWheel.transform.position;
	}

	// Update is called once per frame
	void Update () {

		float inputX = movementObj.GetComponent<movementScript>().palVel; // pull in global value via movement script 
		//baseInputSpeed = Input.GetAxis("HorizontalP1");

		movement = new Vector2(speed.x * inputX, rb.velocity.y);

		Vector3 vel = rb.velocity; 
		palSpeed = vel.magnitude;  

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
		

	void Jump(){


	
		if (movementObj.GetComponent<movementScript>().leftJumped == true){
				//rb.AddForce(Vector2.up * jumpspeed); //on LEFT side of Pal
			rb.velocity = new Vector2(0,1) * jumpForceInt;
			//rb.AddForceAtPosition(new Vector2(0,jumpForceInt), leftWheelPos, ForceMode2D.Impulse); 
			movementObj.GetComponent<movementScript> ().leftJumped = false;
			Debug.Log ("final jump L firing" + leftWheelPos);
		}		

		if (movementObj.GetComponent<movementScript>().rightJumped == true){
			//rb.AddForce(Vector2.up * jumpspeed); //on RIGHT side of Pal
			rb.velocity = new Vector2(0,1) * jumpForceInt;
			//rb.AddForceAtPosition(new Vector2(0,jumpForceInt), rightWheelPos, ForceMode2D.Impulse);
			movementObj.GetComponent<movementScript> ().rightJumped = false;
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
		rb.velocity= movement;
		Jump ();

	}



}