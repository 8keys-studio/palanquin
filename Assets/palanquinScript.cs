﻿using UnityEngine;
using System.Collections;

public class palanquinScript : MonoBehaviour {

	//********NOTES**********:
	// - May need to move some individual checks (angle, speed) to character objs, or else create bools for each condition based
	//   on fare type

	public int palSpeed; //speed of pal
	public int hitSpeed; //speed cap of fare character
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

	// Use this for initialization
	void Start () {
		UpdateFare (); 
		stunCollide = false;
		stunSpeed = false;
		stunRotation = false;
		rb = GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update () {

		Vector3 vel = rb.velocity; //to get a Vector3 representation of the velocity
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
		if (transform.rotation.eulerAngles.y > 90) //make # variable (change per character), confirm axis is correct. make || condition?
			//Debug.Log(transform.eulerAngles.y); //testing
		{
			fareAmount = fareAmount - fareHitAmount;
			UpdateFare ();
			stunSpeed = true;
			Invoke("resetColliderSpeed", speedStunTime);

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

