using UnityEngine;
using System.Collections;

public class palanquinScript : MonoBehaviour {

	//********NOTES**********:
	// - May need to move some individual checks (angle, speed) to character objs, or else create bools for each condition based
	//   on fare type

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

	// Use this for initialization
	void Start () {
		UpdateFare (); 
		stunCollide = false;
		stunSpeed = false;
		stunRotation = false;
		rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () {

		Vector3 vel = rb.velocity; // change this to pull in global value via movement script
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
	}

	void Jump(){
	
		if (movementObj.GetComponent<movementScript>().leftJumped == true){
			//	rb2d.AddForce(Vector2.up * jumpspeed); //on LEFT side of Pal
		}		

		if (movementObj.GetComponent<movementScript>().rightJumped == true){
			//	rb2d.AddForce(Vector2.up * jumpspeed); //on RIGHT side of Pal
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



}

