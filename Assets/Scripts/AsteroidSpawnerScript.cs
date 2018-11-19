using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
	public GameObject asteroidPrefab;
	public float speed = 10f;
	//Lets the spawner not float out of the screen, must match this
	//to main camera orthographic size.
	public float leftAndRightEdge = 40f;
	public float chanceToChangeDirection = 0.1f;
	public float secondsBetweenAsteroidDrops;
	// Use this for initialization
	public float rotationSpeed = 10f;
	void Start()
	{
		//Dropping Asteroids apples
		InvokeRepeating("SpawnAsteroid", 2f, secondsBetweenAsteroidDrops);
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		if (pos.x < -leftAndRightEdge)
		{
			speed = Mathf.Abs(speed); //Move right
		}
		else if (pos.x > leftAndRightEdge)
		{
			speed = -Mathf.Abs(speed); //Move left
		}
	}
	private void FixedUpdate()
	{
		//Change Direction Randomly
		if (Random.value < chanceToChangeDirection)
		{
			speed *= -1; //Change Direction
		}
	}
	void SpawnAsteroid()
	{
		GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
		asteroid.transform.position = transform.position;
	}

}
