using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour {

	public Sprite[] slide;
	public GameObject fadePanel;
	public string loadScene;
	private SpriteRenderer sr;
	private int slide_num = 0;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();

		StartCoroutine ("FadeIn",0.01f);
		sr.sprite = slide [0];
		//slide_num++;
		StartCoroutine("slide_go");
	}


	private IEnumerator slide_go(){
		for (int i = 1; i < slide.Length; i++ ) {
			sr.sprite = slide [i];
			yield return new WaitForSeconds(1.5f);
		}
		StartCoroutine ("FadeOut",0.01f);
	}


	private IEnumerator FadeIn(float speed){
		for (float i = 1; i > 0; i -= speed ) {
			fadePanel.GetComponent<Image> ().color = new Color (0, 0, 0, i);
			yield return new WaitForSeconds(0.01f);
		}
	}

	private IEnumerator FadeOut(float speed){
		for (float i =0; i < 1; i += speed ) {
			fadePanel.GetComponent<Image> ().color = new Color (0, 0, 0, i);
			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene ("tutorial_movie");
	}
}
