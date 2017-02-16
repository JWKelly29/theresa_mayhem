using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	public float powerupLength;

	private PowerupController powerupController;

	// Use this for initialization
	void Start () {
		powerupController = FindObjectOfType<PowerupController> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PointsMultiplier")) 
		{
			powerupController.activateScoreMultiplier ();
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("SpeedPowerup")) 
		{
			powerupController.activateSpeedUp ();
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("InstaKill"))
		{
			powerupController.activateInstaKill ();
			other.gameObject.SetActive (false);
		}
	}

}