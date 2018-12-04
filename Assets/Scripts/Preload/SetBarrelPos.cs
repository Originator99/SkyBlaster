using UnityEngine;

public class SetBarrelPos : MonoBehaviour {
	[SerializeField]private Transform topLane;
	private float diffY;

	void Start(){
		setDiff ();
		setPositions ();
		InvokeRepeating ("Shuffle", 0f, 4f);
	}

	private void setPositions(){
		float x = GlobalScr.horizontalExt;
		float y = GlobalScr.verticleExt;

		float xScale = topLane.GetChild (0).localScale.x / 2f + 0.5f;
		float yScale = topLane.GetChild (0).localScale.y / 2f;

		topLane.GetChild (0).position = new Vector3 (-x + xScale, (y - yScale) + diffY, 0f);

		setRestOfThePositions ();
	}

	private void setRestOfThePositions(){
		int n = topLane.childCount -1;
		float xDiff = GlobalScr.horizontalExt / topLane.childCount;
		float nextX = topLane.GetChild (0).position.x + xDiff  * 2 ;
		float y = topLane.GetChild (0).position.y;
		for (int i = 1; i <= n; i++) {
			topLane.GetChild (i).position = new Vector3 (nextX, y, 0f);
			xDiff = GlobalScr.horizontalExt / topLane.childCount;
			nextX = topLane.GetChild (i).position.x + xDiff  * 2 ;
		}
	}

	private void Shuffle(){
		int n = topLane.childCount;
		Vector3[] positions = new Vector3[n];
		for (int i = 0; i < n; i++) {
			positions [i] = topLane.GetChild (i).position;
		}
		for (int i = 0; i < n; i++) {
			Vector3 temp = positions [i];
			int r = Random.Range (i, n);
			positions [i] = positions [r];
			positions [r] = temp;
		}
		for (int i = 0; i < n; i++) {
			topLane.GetChild (i).position = positions [i];
		}
	}

	private void setDiff(){
		diffY = topLane.GetChild (0).localScale.y * 0.23f;
	}
}
