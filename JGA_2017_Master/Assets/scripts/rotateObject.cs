using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotateObject : MonoBehaviour {

	public float interval;	//差分を書け, 3つめの要素は時間
	void Start () {
		
		StartCoroutine (rotate()); 
	}

	private IEnumerator rotate(){
		int theta = 0;
		while (true){
			transform.rotation = Quaternion.Euler (0, 0, -theta);
			if (transform.rotation.z > 360) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			theta++;
			yield return new WaitForSeconds (interval); 
		}
	}
}
