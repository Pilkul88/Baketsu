using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StaticCameraController : MonoBehaviour {

	public Vector3[] CameraPosition;
	public float[] CameraSize;
	public int startpos;
	private int CameraPositionState;
	private Camera _camera;
	private GameObject CheckPointManager;
	private float _num;

	// Use this for initialization
	void Start () {
		CheckPointManager = GameObject.Find ("RestartPoints");
		transform.position = CameraPosition[startpos];
		_camera = GetComponent<Camera>();
		Num = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (CameraPositionState != CheckPointManager.GetComponent<CheckPointParent> ().CheckPointState) {
			CameraPositionState = CheckPointManager.GetComponent<CheckPointParent> ().CheckPointState;
			transform.DOLocalMove (CameraPosition[CameraPositionState], 2.0f);
			DOTween.To (() => Num, (n) => Num = n,  CameraSize[CameraPositionState], 2f).SetEase (Ease.Linear);
		}
	}

	public float Num {
		set {
			_num = value;
			// Numに値が代入されると画面上の文字が更新される
			_camera.orthographicSize  = _num;
		}
		get {
			return _num;
		}
	}

}
