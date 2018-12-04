using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EnemyBox")
			Explode (col);
		else if (col.tag == "PowerUp")
			Debug.Log ("Power Up");
	}

	private void Explode(Collider2D col){
		Destroy (col.gameObject);
	}
}
