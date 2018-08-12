using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {

	// singleton
	private static EffectController instance;
	public static EffectController Instance { 
		get { return instance; }
	}

	// variables
	public CameraController camera;
	public GameObject explosionPrefab;
	public GameObject smokePrefab;

	// all active effects lists
	private List<Transform> smokeObjects = new List<Transform>();
	private List<Transform> explosionObjects = new List<Transform>();

	private ParticleSystem smoke, explosion;

	// unity functions
	void Awake () {
		if(instance == null) {
			instance = this;
			//DontDestroyOnLoad(this.gameObject);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}
	
	void Update () {
		
	}

	// effect controller functions
	public int PlaySmoke(Vector3 pos) { // add smoke effect and return id
		GameObject smokeObject = GameObject.Instantiate(smokePrefab, pos, Quaternion.identity);
		smokeObject.transform.localPosition += new Vector3(0, 0, -3);
		smokeObject.transform.SetParent(this.transform);
		smoke = smokeObject.GetComponent<ParticleSystem>();
		smoke.Play();
		smokeObjects.Add(smokeObject.transform);
		return smokeObjects.Count-1;
	}
	public void StopSmoke(int id) {
		smokeObjects[id].GetComponent<ParticleSystem>().loop = false;
	}

	public int PlayExplosion(Vector3 pos) {  // add explosion effect and return id
		GameObject explosionObject = GameObject.Instantiate(explosionPrefab, pos, Quaternion.identity);
		explosionObject.transform.localPosition += new Vector3(0, 0, -3);
		explosionObject.transform.SetParent(this.transform);
		explosion = explosionObject.GetComponent<ParticleSystem>();
		explosion.Play();

		camera.ShakeScreen(0.6f);

		explosionObjects.Add(explosionObject.transform);
		return explosionObjects.Count-1;
	}
}
