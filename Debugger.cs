using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Debugger : MonoBehaviour {

	private Transform tiles;
	private Transform buttons;
	
	public Material mat;
	public Material trans;
	public Material black;

	public Color grey;
	public Color white;

	void Start () {
		tiles = GameObject.Find ("Tiles").transform;
		buttons = GameObject.Find ("Buttons").transform;
	}
	
	void Update () {
		if (Input.GetButton ("joystick7")) {
			tiles.GetChild (0).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (0).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3")) {
			tiles.GetChild (1).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (1).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick5")) {
			tiles.GetChild (2).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (2).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick2 4")) {
			tiles.GetChild (3).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (3).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick2 0")) {
			tiles.GetChild (4).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (4).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick2 6")) {
			tiles.GetChild (5).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (5).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick2")) {
			tiles.GetChild (6).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (6).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick1")) {
			tiles.GetChild (7).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (7).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick2 1")) {
			tiles.GetChild (8).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (8).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick2 2")) {
			tiles.GetChild (9).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (9).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 7")) {
			tiles.GetChild (10).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (10).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 3")) {
			tiles.GetChild (11).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (11).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 5")) {
			tiles.GetChild (12).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (12).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 4")) {
			tiles.GetChild (13).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (13).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 0")) {
			tiles.GetChild (14).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (14).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 6")) {
			tiles.GetChild (15).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (15).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 2")) {
			tiles.GetChild (16).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (16).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 1")) {
			tiles.GetChild (17).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (17).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 1")) {
			tiles.GetChild (18).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (18).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 2")) {
			tiles.GetChild (19).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (19).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 6")) {
			tiles.GetChild (20).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (20).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 0")) {
			tiles.GetChild (21).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (21).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick3 4")) {
			tiles.GetChild (22).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (22).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 5")) {
			tiles.GetChild (23).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (23).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 3")) {
			tiles.GetChild (24).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (24).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("joystick4 7")) {
			tiles.GetChild (25).GetComponent<MeshRenderer> ().material = mat;
		} else {
			tiles.GetChild (25).GetComponent<MeshRenderer> ().material = trans;
		}

		if (Input.GetButton ("button0")) {
			buttons.GetChild (0).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (0).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button1")) {
			buttons.GetChild (1).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (1).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button2")) {
			buttons.GetChild (2).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (2).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button3")) {
			buttons.GetChild (3).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (3).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button4")) {
			buttons.GetChild (4).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (4).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button5")) {
			buttons.GetChild (5).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (5).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button6")) {
			buttons.GetChild (6).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (6).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetButton ("button7")) {
			buttons.GetChild (7).GetComponent<MeshRenderer> ().material = mat;
		} else {
			buttons.GetChild (7).GetComponent<MeshRenderer> ().material = black;
		}

		if (Input.GetKeyDown ("backspace")) {
			SceneManager.LoadScene ("start");
		}
	}
}
