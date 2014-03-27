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
		StartCoroutine(PeriodicSpawn());
	//	StartSpawn ();// start the initial

	}

	// Update is called once per frame
	void Update () {
		// for testing purposes press f5
		if (Input.GetKeyDown ("f5")) {
			Spawn ();
		}
	}

	IEnumerator PeriodicSpawn() {
		while (true){
			Spawn();
			yield return new WaitForSeconds(10);
		}
	}

	/**
	 * Random spawn at one of the places
	 */
	void Spawn() {
		Spawn (Random.Range (1, 10));
	}

	/*
	 * Handles the tank spawning
	 */
	void Spawn(int spawn) {
		switch(spawn) {
			case 1:
				Instantiate(tank, spawn1.position, Quaternion.identity);
				break;
			case 2:
				Instantiate(tank, spawn2.position, Quaternion.identity);
				break;
			case 3:
				Instantiate(tank, spawn3.position, Quaternion.identity);
				break;
			case 4:
				Instantiate(tank, spawn4.position, Quaternion.identity);
				break;
			case 5:
				Instantiate(tank, spawn5.position, Quaternion.identity);
				break;
			case 6:
				Instantiate(tank, spawn6.position, Quaternion.identity);
				break;
			case 7:
				Instantiate(tank, spawn7.position, Quaternion.identity);
				break;
			case 8:
				Instantiate(tank, spawn8.position, Quaternion.identity);
				break;
			case 9:
				Instantiate(tank, spawn9.position, Quaternion.identity);
				break;
			default:
				Debug.Log ("not a valid spawn");
				break;
		}
	}
}
