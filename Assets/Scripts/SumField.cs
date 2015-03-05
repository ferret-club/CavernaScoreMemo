using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SumField : MonoBehaviour {

//    public int[] FieldValues = new int[17];

    [HideInInspector]
    public int sum;
    MainCanvas mainCanvas;
    Text me;
    Player player;

    void Start() {
        me = GetComponent<Text>();
        sum = 0;
        mainCanvas = this.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<MainCanvas>() as MainCanvas;
    }

    public void CalcSum() {
        sum = 0;
//        for(int cnt = 0; cnt < FieldValues.Length; cnt++) {
//            sum += FieldValues[cnt];
//        }
        for(int cnt = 0; cnt < mainCanvas.inputFieldUpdates.Count; cnt++) {
            sum += mainCanvas.inputFieldUpdates[cnt].getInputField();
        }
        me.text = sum.ToString();
//        Debug.Log("CalcSum text:" + me.text + " sum:" + sum + " mainCanvas.myNumber:" + mainCanvas.myNumber);
        // playerリストの合計値へ反映させるために初回だけオブジェクトを検索に行く。
        if(player == null) {
            player = GameObject.Find("Player_" + mainCanvas.myNumber).GetComponent<Player>() as Player;
        }
        player.setPlayerSum(sum);
    }

    public void init() {
        sum = 0;
        me.text = "0";
//        FieldValues = new int[17];
        // playerリストの合計値へ反映させるために初回だけオブジェクトを検索に行く。
        if(player == null) {
            player = GameObject.Find("Player_" + mainCanvas.myNumber).GetComponent<Player>() as Player;
        }
        player.setPlayerSum(0);
    }
}
