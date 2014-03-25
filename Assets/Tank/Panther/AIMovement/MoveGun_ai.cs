using UnityEngine;

public class MoveGun_ai : MonoBehaviour {

    public float speed = 15;
    public float curRotation = 0;

    // Gun Down
    void gunDown() {
        if(curRotation > -5) {
            transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
            curRotation -= speed * Time.deltaTime;
        }
    }

    // Gun Up
    void gunUp() {
        if(curRotation < 45) {
            transform.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
            curRotation += speed * Time.deltaTime;
        }
    }
}
