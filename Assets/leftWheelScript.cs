using UnityEngine;
using System.Collections;

public class leftWheelScript : MonoBehaviour {

	public bool Lgrounded;
	public GameObject movementObj; //attach movement script's prefab obj
	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void Jump (){
//	
//		if (movementObj.GetComponent<movementScript>().leftJumped == true){
//			//rb.AddForce(Vector2.up * jumpspeed); //on LEFT side of Pal
//			rb.AddForce(new Vector2(0,20), ForceMode2D.Impulse);
//			movementObj.GetComponent<movementScript> ().leftJumped = false;
//		}
//	
//	}

	void OnTriggerStay2D(Collider2D other){


		if (other.tag == ("ground"))
		{
			Debug.Log("L1 Grounded - OnTriggerStay2D");
			Lgrounded = true;
		}
			
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag("ground"))
		{
			Debug.Log("L1 Grounded - OnCollisionEnter2D");
			Lgrounded = true;
		}


	}


	void OnCollisionStay2D(Collision2D other){

		if (other.gameObject.CompareTag("ground"))
		{
			Debug.Log("L1 Grounded - OnCollisionStay2D");
			Lgrounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D other){


		if (other.gameObject.CompareTag("ground"))
		{
			Debug.Log("L1 UnGrounded - OnCollisionExit2D");
			Lgrounded = false;
		}


	}
}
