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
            gameObject.tag = "enemy";
            TankManager.Instance.EnemyTanks.Add(gameObject);
            enemyList = TankManager.Instance.FriendlyTanks;

        }
        else{
            isFriendly = true;
            TankManager.Instance.FriendlyTanks.Add(gameObject);
            enemyList = TankManager.Instance.EnemyTanks;
            gameObject.tag = "friendly";
        }
	}

	// Update is called once per frame
	void Update () {
        targetLoc = getTarget();
        if (targetLoc != null){
            currentState = States.Chasing;
            setVelTowards(targetLoc);
        }

	}

    Vector3 setVelTowards(Vector3 goal){
        Vector3 goalVelocity = Vector3.Normalize(goal - transform.position) * maxSpeed;
        Vector3 steerVelocity = Vector3.Normalize(goalVelocity - currentVel) * maxSpeed;
        return steerVelocity;
    }

    Vector3 getTarget(){
        Dictionary<float, GameObject> seenEnemies = new Dictionary<float, GameObject>();
        foreach (GameObject enemy in enemyList){
            RaycastHit hit;
            Vector3 toEnemy = transform.position - enemy.transform.position;
            if (Physics.Linecast(transform.position + new Vector3(0, 1, 0), toEnemy, out hit)){
                if (hit.collider.gameObject == enemy){
                    seenEnemies.Add(Vector3.Magnitude(transform.position - enemy.transform.position), enemy);
                }
            }
        }
        if (seenEnemies.Count > 0){
            float minKey = seenEnemies.Keys.Min();
            GameObject closestTank = null;
            seenEnemies.TryGetValue(minKey, out closestTank);
            return closestTank.transform.position;
        }
        else{
            return transform.position;
        }
    }
}
