using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public string player;
	private string buttonInput;
	
	public Material activeColor;
	public Color buttonColor;

	private bool canDoAnimation = true;
	private bool canDoDraw = true;
	private bool canPressButton = true;

	//PLAYERS
	private bool player1;
	private bool player2;
	private bool player3;
	private bool player4;

	//NUMBERS
	private int buttonNumber;
	private int tileNumber1 = 0;
	private int tileNumber2 = 0;

	//BUTTONS & TILES
	private Transform buttons;
	private Transform tiles;
	private MeshRenderer button;
	private GameObject tile1;
	private GameObject tile2;
	private bool firstButton = true;

	private GameObject checkmark1;
	private GameObject checkmark2;

	//SCORE
	private float score = 0;
	private bool tileCorrect1;
	private bool tileCorrect2;
	private bool playerHasScored;

	//LIVES
	public float lives;
	private float maxLives;
	private float currentLives;
	private float newLives;

	//USER INTERFACE
	private Transform ui;
	private TextMeshProUGUI uiScore;
	private GameObject uiScoreUp;
	private Image uiLife;
	private GameObject rip;
	//private GameObject win;
	private GameObject globalWin;
	private GameObject globalDraw;

	private float lifeTimer;
	
	void Start () {
		//DECLARE PLAYER
		if (player == "Player1") {
			player1 = true;
		} else if (player == "Player2") {
			player2 = true;
		} else if (player == "Player3") {
			player3 = true;
		} else if (player == "Player4") {
			player4 = true;
		}

		//DECLARE MAX VARIABLES
		maxLives = lives;
		currentLives = lives;
		newLives = lives;

		//DECLARE BUTTONS & TILES
		buttons = GameObject.Find ("Buttons").transform;
		tiles = GameObject.Find ("Tiles").transform;
		
		//DECLARE UI
		ui = GameObject.Find ("UI/" + player).transform;
		uiScore = ui.Find ("Score").gameObject.GetComponent<TextMeshProUGUI> ();
		uiLife = ui.Find ("Life").gameObject.GetComponent<Image> ();
		rip = ui.Find ("Out").gameObject;
		//win = ui.Find ("Win").gameObject;
		uiScoreUp = GameObject.Find ("UI/" + player + "/Plus").gameObject;
		
		if (player1) {
			globalWin = GameObject.Find ("UI/WinPlayer1").gameObject;
		} else if (player2) {
			globalWin = GameObject.Find ("UI/WinPlayer2").gameObject;
		} else if (player3) {
			globalWin = GameObject.Find ("UI/WinPlayer3").gameObject;
		} else if (player4) {
			globalWin = GameObject.Find ("UI/WinPlayer4").gameObject;
		}
		globalWin.SetActive (false);
		
		if (player1) {
		globalDraw = GameObject.Find ("UI/Draw").gameObject;
		globalDraw.SetActive (false);
		}
	}
	
	void Update () {
		if (TimerController.startRealTimer) {
			if (firstButton) {
				firstButton = false;
			
				//GENERATE FIRST BUTTON
				GenerateRandomButtonNumber ();

				if (player1) {
				StaticController.b_1 = buttonNumber;
				} else if (player2) {
				StaticController.b_2 = buttonNumber;
				} else if (player3) {
				StaticController.b_3 = buttonNumber;
				} else if (player4) {
					StaticController.b_4 = buttonNumber;
				}

				button = buttons.GetChild(buttonNumber).gameObject.GetComponent<MeshRenderer> ();
				button.material = activeColor;
			}
		
			//SET BUTTON INPUT
			for (int i = 0; i <= 7; i++) {
				if (buttonNumber == i) {
					buttonInput = "button" + i;
				}
			}

			//CHECK FOR BUTTON INPUT
			if (lives > 0 && !StaticController.winnerExists && canPressButton && Input.GetButtonDown(buttonInput)) {
				ActivateTiles ();
			}

			if (
			(tileNumber1 == 0 && Input.GetButton ("joystick7")) ||
			(tileNumber1 == 1 && Input.GetButton ("joystick3")) ||
			(tileNumber1 == 2 && Input.GetButton ("joystick5")) ||

			(tileNumber1 == 3 && Input.GetButton ("joystick2 4")) ||
			(tileNumber1 == 4 && Input.GetButton ("joystick2 0")) ||
			(tileNumber1 == 5 && Input.GetButton ("joystick2 6")) ||

			(tileNumber1 == 6 && Input.GetButton ("joystick2")) ||
			(tileNumber1 == 7 && Input.GetButton ("joystick1")) ||

			(tileNumber1 == 8 && Input.GetButton ("joystick2 1")) ||
			(tileNumber1 == 9 && Input.GetButton ("joystick2 2")) ||

			(tileNumber1 == 10 && Input.GetButton ("joystick3 7")) ||
			(tileNumber1 == 11 && Input.GetButton ("joystick3 3")) ||
			(tileNumber1 == 12 && Input.GetButton ("joystick3 5")) ||

			(tileNumber1 == 13 && Input.GetButton ("joystick4 4")) ||
			(tileNumber1 == 14 && Input.GetButton ("joystick4 0")) ||
			(tileNumber1 == 15 && Input.GetButton ("joystick4 6")) ||

			(tileNumber1 == 16 && Input.GetButton ("joystick3 2")) ||
			(tileNumber1 == 17 && Input.GetButton ("joystick3 1")) ||

			(tileNumber1 == 18 && Input.GetButton ("joystick4 1")) ||
			(tileNumber1 == 19 && Input.GetButton ("joystick4 2")) ||

			(tileNumber1 == 20 && Input.GetButton ("joystick3 6")) ||
			(tileNumber1 == 21 && Input.GetButton ("joystick3 0")) ||
			(tileNumber1 == 22 && Input.GetButton ("joystick3 4")) ||

			(tileNumber1 == 23 && Input.GetButton ("joystick4 5")) ||
			(tileNumber1 == 24 && Input.GetButton ("joystick4 3")) ||
			(tileNumber1 == 25 && Input.GetButton ("joystick4 7"))
				) {
				if (tile1 != null) {
					checkmark1.SetActive (true);
				}
			} else {
				if (tile1 != null) {
					checkmark1.SetActive (false);
				}
			}

			if (
			(tileNumber2 == 0 && Input.GetButton ("joystick7")) ||
			(tileNumber2 == 1 && Input.GetButton ("joystick3")) ||
			(tileNumber2 == 2 && Input.GetButton ("joystick5")) ||

			(tileNumber2 == 3 && Input.GetButton ("joystick2 4")) ||
			(tileNumber2 == 4 && Input.GetButton ("joystick2 0")) ||
			(tileNumber2 == 5 && Input.GetButton ("joystick2 6")) ||

			(tileNumber2 == 6 && Input.GetButton ("joystick2")) ||
			(tileNumber2 == 7 && Input.GetButton ("joystick1")) ||

			(tileNumber2 == 8 && Input.GetButton ("joystick2 1")) ||
			(tileNumber2 == 9 && Input.GetButton ("joystick2 2")) ||

			(tileNumber2 == 10 && Input.GetButton ("joystick3 7")) ||
			(tileNumber2 == 11 && Input.GetButton ("joystick3 3")) ||
			(tileNumber2 == 12 && Input.GetButton ("joystick3 5")) ||

			(tileNumber2 == 13 && Input.GetButton ("joystick4 4")) ||
			(tileNumber2 == 14 && Input.GetButton ("joystick4 0")) ||
			(tileNumber2 == 15 && Input.GetButton ("joystick4 6")) ||

			(tileNumber2 == 16 && Input.GetButton ("joystick3 2")) ||
			(tileNumber2 == 17 && Input.GetButton ("joystick3 1")) ||

			(tileNumber2 == 18 && Input.GetButton ("joystick4 1")) ||
			(tileNumber2 == 19 && Input.GetButton ("joystick4 2")) ||

			(tileNumber2 == 20 && Input.GetButton ("joystick3 6")) ||
			(tileNumber2 == 21 && Input.GetButton ("joystick3 0")) ||
			(tileNumber2 == 22 && Input.GetButton ("joystick3 4")) ||

			(tileNumber2 == 23 && Input.GetButton ("joystick4 5")) ||
			(tileNumber2 == 24 && Input.GetButton ("joystick4 3")) ||
			(tileNumber2 == 25 && Input.GetButton ("joystick4 7"))
			) {
				if (tile2 != null) {
					checkmark2.SetActive (true);
				}
			} else {
				if (tile2 != null) {
					checkmark2.SetActive (false);
				}
			}
		
			if (TimerController.timeZero) {
				//CHECK FOR CORRECT TILES
				if (
				(tileNumber1 == 0 && Input.GetButton ("joystick7")) ||
				(tileNumber1 == 1 && Input.GetButton ("joystick3")) ||
				(tileNumber1 == 2 && Input.GetButton ("joystick5")) ||

				(tileNumber1 == 3 && Input.GetButton ("joystick2 4")) ||
				(tileNumber1 == 4 && Input.GetButton ("joystick2 0")) ||
				(tileNumber1 == 5 && Input.GetButton ("joystick2 6")) ||

				(tileNumber1 == 6 && Input.GetButton ("joystick2")) ||
				(tileNumber1 == 7 && Input.GetButton ("joystick1")) ||

				(tileNumber1 == 8 && Input.GetButton ("joystick2 1")) ||
				(tileNumber1 == 9 && Input.GetButton ("joystick2 2")) ||

				(tileNumber1 == 10 && Input.GetButton ("joystick3 7")) ||
				(tileNumber1 == 11 && Input.GetButton ("joystick3 3")) ||
				(tileNumber1 == 12 && Input.GetButton ("joystick3 5")) ||

				(tileNumber1 == 13 && Input.GetButton ("joystick4 4")) ||
				(tileNumber1 == 14 && Input.GetButton ("joystick4 0")) ||
				(tileNumber1 == 15 && Input.GetButton ("joystick4 6")) ||

				(tileNumber1 == 16 && Input.GetButton ("joystick3 2")) ||
				(tileNumber1 == 17 && Input.GetButton ("joystick3 1")) ||

				(tileNumber1 == 18 && Input.GetButton ("joystick4 1")) ||
				(tileNumber1 == 19 && Input.GetButton ("joystick4 2")) ||

				(tileNumber1 == 20 && Input.GetButton ("joystick3 6")) ||
				(tileNumber1 == 21 && Input.GetButton ("joystick3 0")) ||
				(tileNumber1 == 22 && Input.GetButton ("joystick3 4")) ||

				(tileNumber1 == 23 && Input.GetButton ("joystick4 5")) ||
				(tileNumber1 == 24 && Input.GetButton ("joystick4 3")) ||
				(tileNumber1 == 25 && Input.GetButton ("joystick4 7"))
				) {
					tileCorrect1 = true;
				}
			
				if (
				(tileNumber2 == 0 && Input.GetButton ("joystick7")) ||
				(tileNumber2 == 1 && Input.GetButton ("joystick3")) ||
				(tileNumber2 == 2 && Input.GetButton ("joystick5")) ||

				(tileNumber2 == 3 && Input.GetButton ("joystick2 4")) ||
				(tileNumber2 == 4 && Input.GetButton ("joystick2 0")) ||
				(tileNumber2 == 5 && Input.GetButton ("joystick2 6")) ||

				(tileNumber2 == 6 && Input.GetButton ("joystick2")) ||
				(tileNumber2 == 7 && Input.GetButton ("joystick1")) ||

				(tileNumber2 == 8 && Input.GetButton ("joystick2 1")) ||
				(tileNumber2 == 9 && Input.GetButton ("joystick2 2")) ||

				(tileNumber2 == 10 && Input.GetButton ("joystick3 7")) ||
				(tileNumber2 == 11 && Input.GetButton ("joystick3 3")) ||
				(tileNumber2 == 12 && Input.GetButton ("joystick3 5")) ||

				(tileNumber2 == 13 && Input.GetButton ("joystick4 4")) ||
				(tileNumber2 == 14 && Input.GetButton ("joystick4 0")) ||
				(tileNumber2 == 15 && Input.GetButton ("joystick4 6")) ||

				(tileNumber2 == 16 && Input.GetButton ("joystick3 2")) ||
				(tileNumber2 == 17 && Input.GetButton ("joystick3 1")) ||

				(tileNumber2 == 18 && Input.GetButton ("joystick4 1")) ||
				(tileNumber2 == 19 && Input.GetButton ("joystick4 2")) ||

				(tileNumber2 == 20 && Input.GetButton ("joystick3 6")) ||
				(tileNumber2 == 21 && Input.GetButton ("joystick3 0")) ||
				(tileNumber2 == 22 && Input.GetButton ("joystick3 4")) ||

				(tileNumber2 == 23 && Input.GetButton ("joystick4 5")) ||
				(tileNumber2 == 24 && Input.GetButton ("joystick4 3")) ||
				(tileNumber2 == 25 && Input.GetButton ("joystick4 7"))
				) {
					tileCorrect2 = true;
				}

				//CHECK IF SCORED
				if (tileCorrect1 && tileCorrect2) {
					tileCorrect1 = false;
					tileCorrect2 = false;
					playerHasScored = true;
				} else {
					currentLives = lives;
					lives--;
					newLives = lives;
					lifeTimer = 0;
				}

				if (checkmark1 != null) {
					checkmark1.SetActive (false);
					checkmark2.SetActive (false);
				}

				canPressButton = true;
			
				if (tile1 != null) {
					tile1.GetComponent<MeshRenderer> ().material = StaticController.g_tileIdleMat;
					tile2.GetComponent<MeshRenderer> ().material = StaticController.g_tileIdleMat;

					tile1.transform.position = new Vector3 (tile1.transform.position.x, tile1.transform.position.y, 0);
					tile2.transform.position = new Vector3 (tile2.transform.position.x, tile2.transform.position.y, 0);
				
					tile1 = null;
					tile2 = null;
				}

				button.material = StaticController.g_buttonIdleMat;
				
				if (lives > 0 && !StaticController.winnerExists) {
					//GENERATE NEW BUTTON
					if (Random.value < 0.25f) {
						GenerateRandomButtonNumber ();
					} else {
						if (
						(tileNumber2 >= 0 && tileNumber2 <= 2) ||
						(tileNumber2 >= 6 && tileNumber2 <= 7)
						) {
							GenerateFixedButtonNumber (2, 6);
						} else if (
						(tileNumber2 >= 3 && tileNumber2 <= 5) ||
						(tileNumber2 >= 8 && tileNumber2 <= 9)
						) {
							GenerateFixedButtonNumber (3, 7);
						} else if (
						(tileNumber2 >= 16 && tileNumber2 <= 17) ||
						(tileNumber2 >= 20 && tileNumber2 <= 22)
						) {
							GenerateFixedButtonNumber (0, 4);
						} else {
							GenerateRandomButtonNumber ();
						}
					}

					button = buttons.GetChild(buttonNumber).gameObject.GetComponent<MeshRenderer> ();
					button.material = activeColor;
				
					if (player1) {
						StaticController.b_1 = buttonNumber;
					} else if (player2) {
						StaticController.b_2 = buttonNumber;
					} else if (player3) {
						StaticController.b_3 = buttonNumber;
					} else if (player4) {
						StaticController.b_4 = buttonNumber;
					}
				}
			}
		}

		//UPDATE LIFE
		lifeTimer += Time.deltaTime;
		uiLife.fillAmount = Mathf.Lerp (currentLives / maxLives, newLives / maxLives, 0.7f * lifeTimer);
		
		if (lives == 0 && canDoAnimation) {
			canDoAnimation = false;
			rip.SetActive (true);
			rip.GetComponent<AudioSource> ().Play ();
			rip.GetComponent<Animator> ().SetTrigger ("Fall");
			
			if (player1) {
				StaticController.playerOneOut = true;
			} else if (player2) {
				StaticController.playerTwoOut = true;
			} else if (player3) {
				StaticController.playerThreeOut = true;
			} else if (player4) {
				StaticController.playerFourOut = true;
			}
		}

		//UPDATE SCORE
		if (playerHasScored) {
			playerHasScored = false;
			uiScoreUp.GetComponent<Animator> ().SetTrigger ("ScoreUp");
			score++;
		}
		
		if (score < 10) {
			uiScore.text = "00" + Mathf.Round(score).ToString();
		} else if (score >= 10 && score < 100) {
			uiScore.text = "0" + Mathf.Round(score).ToString();
		} else {
			uiScore.text = Mathf.Round(score).ToString();
		}

		if (
		(player1 && StaticController.playerTwoOut && StaticController.playerThreeOut && StaticController.playerFourOut && canDoAnimation) ||
		(player2 && StaticController.playerOneOut && StaticController.playerThreeOut && StaticController.playerFourOut && canDoAnimation) ||
		(player3 && StaticController.playerOneOut && StaticController.playerTwoOut && StaticController.playerFourOut && canDoAnimation) ||
		(player4 && StaticController.playerOneOut && StaticController.playerTwoOut && StaticController.playerThreeOut && canDoAnimation)
		) {
			canDoAnimation = false;
			Invoke ("WinAnim", 1f);
			StaticController.winnerExists = true;
		}

		if (player1) {
			if (StaticController.playerOneOut && StaticController.playerTwoOut && StaticController.playerThreeOut && StaticController.playerFourOut && canDoDraw) {
				canDoDraw = false;
				Invoke ("DrawAnim", 1f);
			}
		}
	}

	void GenerateRandomButtonNumber () {
		buttonNumber = Mathf.RoundToInt (Random.Range (0, 7));

		while (
		buttonNumber == StaticController.b_1 ||
		buttonNumber == StaticController.b_2 ||
		buttonNumber == StaticController.b_3 ||
		buttonNumber == StaticController.b_4
		) {
			buttonNumber = Mathf.RoundToInt (Random.Range (0, 7));
		}
	}

	void GenerateFixedButtonNumber (float first, float second) {
		buttonNumber = Mathf.RoundToInt (Random.Range (first, second));
			
		while (
		buttonNumber == StaticController.b_1 ||
		buttonNumber == StaticController.b_2 ||
		buttonNumber == StaticController.b_3 ||
		buttonNumber == StaticController.b_4
		) {
			buttonNumber = Mathf.RoundToInt (Random.Range (first, second));
		}
	}
	
	void ActivateTiles () {
		canPressButton = false;
		button.material = StaticController.g_buttonIdleMat;

		tileNumber1 = Mathf.RoundToInt (Random.Range (0, StaticController.g_gridSize));

		while (
		tileNumber1 == StaticController.t1_1 ||
		tileNumber1 == StaticController.t1_2 ||
		tileNumber1 == StaticController.t2_1 ||
		tileNumber1 == StaticController.t2_2 ||
		tileNumber1 == StaticController.t3_1 ||
		tileNumber1 == StaticController.t3_2 ||
		tileNumber1 == StaticController.t4_1 ||
		tileNumber1 == StaticController.t4_2
		) {
			tileNumber1 = Mathf.RoundToInt (Random.Range (0, StaticController.g_gridSize));
		}

		if (tileNumber1 < StaticController.g_maxRange) {
			tileNumber2 = tileNumber1 + Mathf.RoundToInt (Random.Range (1f, StaticController.g_maxRange));
			CheckForTileReroll (1f, StaticController.g_maxRange);	
		} else if (tileNumber1 > StaticController.g_gridSize - StaticController.g_maxRange) {
			tileNumber2 = tileNumber1 + Mathf.RoundToInt (Random.Range (-StaticController.g_maxRange, -1f));
			CheckForTileReroll (-StaticController.g_maxRange, -1f);	
		} else {
			tileNumber2 = tileNumber1 + Mathf.RoundToInt (Random.Range (-StaticController.g_maxRange, StaticController.g_maxRange));
			
			while (tileNumber1 == tileNumber2) {
				tileNumber2 = tileNumber1 + Mathf.RoundToInt (Random.Range (-StaticController.g_maxRange, StaticController.g_maxRange));
			}
			
			CheckForTileReroll (-StaticController.g_maxRange, StaticController.g_maxRange);	
		}

		tile1 = tiles.GetChild (tileNumber1).gameObject;
		tile1.transform.position = new Vector3 (tile1.transform.position.x, tile1.transform.position.y, -3f);
		tile1.GetComponent<MeshRenderer> ().material = activeColor;
		checkmark1 = tile1.transform.Find ("checkmark").gameObject;

		tile2 = tiles.GetChild (tileNumber2).gameObject;
		tile2.transform.position = new Vector3 (tile2.transform.position.x, tile2.transform.position.y, -3f);
		tile2.GetComponent<MeshRenderer> ().material = activeColor;
		checkmark2 = tile2.transform.Find ("checkmark").gameObject;

		if (player1) {
			StaticController.t1_1 = tileNumber1;
			StaticController.t1_2 = tileNumber2;
		} else if (player2) {
			StaticController.t2_1 = tileNumber1;
			StaticController.t2_2 = tileNumber2;
		} else if (player3) {
			StaticController.t3_1 = tileNumber1;
			StaticController.t3_2 = tileNumber2;
		} else if (player4) {
			StaticController.t4_1 = tileNumber1;
			StaticController.t4_2 = tileNumber2;
		}
	}

	void CheckForTileReroll (float first, float second) {
		while (
			tileNumber2 == StaticController.t1_1 ||
			tileNumber2 == StaticController.t1_2 ||
			tileNumber2 == StaticController.t2_1 ||
			tileNumber2 == StaticController.t2_2 ||
			tileNumber2 == StaticController.t3_1 ||
			tileNumber2 == StaticController.t3_2 ||
			tileNumber2 == StaticController.t4_1 ||
			tileNumber2 == StaticController.t4_2
			) {
				tileNumber2 = tileNumber1 + Mathf.RoundToInt (Random.Range (first, second));
			}
	}

	void WinAnim () {
		globalWin.SetActive (true);
		globalWin.GetComponents<AudioSource> ()[0].Play ();
		globalWin.GetComponents<AudioSource> ()[1].Play ();
		globalWin.GetComponent<Animator> ().SetTrigger ("Fall");
		Invoke ("Restart", 12f);
	}

	void DrawAnim () {
		globalDraw.SetActive (true);
		globalDraw.GetComponents<AudioSource> ()[0].Play ();
		globalDraw.GetComponents<AudioSource> ()[1].Play ();
		globalDraw.GetComponent<Animator> ().SetTrigger ("Fall");
		Invoke ("Restart", 12f);
	}

	void Restart () {
		StaticController.g_gridSize = 26 - 1;
		StaticController.g_timer = 8f;
		StaticController.winnerExists = false;
		StaticController.playerOneOut = false;
		StaticController.playerTwoOut = false;
		StaticController.playerThreeOut = false;
		StaticController.playerFourOut = false;
		StaticController.onePlayerOut = false;
		StaticController.twoPlayerOut = false;
		StaticController.coffee = false;
		TimerController.timeZero = false;
		TimerController.startRealTimer = false;
		StaticController.menuMusic = true;
		Destroy(GameObject.Find ("DontDestroy").gameObject);
		SceneManager.LoadScene ("start");
	}
}
