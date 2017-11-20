using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {
	private Color color;
	private float alfa = 1;
	bool isTransparent = false;
	SpriteRenderer component;


	void Start () {
		component = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if (alfa >= -1 && isTransparent == true) {
			component.enabled = false;
			component.color = new Color (1, 1, 1, alfa);
			alfa -= 0.1f;
		}
	}

	public void Transparent(){
		isTransparent = true;
	}
}