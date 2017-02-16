using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour {

	public bool doublePoints = false;
	public bool instaKill = false;
	public bool speedUp = false;

	private float doublePointsLengthCounter;
	private float instaKillLengthCounter;
	private float speedUpLengthCounter;
	public ScoreManager scoreManager;
	public PlayerShooting playerShooting;
	private float normalPointsPerEnemyKilled;
	private int normalDmgPerShot;
	private PlayerMovement playerMovement;
	private float normalSpeed;


	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType <ScoreManager> ();
		playerShooting = FindObjectOfType <PlayerShooting> ();
		playerMovement = FindObjectOfType <PlayerMovement> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (doublePoints) 
		{
			doublePointsLengthCounter -= Time.deltaTime	;

			if (doublePointsLengthCounter <= 0) 
			{
				doublePoints = false;
				ScoreManager.enemyValue = ScoreManager.enemyValue / 2;
			}
		}

		if (instaKill) 
		{
			instaKillLengthCounter -= Time.deltaTime	;

			if (instaKillLengthCounter <= 0) 
			{
				instaKill = false;
				playerShooting.damagePerShot = normalDmgPerShot;
			}
		}

		if (speedUp) 
		{
			speedUpLengthCounter -= Time.deltaTime	;

			if (speedUpLengthCounter <= 0) 
			{
				speedUp = false;
				playerMovement.speed = normalSpeed;
			}
		}
	}

	public void activateScoreMultiplier()
	{
		doublePointsLengthCounter = 30;
		ScoreManager.enemyValue = ScoreManager.enemyValue * 2;
		doublePoints = true;
	}

	public void activateInstaKill()
	{
		instaKillLengthCounter = 30;
		normalDmgPerShot = playerShooting.damagePerShot;
		playerShooting.damagePerShot = normalDmgPerShot * 1000;
		instaKill = true;
	}

	public void activateSpeedUp()
	{	
		if (normalSpeed > 0)
		{
			playerMovement.speed = normalSpeed;
		}
		speedUpLengthCounter = 30;
		normalSpeed = playerMovement.speed;
		playerMovement.speed = normalSpeed * 1.5f;
		speedUp = true;
	}






}