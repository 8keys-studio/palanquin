using UnityEngine;
using System.Collections;

public class ThrowProjectile : MonoBehaviour
{
	public GameObject projectile;
	private Quaternion rotation = Quaternion.Euler(45, 30, 0);

	// Use this for initialization
	void Start ()
	{
		//Vector3 position = new Vector3 (14.0f, 4f, 0.2f);
		InvokeRepeating("ThrowRose", 1, 2);

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	
	}

	void ThrowRose ()
	{
		Object roseInstance = Instantiate(projectile, gameObject.transform.position, rotation);
		Object.Destroy(roseInstance, 2.0f);

	}
		
}

