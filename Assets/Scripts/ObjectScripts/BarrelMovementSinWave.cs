using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovementSinWave : MonoBehaviour {
	private int count;
	private float originalPos;

	void Start(){
		count = 0;
		originalPos = transform.position.y;
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
		}
		if (count == 42) {
			count = 0;
			StopCoroutine ("Shake");
			transform.position = new Vector3(transform.position.x,originalPos +0.08f);
		}
	}

	private IEnumerator Shake(){
		while (true) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + Mathf.Sin (Time.time * 10f) * 0.1f);
			count++;
			yield return null;
		}
	}
}
