using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_Health : MonoBehaviour {

	ParticleSystem explosion;               
	CapsuleCollider capsuleCollider; 
	AudioSource explosion1Clip;


	public int startingHealth = 100;           
	public int currentHealth; 
	public float ExplosionForce = 1000f;
	public float ExplosionRadius = 50f;
	public float MaxDamage = 200f;


	void Awake ()
	{
		explosion = GetComponentInChildren <ParticleSystem> ();
		explosion1Clip = GetComponentInChildren <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		currentHealth -= amount;
		explosion.transform.position = hitPoint;
		explosion.Play ();
		explosion1Clip.Play ();
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<BoxCollider>().enabled = false;
		if (currentHealth <= 0) 
		{
			var colliders = Physics.OverlapSphere (transform.position, ExplosionRadius);
			for (int i = 0; i < colliders.Length; i++) {
				Rigidbody targetRigidbody = colliders [i].GetComponent<Rigidbody> ();
				if (!targetRigidbody)
					continue;
				targetRigidbody.AddExplosionForce (ExplosionForce, transform.position, ExplosionRadius);
				EnemyHealth enemyHealth = targetRigidbody.GetComponent<EnemyHealth>();
				if (!enemyHealth)
					continue;
				float damage = CalculateDamage (targetRigidbody.position);
				enemyHealth.TakeDamage (damage, hitPoint);
			}
			StartCoroutine ("WaitASecond");
		}
	}

	IEnumerator WaitASecond() {
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}


	private float CalculateDamage(Vector3 targetPosition)
	{
		Vector3 explosionToTarget = targetPosition - transform.position;
		float explosionDistance = explosionToTarget.magnitude;
		float relativeDistance = (ExplosionRadius - explosionDistance) / ExplosionRadius;
		float damage = relativeDistance * MaxDamage;
		damage = Mathf.Max (0f, damage);
		return damage*20;
	}






	






}
