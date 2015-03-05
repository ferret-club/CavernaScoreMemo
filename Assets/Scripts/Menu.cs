using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    Animator menuAnimator;

    // Use this for initialization
	void Start () {
        menuAnimator = this.GetComponent<Animator>();
	}
	
    public void menuAnimationFinish() {
        setMenuStatus(0);
    }

    public void setMenuStatus(int status) {
        menuAnimator.SetInteger("menuStatus", status);
    }
}
