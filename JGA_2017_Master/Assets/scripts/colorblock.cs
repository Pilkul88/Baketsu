using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class colorblock : MonoBehaviour {

	public string parent_name;
	private SpriteRenderer locus;
	private Sprite basesprite;
	private int State;
	private SpriteRenderer sr;
	private BoxCollider2D bc2;
	private CircleCollider2D cc2;

	public bool isBox = true;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();

		if (isBox)
			bc2 = GetComponent<BoxCollider2D> ();
		else
			cc2 = GetComponent<CircleCollider2D> ();

		locus = transform.Find ("dot").gameObject.GetComponent<SpriteRenderer> ();


	}
		
	void OnTriggerEnter2D( Collider2D other){
		if (other.gameObject.name == gameObject.tag) {
			StateSetting (1);
		}
	}

	void OnTriggerExit2D( Collider2D other){
		if( other.gameObject.name == gameObject.tag){
		StateSetting (0);
		}
	}

	public void StateSetting(int state){
		
		switch( state ){

		case 0:
			sr.enabled = true;
			locus.enabled = false;
			if (isBox)
				bc2.isTrigger = false;
			else
				cc2.isTrigger = false;
			break;
		case 1:
			sr.enabled = false;
			locus.enabled = true;
			if (isBox)
				bc2.isTrigger = true;
			else
				cc2.isTrigger = true;
			break;
		}
	}
		

}
	