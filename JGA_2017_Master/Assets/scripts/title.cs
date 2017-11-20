using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
	public GameObject baketu; 
	int v = 1;
	// Update is called once per frame
	void Update () {
		baketu.transform.position += new Vector3 (0.02f * v, 0, 0);
		transform.rotation = Quaternion.Euler (0, 90 -v*90, 0);
		if (baketu.transform.position.x > 8.5f || baketu.transform.position.x < -8f) {
			v *= -1;
		}

		if (Input.anyKeyDown) {
			SceneManager.LoadScene ("Prologue");
		}
	}
}
