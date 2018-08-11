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

		Vector3 destination = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, this.transform.position.z);
		if(!isShaking) {			
			this.transform.position = Vector3.Lerp(this.transform.position, destination, smooth * Time.deltaTime);
		} else {
			Vector3 newDest = destination + Random.insideUnitSphere * shakePower;
			newDest.z = this.transform.position.z;
			this.transform.position = Vector3.Lerp(this.transform.position, newDest, smooth * Time.deltaTime);
		}

		if(shakeTime > 0f) {
			//this.transform.position = this.transform.position * Random.insideUnitCircle * shakePower;
			shakeTime -= Time.deltaTime;
		} else {
			isShaking = false;
		}
	}

	public void ShakeScreen(float time) {
		time = Random.Range(time*0.5f, time*1.5f);
		isShaking = true;
		shakeTime += time;

		shakePower = Random.Range(1.0f, 5.0f) * shakeTime;
	}
}
