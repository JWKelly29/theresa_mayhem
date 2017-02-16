using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour 

{
	Ray shootRay;                                   
	RaycastHit shootHit;                          
	ParticleSystem gunParticles;                  
	LineRenderer gunLine;                          
	AudioSource gunAudio;     	                  
	Light gunLight;    

	public int damagePerShot = 50;                 
	public float timeBetweenBullets = 0.15f;      
	public float range = 100f;                    
	float timer;                                                        
	float effectsDisplayTime = 0.2f;    
	int shootableMask; 


	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}

	public void CanShoot ()
	{
		timer += Time.deltaTime;
		if(timer >= timeBetweenBullets)
		{
			Shoot ();
		}
		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects ();
		}
	}

	public void DisableEffects ()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot ()
	{
		timer = 0f;
		gunAudio.Play ();
		gunLight.enabled = true;
		gunParticles.Stop ();
		gunParticles.Play ();
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			Destructible_Health destructibleHealth = shootHit.collider.GetComponent <Destructible_Health> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			}
			if (destructibleHealth != null) {
				destructibleHealth.TakeDamage (damagePerShot, shootHit.point);
			}
			gunLine.SetPosition (1, shootHit.point);
		}
		else {
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}