using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dragonmaster : MonoBehaviour {

	private GameObject[] dragon_child;

    public int deadCount;

    [SerializeField]
    GameObject fadePanel;


    [SerializeField]
    Sprite deadSprite;

	// Use this for initialization
	void Start () {
		dragon_child = new GameObject[8];
		int count = 0;
		foreach (Transform child in transform) {
			dragon_child [count] = child.gameObject;
			count++;
		}

		StartCoroutine ("chase");
	}

    private void Update() {
        if(deadCount >= 8 ) {
            Destroy( GetComponent<Animator>() );
            GetComponent<SpriteRenderer>().sprite = deadSprite;
            StartCoroutine( FadeOut( 0.01f ) );
            deadCount++;
        }
    }

    private IEnumerator chase(){
		while (deadCount < 8) {
            bool canAttack = false;
            int which_child = 0;
            while( !canAttack ) {
                which_child = ( int )Random.Range( 0, 8 );
                if( !dragon_child[which_child].GetComponent<dragonhead>().isDead ) {
                    canAttack = true;
                }
            }
			dragon_child [which_child].GetComponent<dragonhead> ().Atack();
			yield return new WaitForSeconds (10f);
		}
	}

    private IEnumerator FadeOut( float speed ) {
        yield return new WaitForSeconds( 4f );
        for( float i = 0; i < 1; i += speed ) {
            fadePanel.GetComponent<Image>().color = new Color( 0, 0, 0, i );
            yield return new WaitForSeconds( 0.01f );
        }
        yield return new WaitForSeconds( 1f );
        SceneManager.LoadScene( "ToBeContinue" );
    }


}
