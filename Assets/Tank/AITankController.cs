using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AITankController : MonoBehaviour {

    public bool isFriendly;
    public enum States {Sleeping, Chasing, Searching, Fleeing}
    public States currentState;
    public int health;
    private Vector3 targetLoc; // The position the tank is moving towards
    private List<GameObject> enemyList; //The list of things this tank considers an enemy

    private int maxSpeed = 10;
    private int accel = 2;
    private Vector3 currentVel = new Vector3(0, 0, 0);
    private Vector3 currentAccel = new Vector3(0, 0, 0);

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
        getTarget();
        if (targetLoc != null){
            setVelTowards(targetLoc);
        }
        transform.position = transform.position + currentVel;
	}

    void setVelTowards(Vector3 goal){
        Vector3 goalVelocity = Vector3.Normalize(goal - transform.position) * maxSpeed;
        Vector3 steerVelocity = Vector3.Normalize(goalVelocity - currentVel) * maxSpeed;
        currentVel = steerVelocity;
    }

    void getTarget(){
        List<GameObject> seenEnemies = new List<GameObject>();
        foreach (GameObject enemy in enemyList){
            RaycastHit hit;
            Vector3 toEnemy = transform.position - enemy.transform.position;
            if (Physics.Linecast(transform.position + new Vector3(0, 1, 0), toEnemy, out hit)){
                if (hit.collider.gameObject == enemy){
                    seenEnemies.Add(enemy);
                }
            }
        }
        if (seenEnemies.Count > 0){
            // seenEnemies = seenEnemies.OrderBy<GameObject>(Vector3.magnitude(enemy => transform.position - enemy.transform.position));
            // Sorry for breakin' shit guys!
        }
    }
}
