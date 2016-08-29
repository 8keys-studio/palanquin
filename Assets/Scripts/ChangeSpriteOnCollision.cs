using UnityEngine;
using System.Collections;

public class ChangeSpriteOnCollision : MonoBehaviour {
	
	public Sprite newSprite;
	public float destroyTime = 2.0f;
	public float velocityX = -3.0f;
	public float velocityY = 5.0f;
	private bool deleting = false;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (velocityX, velocityY);
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = "Foreground";
		spriteRenderer.sortingOrder = 1;
	}
		
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D() {
		if (!deleting) {
			GetComponent<SpriteRenderer> ().sprite = newSprite;
			deleting = true;
			Object.Destroy (gameObject, destroyTime);
		}
	}
}
