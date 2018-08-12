using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour {

	// singleton
	private static FinishController instance;
	public static FinishController Instance {
		get { return instance; }
	}

	// variables
	public bool isFinish = false, isAwake = false;
	public Animator gameAnim;

	public Text[] itemText;
	public Text newItems;

	public Image finishBlackPanel;
	public GenerateMap generateMap;

	private float finishTimer = 0;
	private bool darker = false, generated = false;

	// unity functions
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}
	
	void Update () {
		if(!generated) {
			generated = generateMap.Generate();
			return;
		}

		if(!isAwake) {
			if(finishBlackPanel.color.a >= 0f) 
				finishBlackPanel.color -= new Color(0, 0, 0, 0.03f);
			else {
				finishBlackPanel.enabled = false;
				isAwake = true;
			}
		}
 		
		if(Input.GetKeyDown(KeyCode.Escape)) {
			finishTimer = 3f;
			isFinish = true;
		}

		if(!isFinish) 
			return;

		finishTimer += Time.deltaTime;

		if(finishTimer >= 4.5f) {
			SceneManager.LoadScene(0);
		} else if(finishTimer >= 3f) {
			finishBlackPanel.enabled = true;
			if(finishBlackPanel.color.a <= 1f)
				finishBlackPanel.color += new Color(0, 0, 0, 0.03f);
		} 

	}

	// finish controller functions

	public void FinishGame() {
		isFinish = true;
		gameAnim.SetBool("isFinish", isFinish);

		// update item texts
		for(int i = 0; i < ItemList.Instance.itemsInInventory; i++) {
			itemText[i].text = ItemList.Instance.itemPanels[i].item.itemName;
		}
		// add unlocked items
		for(int i = 0; i < ItemList.Instance.itemsInInventory; i++) {
			int item = ItemList.Instance.itemPanels[i].item.itemID;
			GameManager.Instance.unlockedItems[item] = true; // is unlocked
			GameManager.Instance.amountItems[item]++;
		}

		// check if is something new possible
		CheckForPossible();
		SaveData.Save();
	}
	// make possible new items
	void CheckForPossible() {
		
		int newPossibleItems = 0;
		// 7 pocket guy
		if(!GameManager.Instance.possibleItems[7]) {
			if(GameManager.Instance.amountObjects[6] >= 3) { // 3 tower d
				GameManager.Instance.possibleItems[7] = true;
				newPossibleItems++;
			}
		}
		// 9 u-boot
		if(!GameManager.Instance.possibleItems[9]) {
			if(GameManager.Instance.amountItems[3] >= 5) { // 5 water
				GameManager.Instance.possibleItems[9] = true;
				newPossibleItems++;
			}
		}
		// 10 golden shovel
		if(!GameManager.Instance.possibleItems[10]) {
			if(GameManager.Instance.amountItems[5] >= 2  && // 2 fire
			   GameManager.Instance.amountItems[2] >= 4  && // 4 stone
			   GameManager.Instance.amountItems[0] >= 2) {  // 2 wood
				GameManager.Instance.possibleItems[10] = true;
				newPossibleItems++;
			}
		}
		// 11 door to woods
		if(!GameManager.Instance.possibleItems[11]) {
			if(GameManager.Instance.amountItems[0] >= 5  && // 2 wood
			   GameManager.Instance.amountItems[1] >= 3) { // 5 apple
				GameManager.Instance.possibleItems[11] = true;
				newPossibleItems++;
			}
		}
		// 12 dimensional gun
		if(!GameManager.Instance.possibleItems[12]) {
			if(GameManager.Instance.amountItems[5] >= 3  && // 3 fire
			   GameManager.Instance.amountItems[6] >= 3  && // 3 food
			   GameManager.Instance.amountItems[7] >= 1) { // 1 pocket guy
				GameManager.Instance.possibleItems[12] = true;
				newPossibleItems++;
			}
		}
		// 13 flip-flops
		if(!GameManager.Instance.possibleItems[13]) {
			if(GameManager.Instance.amountItems[4] >= 3  && // 3 trash
			   GameManager.Instance.amountItems[5] >= 3  && // 3 fire
			   GameManager.Instance.amountObjects[11] >= 1) { // 1 llama d
				GameManager.Instance.possibleItems[13] = true;
				newPossibleItems++;
			}
		}
		// 14 horse mask
		if(!GameManager.Instance.possibleItems[14]) {
			if(GameManager.Instance.amountObjects[4] >= 4  && // 3 stable d
			   GameManager.Instance.amountItems[8] >= 5) {  // 5 paper roll
				GameManager.Instance.possibleItems[14] = true;
				newPossibleItems++;
			}
		}
		// 15 living word
		if(!GameManager.Instance.possibleItems[15]) {
			if(GameManager.Instance.amountObjects[10] >= 1  && // 1 guy d
			   GameManager.Instance.amountItems[7] >= 1) {  // 1 pocket guy
				GameManager.Instance.possibleItems[15] = true;
				newPossibleItems++;
			}
		}
		// 16 jezus
		if(!GameManager.Instance.possibleItems[16]) {
			if(GameManager.Instance.amountItems[3] >= 5  && // 5 water
			   GameManager.Instance.amountItems[17] >= 1  && // 1 christmas lights
			   GameManager.Instance.amountItems[6] >= 3) {  // 3 food
				GameManager.Instance.possibleItems[16] = true;
				newPossibleItems++;
			}
		}
		// 17 christmas lights
		if(!GameManager.Instance.possibleItems[17]) {
			if(GameManager.Instance.amountItems[5] >= 5  && // 5 fire
			   GameManager.Instance.amountObjects[8] >= 3) {  // 3 plash d
				GameManager.Instance.possibleItems[17] = true;
				newPossibleItems++;
			}
		}
		// 18 llama
		if(!GameManager.Instance.possibleItems[18]) {
			if(GameManager.Instance.amountObjects[11] >= 4) {  // 4 llama d
				GameManager.Instance.possibleItems[18] = true;
				newPossibleItems++;
			}
		}
		// 19 shrek
		if(!GameManager.Instance.possibleItems[19]) {
			if(GameManager.Instance.amountItems[4] >= 7  && // 7 trash
			   GameManager.Instance.amountObjects[8] >= 3) {  // 3 plash d
				GameManager.Instance.possibleItems[19] = true;
				newPossibleItems++;
			}
		}
		// 20 silver sword
		if(!GameManager.Instance.possibleItems[20]) {
			if(GameManager.Instance.amountObjects[7] >= 7  && // 7 rock d
			   GameManager.Instance.amountObjects[0] >= 3) {  // 3 castle d
				GameManager.Instance.possibleItems[20] = true;
				newPossibleItems++;
			}
		}
		// 21 infinity glove
		if(!GameManager.Instance.possibleItems[21]) {
			if(GameManager.Instance.amountObjects[10] >= 3  && // 3 guy d
			   GameManager.Instance.amountItems[8] >= 5) {  // 5 paper roll
				GameManager.Instance.possibleItems[21] = true;
				newPossibleItems++;
			}
		}
		// 22 meme
		if(!GameManager.Instance.possibleItems[22]) {
			if(GameManager.Instance.amountObjects[1] >= 10  && // 10 house d
			   GameManager.Instance.amountItems[4] >= 5) {  // 5 trash
				GameManager.Instance.possibleItems[22] = true;
				newPossibleItems++;
			}
		}
		// 23 magic ore
		if(!GameManager.Instance.possibleItems[23]) {
			if(GameManager.Instance.amountItems[5] >= 5  && // 5 fire
			   GameManager.Instance.amountItems[2] >= 8  && // 8 stone
			   GameManager.Instance.amountItems[12] >= 1) {  // 1 dimensional gun
				GameManager.Instance.possibleItems[23] = true;
				newPossibleItems++;
			}
		}
		// 24 planet destroyer
		if(!GameManager.Instance.possibleItems[24]) {
			if(GameManager.Instance.amountItems[23] >= 1  && // 1 magic ore
			   GameManager.Instance.amountItems[19] >= 1  && // 1 shrek
			   GameManager.Instance.amountObjects[11] >= 5) {  // 5 llama d
				GameManager.Instance.possibleItems[24] = true;
				newPossibleItems++;
			}
		}
		// 25 expensive painting
		if(!GameManager.Instance.possibleItems[25]) {
			if(GameManager.Instance.amountItems[4] >= 10  && // 10 trash
			   GameManager.Instance.amountItems[17] >= 1) {  // 1 chrismas lights
				GameManager.Instance.possibleItems[25] = true;
				newPossibleItems++;
			}
		}
		// 26 estus flash
		if(!GameManager.Instance.possibleItems[26]) {
			if(GameManager.Instance.amountItems[23] >= 1  && // 1 magic ore
			   GameManager.Instance.amountObjects[9] >= 5  && // 5 bonfire d
			   GameManager.Instance.amountItems[3] >= 10) {  // 10 water
				GameManager.Instance.possibleItems[26] = true;
				newPossibleItems++;
			}
		}
		// 27 gtx 2000 series
		if(!GameManager.Instance.possibleItems[27]) {
			if(GameManager.Instance.amountItems[0] >= 1  && 
			   GameManager.Instance.amountItems[1] >= 1  && 
			   GameManager.Instance.amountItems[2] >= 1  && 
			   GameManager.Instance.amountItems[3] >= 1  && 
			   GameManager.Instance.amountItems[4] >= 1  && 
			   GameManager.Instance.amountItems[5] >= 1  && 
			   GameManager.Instance.amountItems[6] >= 1  && 
			   GameManager.Instance.amountItems[7] >= 1  && 
			   GameManager.Instance.amountItems[8] >= 1  && 
			   GameManager.Instance.amountItems[9] >= 1  && 
			   GameManager.Instance.amountItems[10] >= 1  && 
			   GameManager.Instance.amountItems[11] >= 1  && 
			   GameManager.Instance.amountItems[12] >= 1  && 
			   GameManager.Instance.amountItems[13] >= 1  && 
			   GameManager.Instance.amountItems[14] >= 1  && 
			   GameManager.Instance.amountItems[15] >= 1  && 
			   GameManager.Instance.amountItems[16] >= 1  && 
			   GameManager.Instance.amountItems[17] >= 1  && 
			   GameManager.Instance.amountItems[18] >= 1  && 
			   GameManager.Instance.amountItems[19] >= 1  && 
			   GameManager.Instance.amountItems[20] >= 1  && 
			   GameManager.Instance.amountItems[21] >= 1  && 
			   GameManager.Instance.amountItems[22] >= 1  && 
			   GameManager.Instance.amountItems[23] >= 1  && 
			   GameManager.Instance.amountItems[24] >= 1  && 
			   GameManager.Instance.amountItems[25] >= 1  && 
			   GameManager.Instance.amountItems[26] >= 1) {
				GameManager.Instance.possibleItems[27] = true;
				newPossibleItems++;
			}
		}
		
		newItems.text = newPossibleItems.ToString();
	}

	
}
