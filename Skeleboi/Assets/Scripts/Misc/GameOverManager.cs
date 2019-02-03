using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Life.SharedLifeVariable.lives = 3;
	}

	public void Retry(){
		SceneManager.LoadScene("DragNDropIntro", LoadSceneMode.Single);
	}

	public void Quit(){
		SceneManager.LoadScene("Menu1", LoadSceneMode.Single);
	}
}
