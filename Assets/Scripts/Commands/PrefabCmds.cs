using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCmds : MonoBehaviour {

	public GameObject explosionPrefab;
	public LayerMask layerMask;

	private bool exploded = false;
	private float turnSpeed = 120f;

	void OnEnable(){
		EventSystem.OnEventStarted += HandleEvent;	
	}

	void OnDisable(){
		EventSystem.OnEventStarted -= HandleEvent;
	}
	
	void Update () {
		transform.Rotate (turnSpeed * Time.deltaTime * Vector3.forward);
		if (transform.position.y < -GlobalScr.verticleExt - 1f)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (gameObject.tag == "PowerUp" && col.collider.tag == "Player") {
			EventSystem.RaiseEvent (EventType.POWER_UP);
			Destroy (gameObject);
			return;
		}
		if (!exploded && col.collider.tag == "Ground") {
			if (gameObject.tag == "PowerUp") {
				Destroy (gameObject, 2f);
				return;
			}
			CancelInvoke ("Explode");
			Invoke ("Explode", 0.5f);
		}
	}

	private void Explode(){
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		StartCoroutine (CreateExplosion (Vector3.forward));
		StartCoroutine (CreateExplosion (Vector3.right));
		StartCoroutine (CreateExplosion (Vector3.back));
		StartCoroutine (CreateExplosion (Vector3.left));
		GetComponent<SpriteRenderer> ().enabled = false;
		exploded = true;
		GetComponent<BoxCollider2D>().enabled = false;
		Invoke ("DestroyObj", 0.2f);
	}

	private IEnumerator CreateExplosion(Vector3 direction){
		for (int i = 0; i < 2; i++) {
			RaycastHit hit;
			Physics.Raycast (transform.position + new Vector3 (0f, 0.5f, 0f), direction, out hit, i, layerMask);
			if (!hit.collider) {
				Instantiate (explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
			} else
				break;
			yield return new WaitForSeconds (0.1f);
		}
	}

	private void DestroyObj(){
		Destroy (this.gameObject);
	}

	void HandleEvent(EventType E){
		if (E == EventType.POWER_UP) {
			Debug.Log ("Power Up Taken");
		}
	}
}
