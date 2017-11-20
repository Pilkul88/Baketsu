using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour {

	public float speed;
	public float wide_left;
	public float wide_right;
	public string thiscolor;
	public bool moveable;

	private int vectol = 1;

	// Use this for initialization
	void Start () {
		moveable = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveable) {
			transform.rotation = Quaternion.Euler (0, 90 + vectol * 90, 0);
			transform.position += new Vector3 (vectol * speed, 0, 0);

			if (transform.position.x < wide_left || transform.position.x > wide_right) {
				vectol *= -1;
			}	
		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.name == thiscolor) {
			GetComponent<SpriteRenderer> ().enabled = true;
			//locus.enabled = false;
			gameObject.tag = "Obstacle";
			GetComponent<Rigidbody2D> ().gravityScale = 1;
			GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == thiscolor) {
			GetComponent<SpriteRenderer> ().enabled = false;
			//locus.enabled = true;
			gameObject.tag = "Untagged";
			GetComponent<Rigidbody2D> ().gravityScale = 0;
			GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}
}
