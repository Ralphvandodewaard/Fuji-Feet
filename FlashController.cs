using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FlashController : MonoBehaviour {

	public static bool doFlash;
	
	private GameObject flash;
	Animator anim;

	public Material trans;
	public Material white;
	
	public VideoPlayer lava;
	public GameObject lavaCube;
	private MeshRenderer lavaMesh;
	
	void Start () {
		flash = transform.Find ("Flash").gameObject;
		anim = flash.GetComponent<Animator> ();
		lavaMesh = lavaCube.GetComponent<MeshRenderer> ();
	}
	
	void Update () {
		if (doFlash) {
			anim.SetTrigger ("Flash");
			lava.Play ();
			doFlash = false;
		}

		lava.loopPointReached += EndReached;

		if (lava.isPlaying) {
			lavaMesh.material = white;
			lavaCube.SetActive (true);
		} else {
			lavaMesh.material = trans;
			lavaCube.SetActive (false);
		}
	}

	void EndReached(UnityEngine.Video.VideoPlayer lava) {
        lava.frame = 0;
    }
}
