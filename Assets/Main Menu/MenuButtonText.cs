using UnityEngine;
using System.Collections;

public class MenuButtonText: MonoBehaviour 
{
	public bool isQuit;
	public bool isStart;

	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
	}
	

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown() {
		if(isStart) {
			Application.LoadLevel(1);
		}
		else if(isQuit) {
			Application.Quit();
		}
		else {
		}
	}
}