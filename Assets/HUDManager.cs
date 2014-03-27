using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public GUIText killCounter; // holds the text on screen
	int kills = 0; // start off with no kills
	
	public void killed() { // adds a kill to the count
		kills++;
	}
	
	void Update () {
		killCounter.text = ("Kills: " + kills); // update kill count always
	}
}
