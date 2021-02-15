using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {

	private static bool created = false;

    void Awake () {
        if (StaticController.menuMusic) {
            created = false;
            StaticController.menuMusic = false;
        }
        
        if (!created) {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
}
