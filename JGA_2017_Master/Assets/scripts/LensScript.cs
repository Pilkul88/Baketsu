using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LensScript : MonoBehaviour {

	public GameObject[] Lens;
	public GameObject[] colors;
	private int num;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		DownKeyCheck ();
	}

	void DownKeyCheck(){
		foreach (KeyCode code in Enum.GetValues(typeof (KeyCode))) {
			if (Input.GetKeyDown (code)) {
				switch (code) {
				case KeyCode.R:
					ChangeLens (1);
					break;
				case KeyCode.B:
					ChangeLens (2);
					break;
				case KeyCode.G:
					ChangeLens (3);
					break;
				}
			}
		}
	}


	void ChangeLens(int num){
		if (Lens [num].activeSelf) {
			Lens [num].SetActive (false);
		} else {
			Lens [num].SetActive (true);
			colors [num-1].GetComponent<colors> ().TransparentManage ();
		}
	}
}
