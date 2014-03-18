using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public Transform spawn1; // places that are set
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


	/*
	 * Handles the tank spawning
	 */
	void Spawn(string role) {
		Object ai;
		if (role.Equals ("enemy")) {
						Debug.Log ("enemy spawned"); // 
			ai = Instantiate(tank, spawn1.position, Quaternion.identity);

		} 
		else if (role.Equals ("ally")) {
						Debug.Log ("ally spawned");

		} 
		else { // not a valid spawn
						Debug.Log ("invalid spawn");
		}
		} 
}
