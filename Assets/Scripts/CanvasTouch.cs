using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasTouch : MonoBehaviour {

    // メニューが見えているか
    bool visibleMenu = true;
    // パネルがタップされている最中か
    bool panelPussing = false;
    // パネルがタッチされた時のワールド座標
    Vector2 downPointWorldSpace;
    // パネルがタッチされた時の時間
//    System.DateTime touchedTime;
    // パネルがタッチされた時のX座標
    float tapPointX;
    // スライド判定のX座標
    public float tapPointDetectionX;
    // ドラッグ判定の許容時間
//    float hogeTime = 0.0f;
    GameObject menuPanel;
    Menu menu;

    void Start () {
        menuPanel = GameObject.Find("Menu").gameObject;
        menu = menuPanel.GetComponent<Menu>();
	}
	
    void Update() {
        // Canvasが押された時の処理
        if(Input.GetMouseButtonDown(0)) {
//            panelPussing = true;
            Vector3 buff = new Vector3(Input.mousePosition.x, Input.mousePosition.y, System.Math.Abs(Camera.main.transform.position.z));
            // スクリーン座標からカメラのワールド座標に反映
            downPointWorldSpace = Camera.main.ScreenToWorldPoint(buff);
            Collider2D collider2d = Physics2D.OverlapPoint(downPointWorldSpace);
            if(collider2d) {
                GameObject obj = collider2d.transform.gameObject;
                // 自分自身の場合のみ認識する
                if(obj.name == this.name) {
                    panelPussing = true;
                    // パネルがタッチされた時の時間を一時保存しておく
//                    touchedTime = System.DateTime.Now;
                    tapPointX = Input.mousePosition.x;
                }
            }
        }
        // Canvasが離された時の処理
        if(Input.GetMouseButtonUp(0)) {
            float tmpTapPointX = tapPointX - Input.mousePosition.x;
            if((System.Math.Abs(tmpTapPointX) - tapPointDetectionX) > 0.0f) {
                // 押した位置-離された位置がプラスの場合は離された位置の方が小さいので左スライド
                if(visibleMenu && tmpTapPointX > 0.0f) {
//                    Debug.Log("Menu disable tapPointX:" + tapPointX + " Input.mousePosition.x:" + Input.mousePosition.x);
                    menu.setMenuStatus(0);
                    moveMenu(false);
//                    StartCoroutine("moveMenu", false);
                    visibleMenu = false;
                // 押した位置-離された位置がマイナスの場合は離された位置の方が大きいので右スライド
                } else if(!visibleMenu && tmpTapPointX < 0.0f) {
//                    Debug.Log("Menu visable tapPointX:" + tapPointX + " Input.mousePosition.x:" + Input.mousePosition.x);
                    menu.setMenuStatus(1);
                    moveMenu(true);
//                    StartCoroutine("moveMenu", true);
                    visibleMenu = true;
                }
            }
        }
        // 押されている間
        if(panelPussing) {
//            Debug.Log("Input.mousePosition.x:" + Input.mousePosition.x);
        }
	}

    void moveMenu(bool visible) {
        Transform t = menuPanel.transform;
        float distance = 1.0f;
        float distanceLimit = 40.0f;
        float newPositionX = t.position.x;

        for(;System.Math.Abs(newPositionX) < distanceLimit;) {
            if (visible) {
                newPositionX += distance;
            } else {
                newPositionX -= distance;
            }

            Vector3 v = new Vector3(newPositionX, t.position.y, t.position.z);
            menuPanel.transform.position = v;
        }
    }

}
