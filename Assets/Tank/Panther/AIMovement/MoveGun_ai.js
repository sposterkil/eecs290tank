#pragma strict

var speed : float = 15;
var curRotation : float = 0;

	// Gun Down
function gunDown() {
	if(curRotation > -5) {
		transform.Rotate(Vector3(speed * Time.deltaTime, 0, 0));
		curRotation -= speed * Time.deltaTime;
	}
}


	// Gun Up
function gunUp() {
	if(curRotation < 45) {
		transform.Rotate(Vector3(-speed * Time.deltaTime, 0, 0));
		curRotation += speed * Time.deltaTime;
	}
}
