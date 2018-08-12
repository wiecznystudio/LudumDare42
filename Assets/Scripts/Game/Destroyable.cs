using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	// variables
	public Sprite destroySprite;
	public float destroyTime = 3f;
	
	private float time = 0f;
	private bool collide = false;
	private bool smokeIsPlaying = false, explosionIsPlaying = false;
	private int smokeId;

	// items
	public int objectID;
	public int[] itemDrop;

	// unity functions
	void Update() {
		if(collide)
			time += Time.deltaTime;

		if(time/destroyTime >= 0.3f) {
			if(!smokeIsPlaying) { // play smoke anim after 30% of destroy time
				smokeId = EffectController.Instance.PlaySmoke(this.transform.position);

				smokeIsPlaying = true;
			}
		}

		if(time >= destroyTime) {
			if(!explosionIsPlaying) { // play explosion anim
				EffectController.Instance.StopSmoke(smokeId);
				EffectController.Instance.PlayExplosion(this.transform.position);
				
				explosionIsPlaying = true;
				this.GetComponent<Collider2D>().enabled = false;
				this.GetComponent<SpriteRenderer>().sprite = destroySprite;
				GameManager.Instance.amountObjects[objectID]++;
				ChooseItem();
			}
		}
	}

	// object functions

	void ChooseItem() {
		for(int i = itemDrop.Length-1; i >= 0; i--) { // for every possible drop
			if(GameManager.Instance.possibleItems[itemDrop[i]]) { // check if its possible (unlocked)
				float percent = Random.Range(0f, 100f); // calculate chance
				if(percent <= ItemList.Instance.items[itemDrop[i]].chance) { // if win add item
					ItemList.Instance.AddItem(itemDrop[i], this.transform.position);
					return;
				}
			}
		}
	}

	// check if player is on object
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag != "Player")
			return;
		collide = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		//time = 0f;	
		collide = false;
	}
}
