using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	// variables
	public float destroyTime = 3f;
	
	private float time = 0f;
	private bool collide = false;
	private bool smokeIsPlaying = false, explosionIsPlaying = false;
	private int smokeId;

	// unity functions
	void Update() {
		if(collide)
			time += Time.deltaTime;

		if(time/destroyTime >= 0.3f) {
			if(!smokeIsPlaying) {
				smokeId = EffectController.Instance.PlaySmoke(this.transform.position);

				smokeIsPlaying = true;
			}
		}

		if(time >= destroyTime) {
			if(!explosionIsPlaying) {
				EffectController.Instance.StopSmoke(smokeId);
				EffectController.Instance.PlayExplosion(this.transform.position);
				
				explosionIsPlaying = true;
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
