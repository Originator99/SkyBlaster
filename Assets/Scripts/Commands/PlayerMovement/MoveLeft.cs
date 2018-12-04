using UnityEngine;

public class MoveLeft : ICommands {
	public void Execute(Transform t){
		if (!GlobalScr.flipped) {
			t.localScale = new Vector3 (t.localScale.x * -1, t.localScale.y, t.localScale.z);
			GlobalScr.flipped = true;
		}
		t.Translate (new Vector3 (-GlobalScr.speed * Time.deltaTime, 0f, 0f));
	}
}
