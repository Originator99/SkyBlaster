using UnityEngine;

public class EventSystem {
	public delegate void OnEvent(EventType E);
	public static event OnEvent OnEventStarted;

	public static void RaiseEvent(EventType E){
		if (OnEventStarted != null)
			OnEventStarted (E);
	}
}
