using UnityEngine;
using System.Collections;

public class ThrowProjectile : MonoBehaviour
{
	public GameObject projectile;

	// Use this for initialization
	void Start ()
	{
		Vector3 position = new Vector3 (14.0f, 4f, 0.2f);
		Quaternion rotation = Quaternion.Euler(45, 30, 0);
		Instantiate(projectile, position, rotation);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

