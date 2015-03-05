using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Name : MonoBehaviour, ISelectHandler {

    TouchScreenKeyboard keyboard;
    string inputtedName = "";
    private InputField inputField;

    // Use this for initialization
	void Start () {
        if(inputField == null) {
            inputField = this.transform.GetComponentInChildren<InputField>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        // キーボードが閉じた時
//        if (this.keyboard != null && this.keyboard.done) {
//            Debug.Log("keyboard.done");
//            this.inputtedName = this.keyboard.text;
//            inputField.text = this.inputtedName;
//            this.keyboard = null;
//        } else if(this.keyboard != null && this.keyboard.wasCanceled) {
//            Debug.Log("keyboard.wasCanceled");
//            this.keyboard = null;
//        }
	}

    public void OnSelect(BaseEventData eventData) {
        // キーボードを表示する
//        if(this.keyboard == null) {
//            this.keyboard = TouchScreenKeyboard.Open(this.inputtedName, TouchScreenKeyboardType.EmailAddress);
//        }
    }

}
