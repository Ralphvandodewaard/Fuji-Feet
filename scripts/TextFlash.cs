using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextFlash : MonoBehaviour {

	private GameObject text;
	
	void Start () {
		text = GameObject.Find ("Text");
		InvokeRepeating ("Flash", 0.5f, 0.5f);
	}
	
	void Update () {
		if (
			Input.GetButtonDown ("button0") ||
			Input.GetButtonDown ("button1") ||
			Input.GetButtonDown ("button2") ||
			Input.GetButtonDown ("button3") ||
			Input.GetButtonDown ("button4") ||
			Input.GetButtonDown ("button5") ||
			Input.GetButtonDown ("button6") ||
			Input.GetButtonDown ("button7")
			) {
			SceneManager.LoadScene ("intro");
		}

		if (Input.GetKeyDown ("m")) {
			SceneManager.LoadScene ("debug");
		}
	}
	
	void Flash () {
		if (text.activeSelf == true) {
			text.SetActive (false);
		} else {
			text.SetActive (true);
		}
	}
}
