using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

	// variables
	public float speed = 2f;

	private Vector3 destination;
	private Camera cam;
	private Animator[] guysAnim;
	private SpriteRenderer[] renderers;
	private float[] animTime;
	private bool isMoving = false;
	private bool isCollide = false;

	// unity functions
	void Start () {
		cam = Camera.main;
		guysAnim = GetComponentsInChildren<Animator>();
		renderers = GetComponentsInChildren<SpriteRenderer>();
		animTime = new float[guysAnim.Length];
		SetAnimation("GuyIdle");
	}
	
	void Update () {
		// player gang movement
		if(Input.GetMouseButtonDown(0) && !FinishController.Instance.isFinish) {
			Vector2 mousePos = Input.mousePosition;
			destination = cam.ScreenToWorldPoint(mousePos);
			destination.z = transform.position.z;
			if(!SoundManager.Instance.IsPlaying()) SoundManager.Instance.Play(0);
		}


		if(destination != transform.position) {
			if(destination == Vector3.zero)
				return;
			
			Vector3 heading = new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, 0);
			heading.Normalize();

			transform.position += heading * speed * Time.deltaTime;

			// sprite flip x
			if(heading.x > 0f) {
				FlipX(false);
			} else {
				FlipX(true);
			}
			
			// move anim
			if(!isMoving) {
				SetAnimation("GuyMove");
				isMoving = true;
			}

			if(isCollide) {
				//RandomFlipX();	
				return;
			}

			// stop if almost in destination
			if(Vector3.Distance(transform.position, destination) <= 0.05f) {
				transform.position = destination;
				destination = Vector3.zero;
				SetAnimation("GuyIdle");
				isMoving = false;
				SoundManager.Instance.Stop();
			}
		}
	}
	// destrony anim when on object
	void OnTriggerStay2D(Collider2D other) {
		if(Vector3.Distance(transform.position, destination) <= 0.05f) 
			SoundManager.Instance.Stop();

		 if(isCollide)
		 	return;

		if(Vector3.Distance(transform.position, destination) <= 0.05f)
			SetAnimation("GuyDestroy");	

		isCollide = true;
	}
	void OnTriggerExit2D(Collider2D other) {
		isCollide = false;
		isMoving = false;
	}

	// player controller functions
	void FlipX(bool x) {
		foreach(SpriteRenderer sr in renderers) {
			sr.flipX = x;
		}
	}
	void RandomFlipX() {
		foreach(SpriteRenderer sr in renderers) {
			int random = Random.Range(0, 2);
			if(random == 0) sr.flipX = false;
			else sr.flipX = true;
		}
	}
	void SetAnimation(string animation) {
		for(int i = 0; i < animTime.Length; i++) {
			animTime[i] = Random.Range(0.0f, 0.5f);
			guysAnim[i].Play(animation, -1, animTime[i]);
			guysAnim[i].speed = animTime[i] + 0.7f;
		}
	}
}
