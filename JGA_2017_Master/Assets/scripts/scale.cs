using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scale : MonoBehaviour {

	public GameObject balance_left;
	public GameObject balance_right;

	public GameObject leftRock;
	public GameObject rightRock;

	private GameObject hinge_left;
	private GameObject hinge_right;
	private Vector3 pos; 
	private int HeavyState = 0;	// 平行:0,左重:1,右重:3
	private int totalpoint, leftpoint, rightpoint = 0;


	void Start () {
		hinge_left = transform.Find ("hinge1").gameObject;
		hinge_right = transform.Find ("hinge2").gameObject;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		float y = transform.position.y;

		transform.position = pos;

		balance_left.transform.position = hinge_left.transform.position;
		balance_right.transform.position = hinge_right.transform.position;


		//以下傾き処理
		leftpoint = 0;
		rightpoint = 0;
		if (leftRock.GetComponent<BoxCollider2D> ().isTrigger)
			leftpoint = 1;
		
		if (rightRock.GetComponent<BoxCollider2D> ().isTrigger)
			rightpoint = 3;

		if (totalpoint == leftpoint + rightpoint)
			totalpoint = leftpoint + rightpoint;
		else {
			if (totalpoint == 4)
				totalpoint = 0;

			HeavyStateChange (HeavyState, leftpoint + rightpoint);
			totalpoint = leftpoint + rightpoint;
			HeavyState = totalpoint;
		}
	}

	void HeavyStateChange(int beforState, int afterState ){
		int trans = beforState - afterState;
		switch (trans) {
		case -3:
			heavy_left (2.0f);
			break;
		case -2:
			heavy_left (3.0f);
			break;
		case -1:
			heavy_right (2.0f);
			break;
		case 1:
			heavy_default (2.0f);
			break;
		case 2:
			heavy_right (3.0f);
			break;
		case 3:
			heavy_default (2.0f);
			break;

		}
		
	}

	public void heavy_right(float time){
		transform.DOLocalRotate (new Vector3 (0, 0, -30), time);
	}

	public void heavy_left(float time){
		transform.DOLocalRotate (new Vector3 (0, 0, 30), time);
	}

	public void heavy_default(float time){
		transform.DOLocalRotate (new Vector3 (0, 0, 0), time);
	}
}
