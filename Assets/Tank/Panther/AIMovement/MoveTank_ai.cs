using UnityEngine;
public class MoveTank_ai : MonoBehaviour {
    private MoveTrack_ai leftTrack;
    private MoveTrack_ai rightTrack;
    private float acceleration = 2;
    private float rotationSpeed = 30;

    public float currentVelocity = 0;
    public float maxSpeed = 10;

    Transform spawnPoint;
    GameObject bulletObject;
    GameObject fireEffect;

    void Start() {

        // Get Track Controls
        leftTrack = (MoveTrack_ai)GameObject.Find(gameObject.name + "/Lefttrack").GetComponent("MoveTrack_ai");
        rightTrack = (MoveTrack_ai)GameObject.Find(gameObject.name + "/Righttrack").GetComponent("MoveTrack_ai");

    }


    void Update () {
        // No key input.
        if (currentVelocity > 0)
        currentVelocity -= acceleration * Time.deltaTime;
        else if (currentVelocity < 0)
        currentVelocity += acceleration * Time.deltaTime;

        // Turn off engine if currentVelocity is too small.
        if (Mathf.Abs(currentVelocity) <= 0.005)
        currentVelocity = 0;

        // Move Tank by currentVelocity
        transform.Translate(new Vector3(0, 0, currentVelocity * Time.deltaTime));

        // Move Tracks by currentVelocity
        if (currentVelocity > 0) {
            // Move forward
            leftTrack.speed = currentVelocity;
            leftTrack.GearStatus = 1;
            rightTrack.speed = currentVelocity;
            rightTrack.GearStatus = 1;
        }
        else if (currentVelocity < 0)   {
            // Move Backward
            leftTrack.speed = -currentVelocity;
            leftTrack.GearStatus = 2;
            rightTrack.speed = -currentVelocity;
            rightTrack.GearStatus = 2;
        }
        else {
            // No Move
            leftTrack.GearStatus = 0;
            rightTrack.GearStatus = 0;
        }
    }

    public void speedUp() {
        // Debug.Log("Trying to move forward!");
        // plus speed
        if (currentVelocity < maxSpeed) {
            currentVelocity += acceleration * 2 * Time.deltaTime;
            if (currentVelocity > maxSpeed)
            currentVelocity = maxSpeed;
        }

    }
    public void speedDown() {
        // minus speed
        if (currentVelocity > -maxSpeed)
        currentVelocity -= acceleration * 2 * Time.deltaTime;
        if (currentVelocity < -maxSpeed)
        currentVelocity = -maxSpeed;

    }


        // Turn Tank
    public void turnLeft(){
        if (currentVelocity < 0) {
            // Turn right
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
            leftTrack.speed = rotationSpeed;
            leftTrack.GearStatus = 1;
            rightTrack.speed = rotationSpeed;
            rightTrack.GearStatus = 2;

        } else {
            // Turn left
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
            leftTrack.speed = rotationSpeed;
            leftTrack.GearStatus = 2;
            rightTrack.speed = rotationSpeed;
            rightTrack.GearStatus = 1;

        }
    }

    public void turnRight() {
        if (currentVelocity < 0) {
            // Turn left
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
            leftTrack.speed = rotationSpeed;
            leftTrack.GearStatus = 2;
            rightTrack.speed = rotationSpeed;
            rightTrack.GearStatus = 1;

        } else {
            // Turn right
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
            leftTrack.speed = rotationSpeed;
            leftTrack.GearStatus = 1;
            rightTrack.speed = rotationSpeed;
            rightTrack.GearStatus = 2;

        }
    }

        // Fire!
    public void fireTurret() {
        // make fire effect.
        Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);

        // make ball
        Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation);
    }
}
