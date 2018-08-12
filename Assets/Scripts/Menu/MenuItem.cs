using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour {

	public Image itemImage;
	public int itemID = 0;

	public void Set(bool active) {
		if(active) {
			itemImage.color = new Color32(255, 255, 255, 255);
		} else itemImage.color = new Color32(25, 255 ,255, 0);
	}

	public void SendData() {
		if(GameManager.Instance.unlockedItems[itemID])
			CollectionController.Instance.OpenInfoWindow(ItemList.Instance.items[itemID]);
	}
	

}
