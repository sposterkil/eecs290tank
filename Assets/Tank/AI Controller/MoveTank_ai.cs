using UnityEngine;
public class MoveTank_ai : MonoBehaviour {
    private MoveTrack_ai leftTrack;
    private MoveTrack_ai rightTrack;
    private enum accelStates {Forward, Stop, Backward};
    private accelStates accel = accelStates.Stop;
    public float speed = 10;
    public float maxSpeed = 40;


    public Transform spawnPoint;
    public GameObject bulletObject;
    public GameObject fireEffect;

    void Start() {

        // Get Track Controls
        leftTrack = (MoveTrack_ai)GameObject.Find(gameObject.name + "/Lefttrack").GetComponent("MoveTrack_ai");
        rightTrack = (MoveTrack_ai)GameObject.Find(gameObject.name + "/Righttrack").GetComponent("MoveTrack_ai");

    }


    void FixedUpdate () {
        switch (accel){
            case accelStates.Forward:
                rigidbody.AddForce(transform.forward * 10000);
                break;

            case accelStates.Backward:
                rigidbody.AddForce(transform.forward * -10000);
                break;

            default:
                break;
        }

        speed = rigidbody.velocity.magnitude;

        // Move Tracks by speed
        if (speed > 0) {
            // Move forward
            leftTrack.speed = speed;
            leftTrack.GearStatus = 1;
            rightTrack.speed = speed;
            rightTrack.GearStatus = 1;
        }
        else if (speed < 0)   {
            // Move Backward
            leftTrack.speed = -speed;
            leftTrack.GearStatus = 2;
            rightTrack.speed = -speed;
            rightTrack.GearStatus = 2;
        }
        else {
            // No Move
            leftTrack.GearStatus = 0;
            rightTrack.GearStatus = 0;
        }
        accel = accelStates.Stop;
    }

    public void speedUp() {
        // Speed Up
        if (speed < maxSpeed){
            accel = accelStates.Forward;
        }
    }

    public void speedDown() {
        // Slow Down
        if (speed > -maxSpeed){
            accel = accelStates.Backward;
        }
    }


    // Turn Tank
    public void turnLeft(){
        Debug.Log("Turnin' Left!!");
        rigidbody.AddTorque(transform.up * -8000);
    }

    public void turnRight() {
        Debug.Log("Turnin' Right!!");
        rigidbody.AddTorque(transform.up * 8000);
    }

    // Fire!
    public void fireTurret() {
        // make fire effect.
        Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);

        // make ball
        Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation);
    }
}
