using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 6f;
	public float jumpForce = 1000f;
	public float verticalSpeed = 20;
	public int inObject;

	private Rigidbody2D rb2d;
    private Animator animator;

	public bool isGround;
    public bool jumpFlag=false;

	public Vector2 restart;

	private AudioSource[] sources;
	private GameObject LensManager;
	private Animator red_baketsu;
	private Animator green_baketsu;
	private Animator blue_baketsu;

	public bool isPlayable;

    void Start () {
		isPlayable = true;
		rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inObject = 3;
		sources = gameObject.GetComponents<AudioSource>();
		LensManager = GameObject.Find ("LensManager");
		red_baketsu = transform.Find ("baketsu_noglass").GetComponent<Animator> ();
		green_baketsu = transform.Find ("baketsu_greenglass").GetComponent<Animator> ();
		blue_baketsu = transform.Find ("baketsu_blueglass").GetComponent<Animator> ();
	}


    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Obstacle") {
			sources [1].Play();
			GameOver ();
		}
    }



    void OnTriggerStay2D(Collider2D other){
		switch (other.tag) {
		case "RedBlock":
			inObject = 0;
			break;
		
		case "GreenBlock":
			inObject = 1;
			break;

		case "BlueBlock":
			inObject = 2;
			break;
		}

		if (other.gameObject.tag == "Obstacle") {
			sources [1].Play();
			GameOver ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "RedBlock" || other.tag == "GreenBlock" || other.tag == "BlueBlock")
			inObject = 3;

		//isGround = false;
	}

	void Update () {
		if (isPlayable) {
			if (Input.anyKey) {
				if (Input.GetKeyDown (KeyCode.R) || Input.GetButtonDown ("Fire3")) {
					LensManager.GetComponent<lensManager> ().PushKey (0);
				}
				if (Input.GetKeyDown (KeyCode.G) || Input.GetButtonDown ("Jump")) {
					LensManager.GetComponent<lensManager> ().PushKey (1);
				}
				if (Input.GetKeyDown (KeyCode.B) || Input.GetButtonDown ("Fire2")) {
					LensManager.GetComponent<lensManager> ().PushKey (2);
				}
			}
        
			if ((Input.GetButtonDown ("Fire1") /*|| Input.GetAxis ("Vertical") > 0*/) && isGround) {
				isGround = false;
				sources [0].Play ();
				rb2d.AddForce (new Vector2 (0, jumpForce));
				animator.SetTrigger ("JumpTrigger");
				red_baketsu.SetTrigger ("noglass_JumpTrigger");
				green_baketsu.SetTrigger ("greenglass_JumpTrigger");
				blue_baketsu.SetTrigger ("blueglass_JumpTrigger");
				jumpFlag = true;
			}

			if (!jumpFlag && !isGround) {
				animator.SetTrigger ("fallTrigger");
				//another_baketsu.SetTrigger ("noglass_fallTrigger");
			}

			if (transform.position.y < -20) {
				GameOver ();
			}

			if (jumpFlag && isGround) {
				animator.SetTrigger ("WalkTrigger");
				red_baketsu.SetTrigger ("noglass_WalkTrigger");
				green_baketsu.SetTrigger ("greenglass_WalkTrigger");
				blue_baketsu.SetTrigger ("blueglass_WalkTrigger");
				jumpFlag = false;
			}
      
		}
	}

	void FixedUpdate()
	{
		if (isPlayable) {
			float hor = Input.GetAxis ("Horizontal");
			rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);

			if (hor != 0) {
				if (hor < 0)
					transform.rotation = Quaternion.Euler (0, -180, 0);
				else
					transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}
	}

	public void beChildManager(GameObject mama, int state){
		switch(state){
		case 0:
			transform.parent = mama.transform;
			break;

		case 1:
			transform.parent = null;
			break;
		}
	}

	public void GameOver(){
        //ゲームオ―バー処理
        //現状仕様が確定していないため、リスタート
        sources[1].Play();
        transform.position = restart;
	}


}
