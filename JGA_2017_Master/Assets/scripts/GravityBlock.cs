using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBlock : MonoBehaviour {

	private Vector2 basePosition;
	private Rigidbody2D rb;
	private GameObject CheckPointManager;
	private BoxCollider2D bc2;
	private SpriteRenderer sr;
	private string tana_name;

	public int isRigidBodyState;
	public bool isRigidBody;
	public GameObject tana;

	void Start () {
		basePosition = transform.position;
		rb = GetComponent<Rigidbody2D> ();
		CheckPointManager = GameObject.Find ("RestartPoints");
		bc2 = GetComponent<BoxCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();
		tana_name = tana.name;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (
			basePosition.x,
			transform.position.y,
			transform.position.z
		);
		transform.rotation = new Quaternion (0, 0, 0, 0);
		/*
		if (CheckPointManager.GetComponent<CheckPointParent> ().CheckPointState == isRigidBodyState
		   && !isRigidBody) {
			rb.simulated = true;
			isRigidBody = true;
		}
		*/
	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.name != tana_name) {
			bc2.enabled = false;
			rb.simulated = false;
			StartCoroutine ("rebirth");
		}
	}

	private IEnumerator rebirth(){
		for(float i=1; i>0; i-= 0.01f){
			sr.color = new Color (
				sr.color.r,
				sr.color.g,
				sr.color.b,
				i
			);
			yield return new WaitForSeconds (0.01f);
		}
		transform.position = basePosition;
		yield return new WaitForSeconds (3f);

		for(float i=0; i<1; i+=0.01f){
			sr.color = new Color (
				sr.color.r,
				sr.color.g,
				sr.color.b,
				i
			);
			yield return new WaitForSeconds (0.01f);
		}
		bc2.enabled = true;
		rb.simulated = true;

	}
}
