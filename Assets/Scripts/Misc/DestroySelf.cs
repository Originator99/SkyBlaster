using System.Collections;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

	private float delay = 0.5f;

	void Start () {
		Destroy (gameObject, delay);
	}
}
