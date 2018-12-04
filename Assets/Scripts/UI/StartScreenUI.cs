using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour {
	[SerializeField]private Button startBtn;

	void Start(){
		startBtn.onClick.AddListener (StartClick);
	}

	private void StartClick(){
		SceneManager.LoadScene ("MainGame");
	}
}
