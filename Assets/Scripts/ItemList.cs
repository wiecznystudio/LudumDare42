using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour {
	
	//singleton
	private static ItemList instance;
	public static ItemList Instance {
		get { return instance; }
	}

	// variables
	public Item[] items;
	public GameObject itemPattern;
	public int itemsInInventory = 0;

	public ItemPanel[] itemPanels;
	public Text scoreText;
	public float score = 0f;
	public float newScore = 0f;

	private List<GameObject> newItems = new List<GameObject>();
	private List<int> newItemDest = new List<int>();
	private List<int> newItemID = new List<int>();

	// unity functions
	void Awake() {
		if(instance == null) {
			instance = this;
			//DontDestroyOnLoad(this);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}

	void Update() {

		if(score != newScore) {
			score = Mathf.Lerp(score, newScore, 0.04f);
			scoreText.text = Mathf.Round(score).ToString();
		}

		// if max amount just finish game
		if(itemsInInventory >= 6 && newItems.Count <= 0) {
			if(!FinishController.Instance.isFinish)
				FinishController.Instance.FinishGame();
		}

		// move item from object to ui
		for(int i = 0; i < newItems.Count; i++) {
			// lerp of items positions to ui positions
			newItems[i].transform.position = Vector3.Lerp(newItems[i].transform.position, 
			Camera.main.ScreenToWorldPoint(itemPanels[newItemDest[i]].transform.position), Time.deltaTime*4f);

			// if distance is small destroy flying object and create ui item element
			if(Vector3.Distance(newItems[i].transform.position, Camera.main.ScreenToWorldPoint(itemPanels[newItemDest[i]].transform.position)) <  1f) {
				itemPanels[newItemDest[i]].UpdateData(items[newItemID[i]]);
				Destroy(newItems[i]);
				newItems.Remove(newItems[i]);
				newItemDest.Remove(newItemDest[i]);
				newItemID.Remove(newItemID[i]);
			}
		}
	}

	// item list functions
	public void AddItem(int itemID, Vector3 pos) {
		// max amount limited
		if(itemsInInventory >= 6)
			return;

		pos.z = -4f;
		GameObject newItem = Instantiate(itemPattern, pos, Quaternion.identity);
		newItem.GetComponent<SpriteRenderer>().sprite = items[itemID].itemIcon;
		newItems.Add(newItem);
		newItemDest.Add(itemsInInventory);
		newItemID.Add(itemID);
		newScore += items[itemID].score;
		itemsInInventory++;
	}


}
