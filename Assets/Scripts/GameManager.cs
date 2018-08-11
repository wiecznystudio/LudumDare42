using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// singleton
	private static GameManager instance;
	public static GameManager Instance {
		get { return instance; }
	}

	// variables
	public Animator menuAnimator;

	public bool[] unlockedItems = new bool[25];
	public bool[] possibleItems = new bool[25];

	// unity functions
	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}
	
	void Start () {
		
	}

	void Update () {
		
	}

	// game manager functions

	// menu functions
	public void StartGame() {
		SceneManager.LoadScene(1);
	}
	public void Collection() {
		menuAnimator.Play("MenuToCollection");
	}
	public void ExitGame() {
		Application.Quit();
	}
}
