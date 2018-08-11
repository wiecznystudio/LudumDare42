using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector2 offset;
	public float smooth;

	public float shakePower = 0.5f;
	
	private float shakeTime = 0f;
	private bool isShaking = false;

	void Update () {
		if(target == null)
			return;

		// lerp camera to player gang
		Vector3 destination = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, this.transform.position.z);
		if(!isShaking) { // just lerp			
			this.transform.position = Vector3.Lerp(this.transform.position, destination, smooth * Time.deltaTime);
		} else { // lerp with shake effect
			Vector3 newDest = destination + Random.insideUnitSphere * shakePower;
			newDest.z = this.transform.position.z;
			this.transform.position = Vector3.Lerp(this.transform.position, newDest, smooth * Time.deltaTime);
		}

		// stop camera on map edges
		if(this.transform.position.x < -6.33f) {
			this.transform.position = new Vector3(-6.33f, this.transform.position.y, this.transform.position.z);
		} else if(this.transform.position.x > 6.33f) {
			this.transform.position = new Vector3(6.33f, this.transform.position.y, this.transform.position.z);
		}
		if(this.transform.position.y < -5.23f) {
			this.transform.position = new Vector3(this.transform.position.x, -5.22f, this.transform.position.z);
		} else if(this.transform.position.y > 5.23f) {
			this.transform.position = new Vector3(this.transform.position.x, 5.22f, this.transform.position.z);
		}

		// shahe logic
		if(shakeTime > 0f) {
			shakeTime -= Time.deltaTime;
		} else {
			isShaking = false;
		}
	}

	public void ShakeScreen(float time) {
		time = Random.Range(time*0.5f, time*1.5f);
		isShaking = true;
		shakeTime += time;

		shakePower = Random.Range(3.0f, 5.0f) * shakeTime;
	}
}
