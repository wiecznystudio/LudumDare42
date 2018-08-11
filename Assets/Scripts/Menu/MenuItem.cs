using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour {

	public Image itemImage;

	public void Set(bool active) {
		if(active) {
			itemImage.color = new Color32(255, 255, 255, 255);
		} else itemImage.color = new Color32(25, 255 ,255, 0);
	}
}
