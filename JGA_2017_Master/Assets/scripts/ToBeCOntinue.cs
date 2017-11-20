using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToBeCOntinue : MonoBehaviour {

    [SerializeField]
    GameObject fadePanel;

	void Start () {
        StartCoroutine( FadeIn( 0.01f ) );
	}
	
	// Update is called once per frame
	void Update () {
        if( Input.anyKeyDown ) {
            StartCoroutine( FadeOut( 0.01f ) );
        }   
	}

    private IEnumerator FadeIn( float speed ) {
        for( float i = 1; i > 0; i -= speed ) {
            fadePanel.GetComponent<Image>().color = new Color( 0, 0, 0, i );
            yield return new WaitForSeconds( 0.01f );
        }
       
    }

    private IEnumerator FadeOut( float speed ) {
        for( float i = 0; i < 1; i += speed ) {
            fadePanel.GetComponent<Image>().color = new Color( 0, 0, 0, i );
            yield return new WaitForSeconds( 0.01f );
        }
        yield return new WaitForSeconds( 1f );
        SceneManager.LoadScene( "Title" );
    }

}
