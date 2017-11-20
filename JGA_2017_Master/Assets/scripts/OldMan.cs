using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour {

	private GameObject player;
	public GameObject[] text;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		float x = player.transform.position.x;

		if (x < 190) {
			transform.position = new Vector3 (player.transform.position.x + 5,
				player.transform.position.y + 3,
				0
			);
		} else {
			transform.position = new Vector3 (195,5,0);
		}

		if (x > -8) {
			show (0);
		}

		if (x > -2) {
			show (1);
		}

		if (x > 2) {
			show (2);	
		}

		if (x > 15) {
			show (3);
		}

		if (x > 97) {
			show (4);
		}


		if (x > 130) {
			show (5);
		}

		if (x > 155) {
			show (6);
		}

		if (x > 180) {
			show (7);
		}

		if (x > 190) {
			show (8);
		}


	}


	void show(int num){
		for (int i = 0; i < text.Length; i++) {
			text [i].SetActive (false);
		}
		text [num].SetActive (true);
	}
}
