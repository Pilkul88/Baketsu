using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour {

	private GameObject parent;
	private Component pc;
	private AudioSource source;
	void Start () {
		parent = transform.parent.gameObject;
		source = GetComponent<AudioSource> ();
	}

	void Update(){
		transform.position = parent.transform.position + new Vector3 (0.15f, -0.8f, 0);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name != "player" && !other.isTrigger) {
			source.Play();
			parent.GetComponent<PlayerController> ().isGround = true;
		}
	}

}
