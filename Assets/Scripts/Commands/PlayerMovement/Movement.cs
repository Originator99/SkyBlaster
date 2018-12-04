using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private MoveLeft ml;
	private MoveRight mr;
	private Animator anim;

	void Start(){
		ml = new MoveLeft ();
		mr = new MoveRight ();
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			ml.Execute (transform);
			anim.SetBool ("Run", true);
			anim.Play ("PlayerRun");
		}
		if (Input.GetKey (KeyCode.D)) {
			mr.Execute (transform);
			anim.SetBool ("Run", true);
			anim.Play ("PlayerRun");
		}
		anim.SetBool ("Run", false);
	}
}
