using UnityEngine;
using System.Collections;

public class DecrementButton : MonoBehaviour {

    public InputFieldUpdate inputFieldUpdate;

    // 得点を減らす
    public void decrementField() {
        int num = inputFieldUpdate.getInputField();
        num--;
        inputFieldUpdate.setInputField(num);
        inputFieldUpdate.calcSum();
    }

}
