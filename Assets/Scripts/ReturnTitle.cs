using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReturnTitle : MonoBehaviour {

    // メインカメラの位置情報
    Transform mainCamera;
    // メインカメラを移動する座標
    Vector3 targetPosition;
    // 中間を取る滑らかさ
    float speed = 12.0f;
    public bool GoTitleView{ set; get; }
    float titleViewCameraPositionX = 0.0f;
    PlayerManager playerManager;

    void Start() {
        mainCamera = GameObject.FindWithTag("MainCamera").transform; //カメラトランスフォームの参照を渡す
        GoTitleView = false;
        targetPosition = new Vector3(titleViewCameraPositionX, 0.0f, -10.0f);
    }

    void Update() {
        if(GoTitleView) {
            Vector3 cameraposition = mainCamera.position;
            mainCamera.position = Vector3.Lerp(cameraposition, targetPosition, speed * Time.deltaTime);
            // Lerpはピッタリ同じ位置まで持ってきてくれないので近づいたら合わせる
            if((mainCamera.position.x - 1.0f) < titleViewCameraPositionX) {
                cameraposition.x = titleViewCameraPositionX;
                mainCamera.position = cameraposition;
            }
            if(mainCamera.position.x == targetPosition.x) {
                GoTitleView = false;
            }
        }
    }

    public void onClickReturnTitle() {
        if(playerManager == null) {
            playerManager = GameObject.Find("Players").gameObject.GetComponent<PlayerManager>();
            List<Player> players = playerManager.players;
            for(int cnt = 0; cnt < players.Count; cnt++) {
                Player player = players[cnt];
//                Debug.Log("player.name:" + player.name + " GoMainView:" + player.GoMainView);
                if(player.GoMainView) {
                    player.GoMainView = false;
                }
            }
        }
        ReturnTitle returnTitle = GameObject.Find("ReturnTitleButton").gameObject.GetComponent<ReturnTitle>();
        returnTitle.GoTitleView = true;
    }
}
