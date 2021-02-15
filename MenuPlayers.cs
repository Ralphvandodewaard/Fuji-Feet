using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPlayers : MonoBehaviour {

	private GameObject button1;
	private GameObject button2;
	private GameObject button3;

	private MeshRenderer anotherButton1;
	private MeshRenderer anotherButton2;

	public Material black;
	public Material notBlack;

	private bool canPressButton = true;
	
	void Start () {
		button1 = transform.GetChild(0).gameObject;
		button2 = transform.GetChild(1).gameObject;
		button3 = transform.GetChild(2).gameObject;

		anotherButton1 = GameObject.Find ("Buttons/Button").GetComponent<MeshRenderer>();
		anotherButton2 = GameObject.Find ("Buttons/Button (1)").GetComponent<MeshRenderer>();
	}
	
	void Update () {
		if (canPressButton) {

		if (Input.GetKeyDown ("q")) {
			canPressButton = false;
			Invoke ("CanPressButtonAgain", 0.5f);
			anotherButton1.material = notBlack;
			Invoke ("BackToBlack", 0.1f);

			if (button1.GetComponent<Image> ().fillCenter == true) {
				button1.GetComponent<Image> ().fillCenter = false;
				button2.GetComponent<Image> ().fillCenter = true;
			} else if (button2.GetComponent<Image> ().fillCenter == true) {
				button2.GetComponent<Image> ().fillCenter = false;
				button3.GetComponent<Image> ().fillCenter = true;
			} else {
				button3.GetComponent<Image> ().fillCenter = false;
				button1.GetComponent<Image> ().fillCenter = true;
			}
		}

		if (Input.GetKeyDown ("e")) {
			canPressButton = false;
			Invoke ("CanPressButtonAgain", 0.5f);
			anotherButton2.material = notBlack;
			Invoke ("BackToBlack", 0.1f);

			if (button1.GetComponent<Image> ().fillCenter == true) {
				SceneManager.LoadScene ("game");
			} else if (button2.GetComponent<Image> ().fillCenter == true) {
				SceneManager.LoadScene ("game");
			} else {
				SceneManager.LoadScene ("game");
			}
		}	

		}
	}

	void BackToBlack () {
		anotherButton1.material = black;
		anotherButton2.material = black;
	}

	void CanPressButtonAgain () {
		canPressButton = true;
	}
}
