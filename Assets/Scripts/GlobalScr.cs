using UnityEngine;

public class GlobalScr {
	public static float verticleExt = Camera.main.orthographicSize;
	public static float horizontalExt = Camera.main.orthographicSize * Screen.width/Screen.height;

	public static float speed = 5f;

	public static bool flipped = false;
}
