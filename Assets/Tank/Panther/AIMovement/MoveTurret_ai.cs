using UnityEngine;

public class MoveTurret_ai : MonoBehaviour {
    public float speed = 30;

    // Turn Right
    void turretRight(){
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
    // Turn Left
    void turretLeft() {
        transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
    }
}
