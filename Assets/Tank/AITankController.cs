using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class AITankController : MonoBehaviour {

    public bool isFriendly;
    public enum States {Sleeping, Chasing, Searching, Fleeing}
    public States currentState;
    public int health;
    private Vector3 targetLoc; // The position the tank is moving towards
    private List<GameObject> enemyList; //The list of things this tank considers an enemy
    private Transform map;

    private int maxSpeed = 10;
    private int accel = 2;

    private Vector3 currentVel = new Vector3(0, 0, 0);
    private Vector3 currentAccel = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        map = GameObject.Find("Map").GetComponent<Transform>();
        currentState = States.Sleeping;
        health = 100;
        if(UnityEngine.Random.Range(0, 1) == 0){
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
        Debug.Log("My Enemies");
        foreach (GameObject o in enemyList){
            Debug.Log(o);
        }
        Debug.Log("The Enemies");
        foreach (GameObject o in TankManager.Instance.EnemyTanks){
            Debug.Log(o);
        }
        Debug.Log("My Friends");
        foreach (GameObject o in TankManager.Instance.FriendlyTanks){
            Debug.Log(o);
        }
    }

    // Update is called once per frame
    void Update () {
        setTarget();
        if (targetLoc != null){
            currentState = States.Chasing;
        }

        if (currentState == States.Chasing){ // Move towards the target location with proper pursuit behavior
            setVelTowards(targetLoc);
        }

        if (currentState == States.Searching){ // a slow roll foward while looking for things to shoot

        }

    }

    void setVelTowards(Vector3 goal){
        Vector3 goalVelocity = Vector3.Normalize(goal - transform.position) * maxSpeed;
        Vector3 steerVelocity = Vector3.Normalize(goalVelocity - currentVel) * maxSpeed;

    }

    //Find a target to move towards
    void setTarget(){
        Dictionary<float, GameObject> seenEnemies = new Dictionary<float, GameObject>();
        foreach (GameObject enemy in enemyList){ // Build a list of enemies seen and the distance to them
            if (!Physics.Linecast(transform.position + Vector3.up * 3, enemy.transform.position + Vector3.up * 3)){ // If we successfully draw a line from this tank to their enemy...
                Debug.DrawLine(transform.position + Vector3.up * 3, enemy.transform.position + Vector3.up * 3, Color.green);
                seenEnemies.Add(Vector3.Magnitude(transform.position - enemy.transform.position), enemy);
            }
        }
        if (seenEnemies.Count > 0){ //if we've seen some enemies, grab the closest one
            float minKey = seenEnemies.Keys.Min();
            GameObject closestTank = null;
            seenEnemies.TryGetValue(minKey, out closestTank);
            targetLoc = closestTank.transform.position;
        }
    }
}
