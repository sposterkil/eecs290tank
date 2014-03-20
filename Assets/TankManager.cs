using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//make list of tanks on each team
//locate list in game manager
//current AI
//start OPEN at top down view
//press enter PLAY and it spawns all tanks and game starts
//start, play, FINISH when no friendly tanks left
//how to communicate between other objects and the game manager--who controls what's going on
//keep health in this? do I manage all the player's stats and what's going on in the game?
//who starts the game? do i use my Start/Update?
//How to work with the tanks--also, menu? do we have one of those?
public class TankManager {

	protected TankManager() { //initialize manager; can only be accessed through Instance
	}

	private static TankManager _instance = null;

	public List <GameObject> FriendlyTanks = new List<GameObject>();
	public List <GameObject> EnemyTanks = new List<GameObject>();

	//singleton pattern implementation
	public static TankManager Instance {
		get {
			if (_instance == null) {
				_instance = new TankManager();
			}
			return _instance;
		}
	}
}
