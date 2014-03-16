using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AITankController : MonoBehaviour {

    public bool isFriendly;
    public enum States {Sleeping, Chasing, Searching, Fleeing}
    public States currentState;
    public int health;
    private Vector3 targetLoc; // The position the tank is moving towards
    private List<GameObject> enemyList; //The list of things this tank considers an enemy

	// Use this for initialization
	void Start () {
        currentState = States.Sleeping;
        health = 100;
        if(Random.Range(0, 1) == 0){
            isFriendly = false;
            // TODO: Replace this with GameManager list checking
            gameObject.tag = "enemy";
        }
        else{
            isFriendly = true;
            // TODO: Replace this with GameManager list checking
            gameObject.tag = "friendly";
        }
	}

	// Update is called once per frame
	void Update () {

	}

    bool getTarget(){
        foreach (GameObject enemy in enemyList){
            RaycastHit hit;
            Vector3 toEnemy = transform.position - enemy.transform.position;
            if (Physics.Linecast(transform.position + new Vector3(0, 1, 0), toEnemy, out hit)){
                if (hit.collider.gameObject == enemy){
                    targetLoc = enemy.transform.position;
                    return true;
                }
            }
        }
        return false;
    }
}
