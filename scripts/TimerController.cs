using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class TimerController : MonoBehaviour {

	public static bool timeZero;
	private bool canDoTime = true;
	
	private float actualTimer;
	private bool canFlash = true;

	private Image radial;
	private AudioSource sfx;
	private bool playSound = true;
	private bool playVideo = true;

	private float startTimer = 3f;
	private TextMeshProUGUI startText; 
	private GameObject startTextObject;
	private bool canStartGame;
	public static bool startRealTimer;

	private GameObject color1;
	private GameObject color2;
	private GameObject color3;
	private GameObject color4;
	private GameObject trbg;

	public VideoPlayer volcano;

	public Material trans;
	public Material white;
	
	public GameObject volcCube;
	private MeshRenderer volcMesh;

	public AudioClip sec8;
	public AudioClip sec7;
	public AudioClip sec6;
	public AudioClip sec5;

	public GameObject musica;
	public GameObject countdown;
	private bool playMusic = true;
	private bool playCountdown = true;
	
	void Start () {
		actualTimer = StaticController.g_timer;
		radial = GameObject.Find ("UI/Radial").GetComponent<Image> ();
		sfx = GameObject.Find ("UI/Radial").GetComponent<AudioSource> ();

		volcMesh = volcCube.GetComponent<MeshRenderer> ();

		color1 = GameObject.Find ("UI/Color1");
		color2 = GameObject.Find ("UI/Color2");
		color3 = GameObject.Find ("UI/Color3");
		color4 = GameObject.Find ("UI/Color4");
		trbg = GameObject.Find ("UI/trbg");

		startTextObject = GameObject.Find ("UI/StartText");
		startText = startTextObject.GetComponent<TextMeshProUGUI> ();
		Invoke ("StartStartTimer", 8f);
		Invoke ("FunctionToBeNamed", 5f);
		volcano.Play ();
		volcano.Pause ();
		Invoke ("fuckingvulkaan", 0.5f);
	}
	
	void fuckingvulkaan () {
		volcMesh.material = white;
	}
	
	void Update () {
		if (canStartGame) {
			startTimer -= Time.deltaTime;
			startText.text = Mathf.Ceil (startTimer).ToString ();
			if (playCountdown) {
				playCountdown = false;
				countdown.GetComponent<AudioSource> ().Play ();
			}
		}

		if (startTimer < 0) {
			startTextObject.SetActive(false);
			startRealTimer = true;

			color1.SetActive(false);
			color2.SetActive(false);
			color3.SetActive(false);
			color4.SetActive(false);
			trbg.SetActive(false);
		}

		if (startRealTimer) {
			if (StaticController.coffee) {
				actualTimer = StaticController.g_timer;
				canFlash = true;
				playSound = true;
				playVideo = true;
				StaticController.coffee = false;
			}
		
			if (StaticController.winnerExists) {
				canDoTime = false;
				volcMesh.material = trans;
				volcano.Stop ();
			}

			if (StaticController.playerOneOut && StaticController.playerTwoOut && StaticController.playerThreeOut && StaticController.playerFourOut) {
				canDoTime = false;
				
			}
		
			if (canDoTime) {
				actualTimer -= Time.deltaTime;
				radial.fillAmount = actualTimer / StaticController.g_timer;

				if (playMusic) {
					playMusic = false;
					GameObject.Find ("DontDestroy").GetComponent<AudioSource> ().Stop ();
					musica.GetComponent<AudioSource> ().Play ();
				}
				
				if (playVideo) {
					playVideo = false;
					if (StaticController.g_timer == 8f) {
						volcano.playbackSpeed = 0.9f;
					} else if (StaticController.g_timer == 7f) {
						volcano.playbackSpeed = 1.1f;
					} else if (StaticController.g_timer == 6f) {
						volcano.playbackSpeed = 1.2f;
					} else if (StaticController.g_timer == 5f) {
						volcano.playbackSpeed = 1.4f;
					}
					volcano.Play ();
				}

				if (playSound) {
					playSound = false;
					if (StaticController.g_timer == 8f) {
						sfx.PlayOneShot (sec8);
					} else if (StaticController.g_timer == 7f) {
						sfx.PlayOneShot (sec7);
					} else if (StaticController.g_timer == 6f) {
						sfx.PlayOneShot (sec6);
					} else if (StaticController.g_timer == 5f) {
						sfx.PlayOneShot (sec5);
					}
				}

				volcano.loopPointReached += EndReached;
		
				if (actualTimer < 0) {
					actualTimer = 0;
					if (canFlash) {
						Invoke ("Reset", StaticController.g_turnDelay);
						FlashController.doFlash = true;
						canFlash = false;
					}
				}
			}
		}
	}

	void EndReached(UnityEngine.Video.VideoPlayer volcano) {
        volcano.frame = 0;
    }

	void Reset () {
		timeZero = true;
	}

	void StartStartTimer () {
		canStartGame = true;
	}

	void FunctionToBeNamed () {
		startText.text = "Get ready";
	}
}
