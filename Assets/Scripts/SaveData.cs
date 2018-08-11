using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

	public void Save() {

		for(int i = 0; i < 25; i++) {
			// load ulocked items
			PlayerPrefs.SetInt("unlockedItem" + i, GameManager.Instance.unlockedItems[i] ? 1 : 0);

			// load possible items
			PlayerPrefs.SetInt("possibleItem" + i, GameManager.Instance.possibleItems[i] ? 1 : 0);
		}


		PlayerPrefs.Save();
	}
}
