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

    private MoveTank_ai controller;

    // Use this for initialization
    void Start () {
        controller = (MoveTank_ai)gameObject.GetComponent("MoveTank_ai");
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
    }

    // Update is called once per frame
    void Update () {
        setTarget();
        if (targetLoc != null){
            currentState = States.Chasing;
            Debug.DrawLine(transform.position, targetLoc, Color.red);
        }

        if (currentState == States.Chasing){ // Move towards the target location with proper pursuit behavior
            setVelTowards(targetLoc);
        }

        if (currentState == States.Searching){ // move foward while looking for things to shoot
            controller.speedUp();
        }
    }

    void setVelTowards(Vector3 goal){
        Vector3 goalVelocity = Vector3.Normalize(goal - transform.position) * controller.maxSpeed;
        Vector3 steerVelocity = Vector3.Normalize(goalVelocity - transform.forward * controller.currentVelocity) * controller.maxSpeed;

    }

    //Find a target to move towards
    void setTarget(){
        Dictionary<float, GameObject> seenEnemies = new Dictionary<float, GameObject>();
        foreach (GameObject enemy in enemyList){ // Build a list of enemies seen and the distance to them
            if (!Physics.Linecast(transform.position + Vector3.up * 3, enemy.transform.position + Vector3.up * 3)){ // If we successfully draw a line from this tank to their enemy...
                Debug.DrawLine(transform.position + Vector3.up * 3, enemy.transform.position + Vector3.up * 3, Color.green);
                seenEnemies.Add(Vector3.Magnitude(transform.position - enemy.transform.position), enemy); // Add them to our list of seen enemies
            }
        }
        if (seenEnemies.Count > 0){ //if we've seen some enemies, grab the closest one and set its position as our target location
            float minKey = seenEnemies.Keys.Min();
            GameObject closestTank = null;
            seenEnemies.TryGetValue(minKey, out closestTank);
            targetLoc = closestTank.transform.position;
        }
    }
}
