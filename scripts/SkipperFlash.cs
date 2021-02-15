using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipperFlash : MonoBehaviour {

	private GameObject text;
	
	void Start () {
		text = GameObject.Find ("Text (5)");
		InvokeRepeating ("Flash", 0.5f, 0.5f);
	}
	
	void Flash () {
		if (text.activeSelf == true) {
			text.SetActive (false);
		} else {
			text.SetActive (true);
		}
	}
}
