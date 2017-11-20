using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveObject : MonoBehaviour {

	public Vector3[] section;	//差分を書け, 3つめの要素は時間
	void Start () {
		Sequence _myseq1 = DOTween.Sequence ();
		for (int i=0; i < section.Length; i++) {
			_myseq1.Append (transform.DOLocalMove (new Vector2 (section [i].x, section[i].y), section[i].z));
		}
		_myseq1.SetLoops (-1);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "player" && other.transform.parent == null) {
			other.gameObject.GetComponent<PlayerController> ().beChildManager (this.gameObject, 0);
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.name == "player") {
			other.gameObject.GetComponent<PlayerController> ().beChildManager (this.gameObject, 1);
		}
	}

}
