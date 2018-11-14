using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneScript : MonoBehaviour {
	static public PlayerPlaneScript PlayerS; //Singleton
								 //Control the movement of the plane
	public float speed = 30;
	public float rollMult = -45;
	public float pitchMult = 15;
    public GameObject LaserBeam;
    public Transform LaserBeamSpawn;
    public float laser_Power = 100f;

	//status
	public float forceFieldStrength = 1;

	void Awake () {
		PlayerS = this;
	}
	private void Update()
	{
		//Pull the information from the Input class
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis("Vertical");

		//Change based on the axes
		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;

		//This will cause the ship to rotate ever so slightly.
		transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        if(Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("Shooting the damn Cannonball");
            var aLaserBeam = Instantiate(LaserBeam, LaserBeamSpawn.transform.position, Quaternion.identity);
            Rigidbody2D LaserBeamRigidBody = aLaserBeam.GetComponent<Rigidbody2D>();
            LaserBeamRigidBody.velocity = Quaternion.Euler(0, 0, 0) * Vector3.up * laser_Power;
            Destroy(aLaserBeam.gameObject, 5f);
        }
    }
}
