using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour 

{
	public PlayerHealth playerHealth;       // Reference to the player's health.
	public float restartDelay = 5f;         // Time to wait before restarting the level


	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level


	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("GameOver");

			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}