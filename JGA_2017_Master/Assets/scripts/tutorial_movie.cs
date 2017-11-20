using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial_movie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Jump");
	}

	private IEnumerator Jump(){
		yield return new WaitForSeconds (27f);
		SceneManager.LoadScene ("tutorial_stage");
	}
}
