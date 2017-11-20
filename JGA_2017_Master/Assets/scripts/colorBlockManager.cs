using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBlockManager : MonoBehaviour {

	public GameObject[] blocks;
	public GameObject[] exception; 
	private colorblock[] cb;

	void Start () {
		int childCount = transform.childCount;
		int exceptionCount = exception.Length;
		blocks = new GameObject[childCount + exceptionCount];
		cb = new colorblock[childCount + exceptionCount];

		int count = 0;
		foreach (Transform child in transform)
		{
			blocks [count] = child.gameObject;
			cb [count] = child.GetComponent<colorblock> ();
			count++;
		}

		for(int i=0; i< exceptionCount; i++){
			blocks [count + i] = 
				exception[i];
			cb [count + i] = exception[i].GetComponent<colorblock> ();
		}
				
	}

	public void ChangeState(int state){
		for(int i=0; i<cb.Length; i++){
			cb[i].StateSetting (state);
		}
	}
}
