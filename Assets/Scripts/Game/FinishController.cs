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
	public bool isFinish = false, isAwake = false;
	public Animator gameAnim;

	public Text[] itemText;
	public Text newItems;

	public Image finishBlackPanel;
	public GenerateMap generateMap;

	private float finishTimer = 0;
	private bool darker = false, generated = false;

	// unity functions
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}
	
	void Update () {
		if(!generated) {
			generated = generateMap.Generate();
			return;
		}

		if(!isAwake) {
			if(finishBlackPanel.color.a >= 0f) 
				finishBlackPanel.color -= new Color(0, 0, 0, 0.03f);
			else {
				finishBlackPanel.enabled = false;
				isAwake = true;
			}
		}
 		
		if(Input.GetKeyDown(KeyCode.Escape)) {
			finishTimer = 3f;
			isFinish = true;
		}

		if(!isFinish) 
			return;

		finishTimer += Time.deltaTime;

		if(finishTimer >= 4.5f) {
			SceneManager.LoadScene(0);
		} else if(finishTimer >= 3f) {
			finishBlackPanel.enabled = true;
			if(finishBlackPanel.color.a <= 1f)
				finishBlackPanel.color += new Color(0, 0, 0, 0.03f);
		} 

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

	
}
