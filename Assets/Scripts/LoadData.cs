using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	public static void Load() {
		
		for(int i = 0; i < 28; i++) {
			// load ulocked items
			int unlocked = PlayerPrefs.GetInt("unlockedItem" + i, 0);
			GameManager.Instance.unlockedItems[i] = (unlocked == 1);

			// load possible items
			int possible = PlayerPrefs.GetInt("possibleItem" + i, 0);
			GameManager.Instance.possibleItems[i] = (possible == 1);
		}
		// default value
		GameManager.Instance.possibleItems[0] = true;
		GameManager.Instance.possibleItems[1] = true;
		GameManager.Instance.possibleItems[2] = true;
		GameManager.Instance.possibleItems[3] = true;
		GameManager.Instance.unlockedItems[0] = true;
		GameManager.Instance.unlockedItems[1] = true;
		GameManager.Instance.unlockedItems[11] = true;
		
	}
}
