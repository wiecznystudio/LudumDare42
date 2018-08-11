using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

	// variables
	public Transform playerGang;
	public float speed = 3f;

	private Vector3 destination;
	private Camera cam;
	private Animator[] guysAnim;
	private float[] animTime;
	private bool isMoving = false;

	// unity functions
	void Start () {
		cam = Camera.main;
		guysAnim = GetComponentsInChildren<Animator>();
		animTime = new float[guysAnim.Length];
		SetAnimation("GuyIdle");
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePos = Input.mousePosition;
			destination = cam.ScreenToWorldPoint(mousePos);
			destination.z = transform.position.z;
		}

		if(destination != transform.position) {
			if(destination == Vector3.zero)
				return;
			
			Vector3 heading = new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, 0);
			heading.Normalize();

			transform.position += heading * speed * Time.deltaTime;
			
			if(!isMoving) {
				SetAnimation("GuyMove");
				isMoving = true;
			}

			if(Vector3.Distance(transform.position, destination) <= 0.05f) {
				transform.position = destination;
				destination = Vector3.zero;
				SetAnimation("GuyIdle");
				isMoving = false;
			}
		}
	}

	// player controller functions


	void SetAnimation(string animation) {
		// foreach(Animator anim in guysAnim) {
		// 	anim.SetBool("isMoving", moving);
		// }
		for(int i = 0; i < animTime.Length; i++) {
			animTime[i] = Random.Range(0.0f, 0.5f);
			guysAnim[i].Play(animation, -1, animTime[i]);
		}
	}
}
