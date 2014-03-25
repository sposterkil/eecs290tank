#pragma strict

var speed : float = 200;
var range : float = 400;

var ExploPtcl : GameObject;
var destroyed1 : GameObject;
var destroyed2 : GameObject;
var destroyed3 : GameObject;
var destroyed4 : GameObject;

private var dist : float;

function Start () {
	destroyed1 = Resources.Load("Destroyed Tanks/TankDestroyed1");
	destroyed2 = Resources.Load("Destroyed Tanks/TankDestroyed2");
	destroyed3 = Resources.Load("Destroyed Tanks/TankDestroyed3");
	destroyed4 = Resources.Load("Destroyed Tanks/TankDestroyed4");
}

function Update () {

	// Move Ball forward
	transform.Translate(Vector3.forward * Time.deltaTime * speed);

	// Record Distance.
	dist += Time.deltaTime * speed;

	// If reach to my range, Destroy.
	if(dist >= range) {
		Instantiate(ExploPtcl, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}


function OnTriggerEnter(other: Collider){
	// If hit something, Destroy self.  If it's an enemy, destroy it.
	Instantiate(ExploPtcl, transform.position, transform.rotation);
	if (other.tag == "enemy" || other.tag == "friendly"){
        Destroy(other.gameObject);
        switch(UnityEngine.Random.Range(1, 4)){
            case 1:
                Instantiate(destroyed1, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(destroyed2, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(destroyed3, transform.position, transform.rotation);
                break;
            case 4:
                Instantiate(destroyed4, transform.position, transform.rotation);
                break;
        }
	}
	Destroy(gameObject);

}

