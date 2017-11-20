using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour {

	public float speed;
	public string thiscolor;
	private SpriteRenderer locus;
	private BoxCollider2D bc2;

	// Use this for initialization
	void Start () {
		locus = transform.Find("dot").gameObject.GetComponent<SpriteRenderer> ();
		bc2 = GetComponent<BoxCollider2D> ();
	}

	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (-speed, 0, 0);
		if (transform.position.x < 60) {
			Destroy (this.gameObject);
		}
	}
		
	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.name == thiscolor) {
			GetComponent<SpriteRenderer> ().enabled = true;
			locus.enabled = false;
			gameObject.tag = "Obstacle";
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == thiscolor) {
			GetComponent<SpriteRenderer> ().enabled = false;
			locus.enabled = true;
			gameObject.tag = "Untagged";
		}
	}
}
