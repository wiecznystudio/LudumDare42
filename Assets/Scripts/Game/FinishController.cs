using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour {

	// singleton
	private static FinishController instance;
	public static FinishController Instance {
		get { return instance; }
	}

	// variables
	public bool isFinish = false;
	public Animator gameAnim;

	public Text[] itemText;
	public Text newItems;

	// unity functions
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}
	
	void Update () {
		
	}

	// finish controller functions

	public void FinishGame() {
		isFinish = true;
		gameAnim.SetBool("isFinish", isFinish);

		// update item texts
		for(int i = 0; i < ItemList.Instance.itemsInInventory; i++) {
			itemText[i].text = ItemList.Instance.itemPanels[i].item.itemName;
		}

		// add unlocked items
		for(int i = 0; i < ItemList.Instance.itemsInInventory; i++) {
			int item = ItemList.Instance.itemPanels[i].item.itemID;
			GameManager.Instance.unlockedItems[item] = true; // is unlocked
			GameManager.Instance.amountItems[item]++;
		}

		// check if is something new possible
		CheckForPossible();
		SaveData.Save();
	}

	void CheckForPossible() {
		
		int newPossibleItems = 0;

		if(!GameManager.Instance.possibleItems[3]) {
			// to do
		}
		
		newItems.text = newPossibleItems.ToString();
	}

	// interface buttons logic

	public void Restart() {
		SceneManager.LoadScene(1);
	}

	public void Exit() {
		SceneManager.LoadScene(0);
	}
}
