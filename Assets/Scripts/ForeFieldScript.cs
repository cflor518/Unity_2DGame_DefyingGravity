using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeFieldScript : MonoBehaviour {
	public float rotatePerSecond = 0.1f;
	public bool _______________________;
	public int levelShown = 0;
	private Material mat;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Get the current forcefield from the Singleton
		int currentLevel = Mathf.FloorToInt(PlayerPlaneScript.PlayerS.forceFieldStrength);
		//Make sure the level shown is the same as in the PlayerPlaneScript
		if(levelShown != currentLevel)
		{
			levelShown = currentLevel;
			mat = GetComponent<Material>();
			mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
		}
		//This will make the ForceField rotate
		float rotationAmongZAxis = (rotatePerSecond * Time.time * 360) % 360f;
		transform.rotation = Quaternion.Euler(0, 0, rotationAmongZAxis);
	}
}
