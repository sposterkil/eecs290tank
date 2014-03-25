using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {
    void OnApplicationQuit() {
        Destroy(gameObject);
    }
}
