using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour {

	// singleton
	private static CollectionController instance;
	public static CollectionController Instance { 
		get { return instance; }
	}

	// variables
	public GameObject panel;

	public Image image;
	public Text name;
	public Text desc;
	public Text rare;
	public Text number;

	// unity functions
	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}

	// collection controller functions
	public void OpenInfoWindow(Item item) {
		panel.SetActive(true);

		image.sprite = item.itemIcon;
		name.text = item.itemName;
		desc.text = item.itemDesc;
		rare.color = item.rare;
		if(item.rareC == 0) {
			rare.text = "Common";
		} else if(item.rareC == 1) {
			rare.text = "Rare";
		} else rare.text = "Legendary";
		number.text = "x " + GameManager.Instance.amountItems[item.itemID].ToString();
	}

	public void CloseInfoWindow() {
		panel.SetActive(false);
	}

}
