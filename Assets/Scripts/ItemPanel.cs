using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour {

	public Item item;
	public Image itemImage;

	public void UpdateData(Item newItem) {
		item = newItem;
		itemImage.sprite = item.itemIcon;
		itemImage.color = new Color32(255, 255, 255, 255);
		GetComponent<Image>().color = new Color32(120, 72, 94, 255);
	}
}
