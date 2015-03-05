using UnityEngine;
using System.Collections;

public class AndroidEndScript : MonoBehaviour {

	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu)) {
				Application.Quit();
				return;
			}
		}
	}

    public void exit() {
        Application.Quit();
        return;
    }
}
