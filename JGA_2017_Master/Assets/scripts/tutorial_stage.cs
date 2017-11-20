using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial_stage : MonoBehaviour {

	private GameObject player;
	private bool startflag;
	private bool goalflag;

	public GameObject[] text;
	private bool[] textflag;

	public GameObject NPC;

	void Start () {
		player = GameObject.Find ("player");
		GameObject.Find ("Main Camera").GetComponent<CameraController> ().Player = this.gameObject.transform;
		NPC.GetComponent<moveEnemy> ().moveable = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.transform.position.x < -9.5f && !startflag ) {
			player.GetComponent<PlayerController> ().isPlayable = false;
			player.transform.position += new Vector3 (0.04f, 0, 0);
		} else if (transform.position.x >= -9.5f && !startflag) {
			GameObject.Find ("Main Camera").GetComponent<CameraController> ().Player = player.transform;
			player.GetComponent<PlayerController> ().isPlayable = true;
			startflag = true;
		}
			

		if (player.transform.position.x > 130 && !NPC.GetComponent<moveEnemy> ().moveable) {
			NPC.GetComponent<moveEnemy> ().moveable = true;
		}

		if (player.transform.position.x > 190 && !goalflag) {
			transform.position = player.transform.position;
			GameObject.Find ("Main Camera").GetComponent<CameraController> ().Player =this.gameObject.transform;
			player.GetComponent<PlayerController> ().isPlayable = false;
			goalflag = true;
		}
		if(goalflag)
			player.transform.position += new Vector3 (0.03f, 0, 0);

		if (player.transform.position.x > 200) {
			SceneManager.LoadScene ("1st_stage");
			//SceneManager.LoadScene ("title");
		}
			
	}
}
