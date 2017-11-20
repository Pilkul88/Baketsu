using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colors : MonoBehaviour {
	
	public GameObject[] ColorsChild;	//本体 GameObject

	void Start(){
		ColorsChild = new GameObject[transform.childCount];

		int count = 0;
		foreach(Transform child in transform){
			ColorsChild [count] = child.gameObject; //child.gameObject;
			count++;
		}
	}

	void Update(){
	}

	public void TransparentManage(){
		for(int i=0; i<ColorsChild.Length; i++){
			ColorsChild [i].GetComponent<block> ().Transparent ();
		}

	}

	public void Appearance(){
	}
}
