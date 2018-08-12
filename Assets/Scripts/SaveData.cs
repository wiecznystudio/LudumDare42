using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {
	
	public static void Save() {

		for(int i = 0; i < 28; i++) {
			// save ulocked items
			PlayerPrefs.SetInt("unlockedItem" + i, GameManager.Instance.unlockedItems[i] ? 1 : 0);

			// save possible items
			PlayerPrefs.SetInt("possibleItem" + i, GameManager.Instance.possibleItems[i] ? 1 : 0);

			// save amount of items
			PlayerPrefs.SetInt("amountItem" + i, GameManager.Instance.amountItems[i]);
		}

		PlayerPrefs.Save();
	}
}
