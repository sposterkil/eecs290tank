#pragma strict

var leftTrack : MoveTrack;
var rightTrack : MoveTrack;

var acceleration : float = 5;

var currentVelocity : float = 0;
var maxSpeed : float = 40;

var rotationSpeed : float = 30;

var spawnPoint : Transform;
var bulletObject : GameObject;
var fireEffect : GameObject;
var deathCam : GameObject;

var nextFire: long;

function Start() {
	//Gun starts with no cooldown.
	nextFire = 0L;

	// Get Track Controls
	leftTrack = GameObject.Find(gameObject.name + "/Lefttrack").GetComponent(MoveTrack);
	rightTrack = GameObject.Find(gameObject.name + "/Righttrack").GetComponent(MoveTrack);

}


function Update () {

	if (Input.GetKey (KeyCode.UpArrow)) {
		// plus speed
		if (currentVelocity < maxSpeed) {
			//Add more acceleration of "countering"
			if (currentVelocity < 0) {
				currentVelocity += acceleration * Time.deltaTime;
			}
			currentVelocity += acceleration * Time.deltaTime;
			if (currentVelocity > maxSpeed)
				currentVelocity = maxSpeed;
		}

	} else if (Input.GetKey (KeyCode.DownArrow)) {
		// minus speed
		if (currentVelocity > -maxSpeed) {
			//Add more acceleration of "countering"
			if (currentVelocity > 0) {
				currentVelocity -= acceleration * Time.deltaTime;
			}
			currentVelocity -= acceleration * Time.deltaTime;
			if (currentVelocity < -maxSpeed)
				currentVelocity = -maxSpeed;
		}

	} else {
		// No key input.
		if (currentVelocity > 0)
			currentVelocity -= acceleration * Time.deltaTime;
		else if (currentVelocity < 0)
			currentVelocity += acceleration * Time.deltaTime;

	}


	// Turn off engine if currentVelocity is too small.
	if (Mathf.Abs(currentVelocity) <= 0.005)
		currentVelocity = 0;

	// Move Tank by currentVelocity
	transform.Translate(Vector3(0, 0, currentVelocity * Time.deltaTime));

	// Move Tracks by currentVelocity
	if (currentVelocity > 0) {
		// Move forward
		leftTrack.speed = currentVelocity;
		leftTrack.GearStatus = 1;
		rightTrack.speed = currentVelocity;
		rightTrack.GearStatus = 1;
	}
	else if (currentVelocity < 0)	{
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

	// Turn Tank
	if (Input.GetKey (KeyCode.LeftArrow)) {
		if (currentVelocity < 0) {
			// Turn right
			transform.Rotate(Vector3(0, rotationSpeed * Time.deltaTime, 0));
			leftTrack.speed = rotationSpeed;
			leftTrack.GearStatus = 1;
			rightTrack.speed = rotationSpeed;
			rightTrack.GearStatus = 2;

		} else {
			// Turn left
			transform.Rotate(Vector3(0, -rotationSpeed * Time.deltaTime, 0));
			leftTrack.speed = rotationSpeed;
			leftTrack.GearStatus = 2;
			rightTrack.speed = rotationSpeed;
			rightTrack.GearStatus = 1;

		}
	}
	if (Input.GetKey (KeyCode.RightArrow)) {
		if (currentVelocity < 0) {
			// Turn left
			transform.Rotate(Vector3(0, -rotationSpeed * Time.deltaTime, 0));
			leftTrack.speed = rotationSpeed;
			leftTrack.GearStatus = 2;
			rightTrack.speed = rotationSpeed;
			rightTrack.GearStatus = 1;

		} else {
			// Turn right
			transform.Rotate(Vector3(0, rotationSpeed * Time.deltaTime, 0));
			leftTrack.speed = rotationSpeed;
			leftTrack.GearStatus = 1;
			rightTrack.speed = rotationSpeed;
			rightTrack.GearStatus = 2;

		}
	}

	// Fire!
	if (Input.GetButton("Fire1")) {
		//If gun is off of cooldown
		if (System.DateTime.Now.Ticks >= nextFire) {
			// make fire effect.
			Instantiate(fireEffect, spawnPoint.position, spawnPoint.rotation);
			// make ball
			Instantiate(bulletObject, spawnPoint.position, spawnPoint.rotation);
			//Reset cooldown
			nextFire = System.DateTime.Now.Ticks + (1000L * 10000L);
		}
	}

	//Update minimap
	var map : Transform = GameObject.Find("ZMinimap").transform;
	var player : Transform = GameObject.Find("PlayerTank").transform;
	map.localPosition.x = player.localPosition.x;
	map.localPosition.y = player.localPosition.y + 150f;
	map.localPosition.z = player.localPosition.z;
}

function OnDeath() {
	deathCam.SetActive(true);
}
