using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public GUIText killCounter; // holds the text on screen'
	public GUITexture crosshairs;
	int kills = 0; // start off with no kills
	public GameObject playerTank;
	public GUIText deathText;

	void Start() {
				crosshairs.enabled = true;
				killCounter.enabled = true;
				deathText.enabled = false;
		}


	public void killed() { // adds a kill to the count
		kills++;
	}
	
	void Update () {
		killCounter.text = ("Kills: " + kills); // update kill count always
	
		if (playerTank == null) {
			killCounter.enabled = false;
			crosshairs.enabled = false;
			deathText.enabled = true;
		}
	}


}
