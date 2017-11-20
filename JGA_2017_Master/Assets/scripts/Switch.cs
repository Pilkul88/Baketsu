using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public GameObject[] door;
	private GameObject head;
	private bool switchflag;

	void Start () {
		head = transform.parent.gameObject;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag != "switch" && !switchflag) {
			for(int i=0; i<door.Length; i++){
				door [i].GetComponent<door> ().open ();
			}
			head.transform.position += new Vector3 (0, -0.2f, 0);
			switchflag = true;
		}

	}
}
