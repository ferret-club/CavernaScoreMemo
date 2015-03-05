using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InputFieldUpdate : MonoBehaviour, IDeselectHandler {

//	public enum fieldNames {
//		ANIMALS,
//		NOANIMALS,
//		WHEAT,
//		RUBY,
//		DWARF,
//		NOSPACE,
//		ROOMS,
//		BONUS,
//		MONEYANDBEGGER,
//	}
    public int FieldName;

    private InputField inputField;
    SumField sumField;

    void Start() {
        inputField = GetComponent<InputField>();
    }
    // フォーカスが外れたときに呼ばれる
    public void OnDeselect(BaseEventData eventData) {
        this.calcSum();
    }

    public void calcSum() {
//        int num = getInputField();
        if(sumField == null) {
            GameObject parentObj = this.transform.parent.transform.parent.transform.parent.gameObject;
            GameObject sumObject = parentObj.transform.FindChild("Summary").FindChild("Total").FindChild("SumField").gameObject;
            sumField = sumObject.GetComponent<SumField>() as SumField;
//            Debug.Log("sumField.name:" + sumField.name);
        }
//        sumField.FieldValues[FieldName] = num;
        sumField.CalcSum();
    }

    public int getInputField() {
        string val = inputField.value;
        double d;
        if(string.IsNullOrEmpty(val) || !double.TryParse(val, out d)) {
            return 0;
        }
        int num = int.Parse(val);
        return num;
    }

    public void setInputField(int _value) {
        inputField.value = _value.ToString();
    }
}
