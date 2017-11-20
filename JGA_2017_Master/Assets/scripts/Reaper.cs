using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Reaper : MonoBehaviour {

	private bool isAction = false;
	private int hp = 3;
	private Vector3 defaultPosition;
	private string now_antion;
	private bool isdead;

	public GameObject[] Wind;
	public GameObject[] Seed;

	public GameObject[] story;

	public GameObject bake;
	public GameObject sini;

	public GameObject panel;
    
    AudioClip clip;


    public Sprite[] ReaperAnim;
	private SpriteRenderer sp;
	private CircleCollider2D cc2;
	// Use this for initialization
	void Start () {
		defaultPosition = transform.position;
		sp = GetComponent<SpriteRenderer> ();
		cc2 = GetComponent<CircleCollider2D> ();
        clip = GetComponent<AudioSource>().clip;
    }
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, 0, 0);	
		if (!isAction && !isdead) {
			isAction = true;
			int action = Random.Range (0, 100);
			if (action < 30) {
				now_antion = "Idle";
				StartCoroutine ("Idle");
			} else if (action < 70) {
				now_antion = "Sickle";
				StartCoroutine ("Sickle");
			} else if (action < 100) {
				now_antion = "seed";
				StartCoroutine ("seed");
			}
		} else if (!isAction && isdead) {
			StartCoroutine ("story_go");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "blackRock"){
			StopCoroutine(now_antion);
            GetComponent<AudioSource>().PlayOneShot(clip);
            StartCoroutine("Damage");
		}
	}


    private IEnumerator story_go() {

        /*
        bake.gameObject.SetActive( true );
        sini.gameObject.SetActive( true );

        show( 1 );
        yield return new WaitForSeconds( 3f );
        show( 2 );
        yield return new WaitForSeconds( 3f );
        show( 3 );
        yield return new WaitForSeconds( 3f );
        show( 4 );
        yield return new WaitForSeconds( 3f );
        show( 5 );
        yield return new WaitForSeconds( 3f );

        */

        panel.GetComponent<first_fade>().FadeO();
        yield return new WaitForSeconds( 3f );
        SceneManager.LoadScene( "2nd_stage" );
    }
    

	private IEnumerator Damage(){
		hp--;
		cc2.isTrigger = true;
		sp.sprite = ReaperAnim[5];
		yield return new WaitForSeconds(4-hp);
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;

		if (!isdead) {
			sp.sprite = ReaperAnim [0];
		}

		transform.DOMove (new Vector3 (80f, 1.37f, 0), 2.5f);
		yield return new WaitForSeconds (2.5f);

		if (!isdead) {
			sp.sprite = ReaperAnim [1];
		}

		transform.DOMove (new Vector3 (80f, -2f, 0), 1.5f);
		yield return new WaitForSeconds (1.5f);
		isAction = false;

		if (!isdead) {
			sp.sprite = ReaperAnim [0];
		}

		cc2.isTrigger = false;
		isdead = (hp == 0);
	}

	private IEnumerator Idle(){
		transform.DOLocalMove (new Vector3 (80, 1, 0), 1.5f);
		yield return new WaitForSeconds(1.5f);

		sp.sprite = ReaperAnim [1];
		transform.DOLocalMove (new Vector3 (80, -2, 0), 1.5f);
        yield return new WaitForSeconds( 1.5f );

        sp.sprite = ReaperAnim [0];

		isAction = false;
	}

	private IEnumerator Sickle(){
		int windId;
		transform.DOMove (new Vector3 (81.5f, 1f, 0), 1f);
		yield return new WaitForSeconds(1f);
		sp.sprite = ReaperAnim [2];
		yield return new WaitForSeconds(0.5f);
		sp.sprite = ReaperAnim [3];
		windId = (int)Random.Range (0, 4);
		Instantiate (Wind [windId], transform.position, new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		sp.sprite = ReaperAnim [1];

		transform.DOMove (new Vector3 (81.5f, -1f, 0), 0.5f);
		yield return new WaitForSeconds(0.5f);
		sp.sprite = ReaperAnim [2];
		yield return new WaitForSeconds(0.5f);
		sp.sprite = ReaperAnim [3];
		windId = (int)Random.Range (0, 4);
		Instantiate (Wind [windId], transform.position, new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		sp.sprite = ReaperAnim [1];


		transform.DOMove (new Vector3 (81.5f, -3f, 0), 0.5f);
		yield return new WaitForSeconds (0.5f);
		sp.sprite = ReaperAnim [2];
		yield return new WaitForSeconds(0.5f);
		sp.sprite = ReaperAnim [3];
		windId = (int)Random.Range (0, 4);
		Instantiate (Wind [windId], transform.position, new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);

		sp.sprite = ReaperAnim[0];
		transform.DOMove (new Vector3 (80f, -2f, 0), 1f);
		yield return new WaitForSeconds(1f);
		isAction = false;
	}

	private IEnumerator seed(){
		int seedId;
		transform.DOMove (new Vector3 (80f, 1.37f, 0), 1f);
		yield return new WaitForSeconds (1f);



		transform.DOMove (new Vector3 (76f, 1.37f, 0), 1.5f);
		yield return new WaitForSeconds (1.5f);
		sp.sprite = ReaperAnim [4];
		seedId = (int)Random.Range (0, 4);
		Instantiate (Seed [seedId], transform.position, new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds (0.5f);
		sp.sprite = ReaperAnim [0];

		transform.DOMove (new Vector3 (71.7f, 1.37f, 0), 1.5f);
		yield return new WaitForSeconds (1.5f);
		sp.sprite = ReaperAnim [4];
		seedId = (int)Random.Range (0, 4);
		Instantiate (Seed [seedId], transform.position, new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds (0.5f);
		sp.sprite = ReaperAnim [0];

		transform.DOMove (new Vector3 (67.34f, 1.37f, 0), 1.5f);
		yield return new WaitForSeconds (1.5f);
		sp.sprite = ReaperAnim [4];
		seedId = (int)Random.Range (0, 4);
		Instantiate (Seed [seedId], transform.position, new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds (0.5f);
		sp.sprite = ReaperAnim [0];

		transform.DOMove (new Vector3 (80f, 1.37f, 0), 2.5f);
		yield return new WaitForSeconds (2.5f);

		sp.sprite = ReaperAnim [1];

		transform.DOMove (new Vector3 (80f, -2f, 0), 1.5f);
		yield return new WaitForSeconds (1.5f);
		isAction = false;

		sp.sprite = ReaperAnim [0];
	}

	private IEnumerator Interval( float time) {  
		yield return new WaitForSeconds (time);
		isAction = false;
	} 

    /*
	void show(int num){
		for (int i = 0; i <story.Length; i++) {
			story [i].SetActive (false);
		}
		story [num].SetActive (true);
	}
    */
}