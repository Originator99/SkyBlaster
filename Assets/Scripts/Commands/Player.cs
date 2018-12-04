using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private bool dead = false;

	void OnEnable(){
		EventSystem.OnEventStarted += HandleEvent;
	}

	void OnDisable(){
		EventSystem.OnEventStarted -= HandleEvent;
	}

	void HandleEvent(EventType E){
		if (E == EventType.PLAYER_DEAD)
			Debug.Log ("Game Over");
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag("Explosion")) {
			dead = true;
			EventSystem.RaiseEvent (EventType.PLAYER_DEAD);
		}
	}
}
