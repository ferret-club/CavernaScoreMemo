using UnityEngine;
using System.Collections;

public class IncrementButton : MonoBehaviour {

    public InputFieldUpdate inputFieldUpdate;

    // 得点を増やす
    public void incrementField() {
        int num = inputFieldUpdate.getInputField();
        num++;
        inputFieldUpdate.setInputField(num);
        inputFieldUpdate.calcSum();
    }

}
