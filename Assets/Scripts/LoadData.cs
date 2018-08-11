using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	public void Load() {
		
		for(int i = 0; i < 25; i++) {
			// load ulocked items
			int unlocked = PlayerPrefs.GetInt("unlockedItem" + i, 0);
			GameManager.Instance.unlockedItems[i] = (unlocked == 1);

			// load possible items
			int possible = PlayerPrefs.GetInt("possibleItem" + i, 0);
			GameManager.Instance.possibleItems[i] = (possible == 1);
		}
		// default value
		GameManager.Instance.possibleItems[0] = true;
		
	}
}
