using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	PlayerHealth playerHealth;      // Reference to the player's health.
	EnemyHealth enemyHealth;        // Reference to this enemy's health.
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}


	void Update ()
	{
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			nav.SetDestination (player.position);
		}
		else
		{
			nav.enabled = false;
		}
	} 
}