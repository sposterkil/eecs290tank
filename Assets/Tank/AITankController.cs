using UnityEngine;
using System.Collections;

public class AITankController : MonoBehaviour {

    public bool isFriendly;
    public enum States {Sleeping, Chasing, Searching, Fleeing}
    public States currentState;
    public int health;

	// Use this for initialization
	void Start () {
        currentState = States.Sleeping;
        health = 100;
        if(Random.Range(0, 1) == 0){
            isFriendly = false;
        }
        else{
            isFriendly = true;
        }
	}

	// Update is called once per frame
	void Update () {

	}
}
