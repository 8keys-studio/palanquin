using UnityEngine;
using System.Collections;

public class CameraNoPivot : MonoBehaviour {

	public GameObject player;
//	public float cameraFollowSpeed;
//	private Vector3 player_target = new Vector3(0, 0, 0);

	void Update(){

		float playerx = player.transform.position.x;
		float playery = player.transform.position.y;

		Vector3 player_target = new Vector3(playerx, playery, -10);
//		Debug.Log("PT: " + player_target.z);

//		transform.position = Vector2.MoveTowards(
//			transform.position, player_target,
//			Time.deltaTime*cameraFollowSpeed);
//
		transform.position = player_target;
	}
}
