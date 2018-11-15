using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour {

	public GameObject PlayerPlanePOI; //The playerplane position
	public GameObject[] panels; //The scrolling foreground
	public float scrollSpeed = -30f;
	//motionMult controls how much panerls react to player movement
	public float motionMult = 0.25f;

	private float panelHeight; //Height of each panel
	private float depth; //The depth of panels, the position Z;



	// Use this for initialization
	void Start () {
		panelHeight = panels[0].transform.localScale.y;
		depth = panels[0].transform.position.z;

		//Set initial positions of panels
		panels[0].transform.position = new Vector3(0, 0, depth);
		panels[1].transform.position = new Vector3(0, panelHeight, depth);
	}
	
	// Update is called once per frame
	void Update () {
		float tY, tX = 0;
		tY = Time.time * scrollSpeed % panelHeight + (panelHeight + 0.5f);
		if(PlayerPlanePOI != null){
			tX = -PlayerPlanePOI.transform.position.x * motionMult;
		}

		//Positoon panels[0]
		panels[0].transform.position = new Vector3(tX, tY, depth);
		//Then the position panels[1] where needed to make a continsouse starfield
		if(tY >= 0){
			panels[1].transform.position = new Vector3(tX, tY - panelHeight, depth);
		}
		else
		{
			panels[1].transform.position = new Vector3(tX, tY + panelHeight, depth);
		}
	}
}
