using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource[] sources;

	// Use this for initialization
	void Start () {
		sources = gameObject.GetComponents<AudioSource>();
	}

	public void PlaySound(int num){
		for (int i = 0; i < sources.Length; i++) {
			sources [i].Stop ();
		}
		sources [num].Play();
	}
}
