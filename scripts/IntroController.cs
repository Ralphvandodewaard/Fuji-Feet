using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroController : MonoBehaviour {

	private Transform tiles;
	private Transform buttons;
	private Transform ui;

	public Material mat;
	public Material trans;
	public Material black;
	public Material mat1;

	public Color grey;
	public Color white;

	private GameObject but;
	private GameObject pad;
	private GameObject lava;

	public GameObject score;
	public GameObject life;
	public GameObject checkmark1;
	public GameObject checkmark2;

	private float lifeTimer;
	private float newValue = 1f;

	public VideoPlayer volcano;
	public VideoPlayer realLava;
	public GameObject lavaCube;
	private MeshRenderer lavaMesh;
	public Material realWhite;

	public GameObject volCube;
	private MeshRenderer volMesh;

	private GameObject tile1;
	private GameObject tile2;
	private GameObject tile3;
	private GameObject tile4;

	public GameObject scoreText;

	/*public TextMeshProUGUI but1;
	public TextMeshProUGUI pad1;
	public TextMeshProUGUI lava1;*/

	void Start () {
		tiles = GameObject.Find ("Tiles").transform;
		buttons = GameObject.Find ("Buttons").transform;
		ui = GameObject.Find ("UI").transform;

		but = ui.Find ("Text").gameObject;
		pad = ui.Find ("Text (1)").gameObject;
		lava = ui.Find ("Text (2)").gameObject;

		/*but1 = but.GetComponent<TextMeshProUGUI> ();
		pad1 = pad.GetComponent<TextMeshProUGUI> ();
		lava1 = lava.GetComponent<TextMeshProUGUI> ();*/

		but.SetActive (false);
		pad.SetActive (false);
		lava.SetActive (false);
		checkmark1.SetActive (false);
		checkmark2.SetActive (false);

		lavaMesh = lavaCube.GetComponent<MeshRenderer> ();
		volMesh = volCube.GetComponent<MeshRenderer> ();

		Step1Button ();
		volcano.Play ();
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
			SceneManager.LoadScene ("game");
		}

		lifeTimer += Time.deltaTime;
		life.GetComponent<Image> ().fillAmount = Mathf.Lerp (1f, newValue, 0.7f * lifeTimer);

		if (realLava.isPlaying) {
			lavaMesh.material = realWhite;
			lavaCube.SetActive (true);
		} else {
			lavaMesh.material = trans;
			lavaCube.SetActive (false);
		}

		if (volcano.isPlaying) {
			volMesh.material = realWhite;
			volCube.SetActive (true);
		} else {
			volMesh.material = trans;
			volCube.SetActive (false);
		}
	}

	void Step1Button () {
		buttons.GetChild (4).GetComponent<MeshRenderer> ().material = mat1;
		buttons.GetChild (1).GetComponent<MeshRenderer> ().material = mat;
		
		but.SetActive (true);

		//Invoke ("Step1half", 2f);
		Invoke ("Step2Tiles", 4f);
	}

	/*void Step1half () {
		buttons.GetChild (4).GetComponent<MeshRenderer> ().material = black;
		buttons.GetChild (1).GetComponent<MeshRenderer> ().material = black;

		tile1 = tiles.GetChild (4).gameObject;
		tile2 = tiles.GetChild (9).gameObject;
		tile3 = tiles.GetChild (12).gameObject;
		tile4 = tiles.GetChild (15).gameObject;
		
		tile1.GetComponent<MeshRenderer> ().material = mat1;
		tile2.GetComponent<MeshRenderer> ().material = mat1;

		tile3.GetComponent<MeshRenderer> ().material = mat;
		tile4.GetComponent<MeshRenderer> ().material = mat;

		tile1.transform.position = new Vector3 (tile1.transform.position.x, tile1.transform.position.y, -3f);
		tile2.transform.position = new Vector3 (tile2.transform.position.x, tile2.transform.position.y, -3f);
		tile3.transform.position = new Vector3 (tile3.transform.position.x, tile3.transform.position.y, -3f);
		tile4.transform.position = new Vector3 (tile4.transform.position.x, tile4.transform.position.y, -3f);

		Invoke ("Step2Tiles", 2f);
	}*/

	void Step2Tiles () {
		buttons.GetChild (4).GetComponent<MeshRenderer> ().material = black;
		buttons.GetChild (1).GetComponent<MeshRenderer> ().material = black;

		tile1 = tiles.GetChild (4).gameObject;
		tile2 = tiles.GetChild (9).gameObject;
		tile3 = tiles.GetChild (12).gameObject;
		tile4 = tiles.GetChild (15).gameObject;
		
		tile1.GetComponent<MeshRenderer> ().material = mat1;
		tile2.GetComponent<MeshRenderer> ().material = mat1;

		tile3.GetComponent<MeshRenderer> ().material = mat;
		tile4.GetComponent<MeshRenderer> ().material = mat;

		tile1.transform.position = new Vector3 (tile1.transform.position.x, tile1.transform.position.y, -3f);
		tile2.transform.position = new Vector3 (tile2.transform.position.x, tile2.transform.position.y, -3f);
		tile3.transform.position = new Vector3 (tile3.transform.position.x, tile3.transform.position.y, -3f);
		tile4.transform.position = new Vector3 (tile4.transform.position.x, tile4.transform.position.y, -3f);
		but.SetActive (false);
		pad.SetActive (true);

		//Invoke ("Step2half", 2f);
		Invoke ("Step3Checkmark", 4f);
	}

	/*void Step2half () {
		checkmark1.SetActive (true);
		checkmark2.SetActive (true);
		Invoke ("Step3Lava", 2f);
	}*/
	
	void Step3Checkmark () {
		checkmark1.SetActive (true);
		checkmark2.SetActive (true);
		pad.SetActive (false);
		lava.SetActive (true);

		//Invoke ("Step3half", 2f);
		Invoke ("Step4Lava", 4f);
	}

	/*void Step3half () {
		realLava.Play ();
		Invoke ("Step4Score", 3f);
	}*/

	void Step4Lava () {
		realLava.Play ();

		Invoke ("Step5Score", 4f);
	}

	void Step5Score () {
		lava.SetActive (false);
		scoreText.SetActive (true);
		score.GetComponent<TextMeshProUGUI> ().text = "001";
		newValue = 0.66f;
		lifeTimer = 0;
		Invoke ("NextScene", 4f);
	}

	void NextScene () {
		SceneManager.LoadScene ("game");
	}
}
