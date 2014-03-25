#pragma strict

var speed : float = 30;

	// Turn Right
function turretRight(){
	transform.Rotate(Vector3(0, speed * Time.deltaTime, 0));
}
 	// Turn Left
function turretLeft() {
	transform.Rotate(Vector3(0, -speed * Time.deltaTime, 0));
}