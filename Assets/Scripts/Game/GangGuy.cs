using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangGuy : MonoBehaviour {

	void Awake() {
		Vector3 newPos = this.transform.localPosition;
		newPos.z += this.transform.position.y/1000f;
		this.transform.localPosition = newPos;
	}
	
}
