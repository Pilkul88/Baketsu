using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour {

	public GameObject aa;
	public float startFadeSpeed = 0;
	// Use this for initialization
	void Start () {
		if(startFadeSpeed != 0)
		StartCoroutine ("FadeIn", startFadeSpeed);
		
	}


	void Update(){
		if (aa.transform.position.x > 200) {
			StartCoroutine ("FadeOut", startFadeSpeed);
		}
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
}
