using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

	private MeshRenderer tile;
	private bool removeFirstRow;
	private bool removeSecondRow;
	
	void Update () {
		if (StaticController.onePlayerOut && !removeFirstRow) {
			removeFirstRow = true;

			for (int i = Mathf.RoundToInt(StaticController.g_gridSize); i >= StaticController.g_gridSize - 5; i--) {
				tile = transform.GetChild(i).gameObject.GetComponent<MeshRenderer> ();
				tile.material = StaticController.g_tileRemovedMat;
			}

			StaticController.g_gridSize -= 6;
		}

		if (StaticController.twoPlayerOut && !removeSecondRow) {
			removeSecondRow = true;

			for (int i = Mathf.RoundToInt(StaticController.g_gridSize); i >= StaticController.g_gridSize - 3; i--) {
				tile = transform.GetChild(i).gameObject.GetComponent<MeshRenderer> ();
				tile.material = StaticController.g_tileRemovedMat;
			}

			StaticController.g_gridSize -= 4;
		}

		if (TimerController.timeZero) {
			TimerController.timeZero = false;
		}
	}
}
