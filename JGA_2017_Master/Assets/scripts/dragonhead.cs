using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dragonhead : MonoBehaviour {

	private bool chaseflag;
	private bool rushflag;
    public bool isDead;
	private GameObject player;
	private Vector3 baseposition;
    AudioClip clip;

    [SerializeField]
    Sprite deadSprite;



    void Start () {
		player = GameObject.Find ("player");
		baseposition = transform.position;
        clip = GetComponent<AudioSource>().clip;
    }

	void Update(){
		if (transform.position.x < 80) {
			rushflag = false;
			transform.position = new Vector3 (130, -1, 0);
			transform.DOMove (baseposition, 3.0f);
		}
	}
	

	void FixedUpdate () {
		if (chaseflag)
			transform.position = Vector3.Lerp (transform.position, new Vector3 (119, player.transform.position.y, 0), 0.1f) /*+ new Vector3(0, 0.1f, -10)*/;

		if (rushflag)
			transform.position -= new Vector3 (0.6f, 0, 0);
		
	}

	public void Atack(){
		StartCoroutine ("chase");
	}

	private IEnumerator chase(){
		transform.DOMove (new Vector3 (119, 1, 0), 1f);
		yield return new WaitForSeconds (1f);

		chaseflag = true;

		yield return new WaitForSeconds (3f);

		transform.DOMove (new Vector3(
			119,
			player.transform.position.y - 1,
			0) ,
			0.1f);
		yield return new WaitForSeconds (0.1f);
		transform.rotation = Quaternion.Euler (0, 0, -20);
		chaseflag = false;
		rushflag = true;


	}

    private void OnTriggerEnter2D( Collider2D collision ) {
      

        if( collision.tag == "DragonKiller" ) {
            isDead = true;
            GetComponent<AudioSource>().PlayOneShot( clip );
            Destroy( GetComponent<Animator>() );
            GetComponent<SpriteRenderer>().sprite = deadSprite;
            transform.parent.gameObject.GetComponent<dragonmaster>().deadCount++;
        }
    }
}
