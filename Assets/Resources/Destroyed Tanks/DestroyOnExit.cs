using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {

    void OnApplicationQuit() {
        Debug.Log("Destroying " + gameObject);
        Destroy(gameObject);
    }
}
