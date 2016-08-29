using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FaderScript : MonoBehaviour {

	public Texture2D fadeOutTexture; // texture to overlay the screen
	public float fadeSpeed = 0.8f; // the fade speed
	private int drawDepth = -1000; //texture's order in draw hierarchy: lowest renders on top
	private float alpha = 1.0f; // texture's alhpa between 0 and 1
	private int fadeDir = -1; // the direction to fade: in = -1 or out  = 1

	void OnGUI () 
	{
		//Debug.Log("FaderScript activated.");
		//fade out/in the alpha value using a direction, speed, and Time.deltatime to convert to seconds

		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		//force the number bettween 0 and 1 for Gui.colo

		alpha = Mathf.Clamp01(alpha);

		//se color of our GUI. All color values remain the same and Alpha is set to alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // set the alpha value
		GUI.depth = drawDepth; // make black texture on top/drawn last
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); // draw texture to fit entire screen area

	}

	public float BeginFade (int direction) {
		Debug.Log("Got to BeginFade!");
		fadeDir = direction;
		return (fadeSpeed);
	}

	// OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes

	void OnLevelWasLoaded () {
		//Debug.Log("SceneLoaded fired.");
		// alpha = 1;   // use this is the alpha is not set to 1 by default
		BeginFade (-1);
	}
		
}
