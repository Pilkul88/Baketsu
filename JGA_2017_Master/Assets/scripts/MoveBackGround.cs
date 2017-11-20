using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour {

	public GameObject player;
	public float StageLength = 90; //ステージ全体の長さ
	public float BackgroundLength; //動かす背景の長さ
	public float CameraLength = 15; //画面に映る全体の長さ
	public float height;
	float idouryou;
	float length;

	void Start(){
		length = BackgroundLength - CameraLength;
	}
	
	// Update is called once per frame
	void Update () {
		if (StageLength != 0)
			idouryou = (player.transform.position.x -10) * length / StageLength;

		transform.position = new Vector3 (
			player.transform.position.x - CameraLength/2 + BackgroundLength/2 - idouryou,
			player.transform.position.y + height,
			0
		);
	}
}
