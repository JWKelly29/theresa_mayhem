using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour 
{
	private static float score;        // The player's score.
	public static float enemyValue = 10f;

	UnityEngine.UI.Text text;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <UnityEngine.UI.Text> ();

		// Reset the score.
		score = 0.0f;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + score;
	}

	public static void updateScore ()
	{
		score += enemyValue;
	}
}