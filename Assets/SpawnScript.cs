using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public Transform spawn1; // places that are set
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	public Transform spawn5;
	public Transform spawn6;
	public Transform spawn7;
	public Transform spawn8;
	public Transform spawn9;
	public GameObject tank;


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
		Spawn (Random.Range (1, 10), role);
	}

	/*
	 * Handles the tank spawning
	 */
	void Spawn(int spawn, string role) {
		GameObject ai;
		Transform t;
		if (role.Equals ("enemy")) {
						Debug.Log ("enemy spawned"); //
			switch(spawn) {
				case 1:
					t = Instantiate(tank, spawn1.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 2:
					t = Instantiate(tank, spawn2.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 3:
					t = Instantiate(tank, spawn3.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 4:
					t = Instantiate(tank, spawn4.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 5:
					t = Instantiate(tank, spawn5.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 6:
					t = Instantiate(tank, spawn6.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 7:
					t = Instantiate(tank, spawn7.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
					break;
				case 8:
					t = Instantiate(tank, spawn8.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
				break;
				case 9:
					t = Instantiate(tank, spawn9.position, Quaternion.identity) as Transform;
					ai = t.gameObject;
					ai.SetActive(true);
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
