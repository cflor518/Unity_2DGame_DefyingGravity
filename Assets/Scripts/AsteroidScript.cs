using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

	public static float bottomY = -50f;
	public float rotationSpeed = 100f;
	public float numberOfShotsToDestroy = 3f;
	public float explosion_power = 100f;
	//public GameObject rubbleP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
		if ( transform.position.y < bottomY)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Find out what hit he Asteroid
		GameObject collideWith = collision.gameObject;
		if (collideWith.tag == "aLaserBeam")
		{
			Destroy(collideWith);
			Destroy(this.gameObject);
			/*
			var rubble1 = Instantiate(rubbleP, transform.position, Quaternion.identity);
			Rigidbody rubble1rigidbody = rubble1.GetComponent<Rigidbody>();
			rubble1rigidbody.velocity = Quaternion.Euler(0, 0, 0) * Vector3.up * explosion_power;
			Destroy(rubble1.gameObject, 1f);
			
			
			var rubble2 = Instantiate(rubblePrefab, transform.position, Quaternion.identity);
			Rigidbody rubble2rigidbody = rubble2.GetComponent<Rigidbody>();
			rubble2rigidbody.velocity = Quaternion.Euler(0, 0, 0) * Vector3.down * explosion_power;
			Destroy(rubble2.gameObject, 1f);

			var rubble3 = Instantiate(rubblePrefab, transform.position, Quaternion.identity);
			Rigidbody rubble3rigidbody = rubble3.GetComponent<Rigidbody>();
			rubble3rigidbody.velocity = Quaternion.Euler(0, 0, 0) * Vector3.right * explosion_power;
			Destroy(rubble3.gameObject, 1f);

			var rubble4 = Instantiate(rubblePrefab, transform.position, Quaternion.identity);
			Rigidbody rubble4rigidbody = rubble4.GetComponent<Rigidbody>();
			rubble4rigidbody.velocity = Quaternion.Euler(0, 0, 0) * Vector3.left * explosion_power;
			Destroy(rubble4.gameObject, 1f);*/






		}

	}
}
