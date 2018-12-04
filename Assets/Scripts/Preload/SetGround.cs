using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGround : MonoBehaviour {
	[SerializeField]private GameObject groundPrefab;

	void Start(){
		CreateGround ();
	}

	private void CreateGround(){
		float x = (-GlobalScr.horizontalExt + groundPrefab.transform.localScale.x);
		float y = -GlobalScr.verticleExt;
		int n = (int)(GlobalScr.horizontalExt / groundPrefab.transform.localScale.x);
		for (int i = 0; i < n; i++) {
			Vector3 pos = new Vector3 (x, y);
			if (x > GlobalScr.horizontalExt)
				return;
			GameObject o = Instantiate (groundPrefab, pos, Quaternion.identity);
			x +=  groundPrefab.transform.localScale.x*2f + 0.7f;
			o.transform.SetParent (transform);
		}
	}
}
