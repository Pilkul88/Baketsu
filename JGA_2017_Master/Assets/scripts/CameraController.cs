using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraController : MonoBehaviour 
{
	public Transform Player;
	public float m_speed = 0.1f;
	public float height = 0;
	private Camera mycam;
	private float _num;
	private bool Bossflag;
	private GameObject soundManager;

	public int BossPoint;
	public Vector3 BossCameraPos;
	public float BossCameraSize;

	private GameObject RestartPoints;
	public GameObject[] BossStage;
	public GameObject Boss;

	public void Start()
	{
		mycam = GetComponent<Camera> ();
		RestartPoints = GameObject.Find ("RestartPoints");
		Num = 5;
		soundManager = GameObject.Find ("SoundManager");
	}

	public void FixedUpdate()
	{
		if (Player && !Bossflag) 
		{
		
			transform.position = Vector3.Lerp(transform.position, Player.position, m_speed) + new Vector3(0, height, -10);
		}

		
		if (RestartPoints.GetComponent<CheckPointParent> ().CheckPointState == BossPoint && !Bossflag) {
			soundManager.GetComponent<SoundManager> ().PlaySound (1);
			Bossflag = true;
			transform.DOLocalMove (BossCameraPos, 2.0f);
			DOTween.To (() => Num, (n) => Num = n,  BossCameraSize, 2.0f).SetEase (Ease.Linear);
			for(int i=0; i<BossStage.Length; i++){
				BossStage[i].GetComponent<BoxCollider2D> ().isTrigger = false;
			}

			Boss.SetActive(true);
		}

	}

	public float Num {
		set {
			_num = value;
			// Numに値が代入されると画面上の文字が更新される
			mycam.orthographicSize  = _num;
		}
		get {
			return _num;
		}
	}


}
