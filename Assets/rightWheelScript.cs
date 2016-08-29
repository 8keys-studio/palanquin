using UnityEngine;
using System.Collections;

public class rightWheelScript : MonoBehaviour {

	public bool Rgrounded;
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
//		if (movementObj.GetComponent<movementScript>().rightJumped == true){
//			//rb.AddForce(Vector2.up * jumpspeed); //on RIGHT side of Pal
//			rb.AddForce(new Vector2(0,20), ForceMode2D.Impulse);
//			movementObj.GetComponent<movementScript> ().rightJumped = false;
//		}	
//
//	}

	void OnTriggerStay2D(Collider2D other){


		if (other.tag == ("ground"))
		{
			Debug.Log("R1 Grounded - OnTriggerStay2D");
			Rgrounded = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag("ground"))
		{
			Debug.Log("R1 Grounded - OnCollisionEnter2D");
			Rgrounded = true;
		}



	}


	void OnCollisionStay2D(Collision2D other){


		if (other.gameObject.CompareTag("ground"))	
		{
			Debug.Log("R1 Grounded - OnCollisionStay2D");
			Rgrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){


		if (other.gameObject.CompareTag("ground"))
		{
			Debug.Log("R1 UnGrounded - OnCollisionExit2D");
			Rgrounded = false;
		}

	}
}
