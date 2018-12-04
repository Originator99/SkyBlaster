using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MoveBarrel : MonoBehaviour {
	private int count;
	private float originalPosY;
	private int maxBarrels, barrelNo;
	[SerializeField]private GameObject greenObjPreb, redObjPrefab;

	void Start(){
		count = 0;
		maxBarrels = transform.childCount;
		InvokeRepeating ("ShakeBarrel", 1f, 1f);
	}

	void Update () {
		if (count == 42) {
			count = 0;
			StopAllCoroutines ();
			transform.GetChild(barrelNo).position = new Vector3(transform.GetChild(barrelNo).position.x,originalPosY );

		}
	}

	private void ShakeBarrel(){
		barrelNo = Random.Range (0, maxBarrels);
		originalPosY = transform.GetChild (barrelNo).position.y;
		InstObj (transform.GetChild(barrelNo).name);
		StartCoroutine (Shake (transform.GetChild (barrelNo)));
	}

	private IEnumerator Shake(Transform t){
		while (true) {
			t.position = new Vector3 (t.position.x, t.position.y + Mathf.Sin (Time.time * 10f) * 0.1f);
			count++;
			yield return null;
		}
	}

	private void InstObj(string name){
		Vector3 parentPos = transform.GetChild (barrelNo).position;
		Vector3 pos = new Vector3 (parentPos.x, parentPos.y, 0f);
		if (name.Contains ("Green")) {
			Instantiate (greenObjPreb, pos, Quaternion.identity);
			return;
		}
			Instantiate (redObjPrefab, pos, Quaternion.identity);
	}
}
