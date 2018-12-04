using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour {
	
	Animator anim;

	void Start(){
		anim = gameObject.GetComponent<Animator> ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			anim.SetTrigger ("Throw");
		}
	}

	void moveB(){
		
	}
}
