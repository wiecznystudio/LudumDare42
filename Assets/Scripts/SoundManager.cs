using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// singleton 
	private static SoundManager instance;
	public static SoundManager Instance {
		get { return instance; }
	}

	// variable
	public AudioClip[] audioClips;
	private AudioSource audioSource;

	// unity functions
	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}

	void Start() {
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = false;
	}

	// sound manager functions
	public void Play(int audio) {
		audioSource.clip = audioClips[audio];
		audioSource.Play();
	}

	public bool IsPlaying() {
		return audioSource.isPlaying;
	}

	public void Stop() {
		audioSource.Stop();
	}
}
