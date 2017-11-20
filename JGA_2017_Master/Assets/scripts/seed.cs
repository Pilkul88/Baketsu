using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour {


	public string thiscolor;
	private SpriteRenderer locus;

	// Use this for initialization
	void Start () {
		locus = transform.Find("dot").gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20)
			Destroy (gameObject);
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == thiscolor) {
			GetComponent<SpriteRenderer> ().enabled = true;
			locus.enabled = false;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == thiscolor) {
			GetComponent<SpriteRenderer> ().enabled = false;
			locus.enabled = true;
		}
	}
}
