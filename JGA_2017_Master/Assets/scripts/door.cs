using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class door : MonoBehaviour {

	public Vector2 open_position;
	private Vector2 close_position;

	void Start () {
		close_position = transform.position;
	}

	public void open(){
		transform.DOLocalMove (open_position, 1.0f);

	}

	public void close(){
		transform.DOLocalMove (close_position, 1.0f);
	}
}
