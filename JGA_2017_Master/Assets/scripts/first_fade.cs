using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class first_fade : MonoBehaviour {

	public float startFadeSpeed = 0;
	// Use this for initialization
	void Start () {
		if(startFadeSpeed != 0)
			StartCoroutine ("FadeIn", startFadeSpeed);
	}

	private IEnumerator FadeIn(float speed){
		for (float i = 1; i > 0; i -= speed ) {
			GetComponent<Image> ().color = new Color (0, 0, 0, i);
			yield return new WaitForSeconds(0.01f);
		}
	}

	private IEnumerator FadeOut(float speed){
		for (float i = 0; i < 1; i += speed ) {
			GetComponent<Image> ().color = new Color (0, 0, 0, i);
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void FadeO(){
		StartCoroutine ("FadeOut", 0.01f);
	}
}
