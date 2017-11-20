using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class lensManager : MonoBehaviour {

	public GameObject[] Lenses;
	public GameObject[] colorBlockManager;
	public GameObject player;
	private SpriteRenderer[] another_baketsu;
	private bool[] whichWear;
	public Sprite[] ButtonUI;
	private GameObject UI;

	private AudioSource source;

	//int count=0;

	void Start () {
		whichWear = new bool[colorBlockManager.Length];
		source = GetComponent<AudioSource> ();
		UI = GameObject.Find ("ButtonUI");
		another_baketsu = new SpriteRenderer[3];
		another_baketsu[0] = player.transform.Find ("baketsu_noglass").GetComponent<SpriteRenderer>();
		another_baketsu[1] = player.transform.Find ("baketsu_greenglass").GetComponent<SpriteRenderer>();
		another_baketsu[2] = player.transform.Find ("baketsu_blueglass").GetComponent<SpriteRenderer>();
	}

	public void PushKey(int id){
		int inobject = player.GetComponent<PlayerController> ().inObject;
		if (whichWear [id] == false && inobject == 3) {
			for (int i = 0; i < 3; i++) {
				if (whichWear [i]) {
					LensLotate (i, 1);
					whichWear [i] = false;
				}
			}
			LensLotate (id, 0);
			whichWear [id] = true;
		} else if (inobject == 3) {
			LensLotate (id, 1);
			whichWear [id] = false;
		} else if (id == inobject) {
			LensLotate (id, 3);
		}else{
			LensLotate (id, 2);
			for (int i = 0; i < 3; i++) {
				if(whichWear[i]) LensLotate (i, 3);
			}
		}
		UI.GetComponent<Image>().sprite = ButtonUI[which_num()];


		for (int i = 0; i < another_baketsu.Length; i++) {
			another_baketsu [i].GetComponent<SpriteRenderer> ().enabled = false;
		}
		player.GetComponent<SpriteRenderer> ().enabled = false;

		switch (which_num ()) {
		case 0:
			player.GetComponent<SpriteRenderer> ().enabled = true;
			break;
		
		case 1:
			another_baketsu[1].GetComponent<SpriteRenderer> ().enabled = true;
			break;

		case 2:
			another_baketsu[2].GetComponent<SpriteRenderer> ().enabled = true;
			break;

		case 3:
			another_baketsu[0].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		}
	}


	void LensLotate(int id, int vec){
		switch (vec) {
		case 0:
			Lenses [id].transform.DOLocalRotate (new Vector3 (0, 0, -90), 0.2f);
			source.Play ();
			break;
		case 1:
			Lenses [id].transform.DOLocalRotate (new Vector3 (0, 0, 0), 0.2f);
			source.Play ();
			break;
		case 2:
			Sequence _myseq1 = DOTween.Sequence ();
			_myseq1.Append (Lenses [id].transform.DOLocalRotate (new Vector3 (0, 0, -30), 0.2f));
			_myseq1.Append (Lenses [id].transform.DOLocalRotate (new Vector3 (0, 0, 0), 0.2f));
			break;
		case 3:
			Sequence _myseq2 = DOTween.Sequence ();
			_myseq2.Append (Lenses [id].transform.DOLocalRotate (new Vector3 (0, 0, -80), 0.2f));
			_myseq2.Append (Lenses [id].transform.DOLocalRotate (new Vector3 (0, 0, -90), 0.2f));
			break;
		}
	}

	int which_num(){
		for (int i = 0; i < 3; i++) {
			if (whichWear [i]) {
				return i;
			}
		}
		return 3;
	}
}
	