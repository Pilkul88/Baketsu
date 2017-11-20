using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	private GameObject restart_parent;
	public int CheckPoint_number; //1~

	void Start(){
		restart_parent = GameObject.Find ("RestartPoints");
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerController>().restart = transform.position + new Vector3( 1, 0, 0 );


			if (restart_parent.GetComponent<CheckPointParent> ().CheckPointState < CheckPoint_number)
				restart_parent.GetComponent<CheckPointParent> ().CheckPointState = CheckPoint_number;
			else
				restart_parent.GetComponent<CheckPointParent> ().CheckPointState--;
		}
	}

}
