using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public Transform spawn1; // places that are set
	public Transform spawn2;
	public Transform spawn3;
	public Transform tank;


	// Use this for initialization
	void Start () {

	//	StartSpawn ();// start the initial 
	
	}
	
	// Update is called once per frame
	void Update () {

		// for testing purposes press f5
		if (Input.GetKeyDown ("f5")) {

						Spawn ("enemy");
				}
	
	}

	/**
	 * Random spawn at one of the places
	 */
	void Spawn(string role) {
		Spawn (Random.Range (1, 4), role);
	}

	/*
	 * Handles the tank spawning
	 */
	void Spawn(int spawn, string role) {
		Object ai;
		if (role.Equals ("enemy")) {
						Debug.Log ("enemy spawned"); // 
			switch(spawn) {
				case 1:			
				ai = Instantiate(tank, spawn1.position, Quaternion.identity);
				//ai.GetChild("turret").GetChild("cannon").GetChild("TPCamera").enable = false;
				break;
				case 2:
				ai = Instantiate(tank, spawn2.position, Quaternion.identity);
				//ai.turret.cannon.TPCamera.enable = false;
				break;
				case 3:
				ai = Instantiate(tank, spawn3.position, Quaternion.identity);
				//ai.turret.cannon.TPCamera.enable = false;
				break;
			default:
				Debug.Log ("not a valid spawn");
				break;
			}
				
		} 
		else if (role.Equals ("ally")) {
						Debug.Log ("ally spawned");

		} 
		else { // not a valid spawn
						Debug.Log ("invalid spawn");
		}
		} 
}
