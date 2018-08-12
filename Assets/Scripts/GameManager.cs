using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// singleton
	private static GameManager instance;
	public static GameManager Instance {
		get { return instance; }
	}

	// variables
	public Animator menuAnimator;
	public Slider progressBar;
	public Transform itemPanels;

	private int unlockedItemAmount = 0;

	public bool[] unlockedItems;
	public bool[] possibleItems;
	public int[] amountItems;
	public int[] amountObjects;

	// unity functions
	void Awake() {
		if(instance == null) {
			instance = this;
			//DontDestroyOnLoad(this.gameObject);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}
	
	void Start () {
		unlockedItems = new bool[28];
		possibleItems = new bool[28];
		amountItems = new int[28];
		amountObjects = new int[28];

		LoadData.Load();
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

		UpdateProgressBar();
		UpdateIcons();
	}

	public void Stats() {
		MenuStat[] stats = Transform.FindObjectsOfType<MenuStat>();
		foreach(MenuStat stat in stats) {
			stat.UpdateData();
		}
		menuAnimator.Play("MenuToStats");
	}
	public void ExitGame() {
		Application.Quit();
	}
	public void BackCollection() {
		menuAnimator.Play("CollectionToStart");
	}
	public void BackStats() {
		menuAnimator.Play("StatsToStart");
	}
	// update stuff
	public void UpdateProgressBar() {
		unlockedItemAmount = 0;
		foreach(bool unlocked in unlockedItems) {
			if(unlocked) {
				unlockedItemAmount++;
			}
		}
		progressBar.value = unlockedItemAmount;
	}
	public void UpdateIcons() {
		for(int i = 0; i < 28; i++) {
			MenuItem item = GameObject.Find("Item" + i + "Panel").GetComponent<MenuItem>();
			item.Set(unlockedItems[i]);
		}
	}
}
