using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuStat : MonoBehaviour {

	private int itemID;
	public int buildID;
	public Text collectedText;
	public Image[] images;
	public int[] items;
	public Text destroyed;

	void Start() {
		itemID = GetComponent<MenuItem>().itemID;
	}

	public void UpdateData() {

		// update collected number and icons
		int collected = 0;
		for(int i = 0; i < items.Length; i++) {
			if(GameManager.Instance.unlockedItems[items[i]]) {
				images[i].sprite = ItemList.Instance.items[items[i]].itemIcon;
				collected++;
			}
		}
		collectedText.text = "Drop collected: " + collected + "/" + items.Length;

		//  update destroyed number

		destroyed.text = "x " + GameManager.Instance.amountObjects[buildID];
	}

}
