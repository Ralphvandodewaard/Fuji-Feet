using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticController : MonoBehaviour {

	public float maxRange;
	public float timer;
	public float turnDelay;
	public Material tileIdleMat;
	public Material tileRemovedMat;
	public Material buttonIdleMat;

	public static float g_gridSize;
	public static float g_maxRange;
	public static float g_timer;
	public static float g_turnDelay;
	public static Material g_tileIdleMat;
	public static Material g_tileRemovedMat;
	public static Material g_buttonIdleMat;
	public static bool winnerExists;
	public static bool menuMusic;

	//PLAYER TILE1 NUMBERS;
	public static int t1_1;
	public static int t2_1;
	public static int t3_1;
	public static int t4_1;

	//PLAYER TILE2 NUMBERS;
	public static int t1_2;
	public static int t2_2;
	public static int t3_2;
	public static int t4_2;
	
	//PLAYER BUTTON NUMBERS
	public static int b_1;
	public static int b_2;
	public static int b_3;
	public static int b_4;

	public static bool playerOneOut;
	public static bool playerTwoOut;
	public static bool playerThreeOut;
	public static bool playerFourOut;

	public static bool onePlayerOut;
	public static bool twoPlayerOut;

	public static bool coffee;
	
	void Awake () {
		g_gridSize = 26 - 1;
		g_maxRange = maxRange;
		g_timer = timer;
		g_turnDelay = turnDelay;
		g_tileIdleMat = tileIdleMat;
		g_tileRemovedMat = tileRemovedMat;
		g_buttonIdleMat = buttonIdleMat;
	}

	void Update () {
		if (playerOneOut || playerTwoOut || playerThreeOut || playerFourOut) {
			onePlayerOut = true;
		}

		if (onePlayerOut && playerOneOut) {
			if (playerTwoOut || playerThreeOut || playerFourOut) {
				twoPlayerOut = true;
			}
		} else if (onePlayerOut && playerTwoOut) {
			if (playerOneOut || playerThreeOut || playerFourOut) {
				twoPlayerOut = true;
			}
		} else if (onePlayerOut && playerThreeOut) {
			if (playerOneOut || playerTwoOut || playerFourOut) {
				twoPlayerOut = true;
			}
		} else if (onePlayerOut && playerFourOut) {
			if (playerOneOut || playerTwoOut || playerThreeOut) {
				twoPlayerOut = true;
			}
		}

		if (TimerController.timeZero) {
			coffee = true;

			if (twoPlayerOut && StaticController.g_timer > 5f) {
				StaticController.g_timer -= 1f;
			}
		}
	}
}
