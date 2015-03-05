using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    // 何番目のプレイヤーか？
    public int number;
    // メイン画面の座標（今のところ使っていないので不要なら消す。戻るときに使うかも）
//    Vector3 mainViewVec = new Vector3(82.306f, 0.0f, 0.0f);
    // メインカメラの位置情報
    Transform mainCamera;
    // メインカメラを移動する座標
    Vector3 targetPosition;
    // 中間を取る滑らかさ（横スクロール速度）
    float speed = 12.0f;
    // メイン入力画面へのスクロール中か？（ボタンが押された瞬間にtrueとなる）
    public bool GoMainView{ set; get; }
    // メイン入力画面のx座標
    float playerViewCameraPositionX;
    Text playerSumText;
    public InputField nameField { set; get; }
    public int playerSum = 0;
    Text mainCanvasPlayerName;
//    string textToEdit = "";

    void Start() {
        mainCamera = GameObject.FindWithTag("MainCamera").transform; //カメラトランスフォームの参照を渡す
        GoMainView = false;
//        init(1, 82.0f);
        playerSumText = this.transform.FindChild("PlayerSum").GetComponent<Text>() as Text;
        nameField = this.transform.FindChild("Name").GetComponent<InputField>() as InputField;
    }
/*
    void OnGUI() {
        Debug.Log("x:" + this.transform.position.x + " y:" + this.transform.position.y);
        // テキストフィールドを表示する
        textToEdit = GUI.TextField(new Rect(this.transform.position.x, this.transform.position.y, 120, 20), textToEdit, 16);
    }
*/
    // プレイヤーが生成された時にプレイヤー数に応じて初期化される
    public void init(int _number, float positionX) {
        this.number = _number;
//        playerViewCameraPositionX = 82.0f;
        playerViewCameraPositionX = positionX;
        targetPosition = new Vector3(playerViewCameraPositionX, 0.0f, -10.0f);
    }

    void Update() {
        if(GoMainView) {
//            Debug.Log("targetPosition:" + targetPosition);
            Vector3 cameraposition = mainCamera.position;
            mainCamera.position = Vector3.Lerp(cameraposition, targetPosition, speed * Time.deltaTime);
            // Lerpはピッタリ同じ位置まで持ってきてくれないので近づいたら合わせる
            if((mainCamera.position.x + 1.0f) > playerViewCameraPositionX) {
                cameraposition.x = playerViewCameraPositionX;
                mainCamera.position = cameraposition;
            }
        }
        if(mainCamera.position.x == targetPosition.x) {
            GoMainView = false;
        }
    }

    public void onClickPlayer() {
//        Debug.Log("Player::onClickPlayer");
// TODO ここで何番目のPlayerか与えないと・・
//        Player player = GameObject.Find("Player").gameObject.GetComponent<Player>();
//        player.GoMainView = true;
        // プレイヤー名をメイン側に反映
        setPlayerName();
        GoMainView = true;
    }

    public void setPlayerSum(int value) {
        playerSum = value;
        if(playerSumText == null) {
//            Debug.Log("playerSumText is null");
            playerSumText = this.transform.FindChild("PlayerSum").GetComponent<Text>() as Text;
        }
        playerSumText.text = value.ToString();
//        Debug.Log("playerSumText text:" + playerSumText.text);
    }

    private void setPlayerName() {
        // プレイヤー名をメイン側に反映させるために初回だけオブジェクトを検索に行く。
        if(mainCanvasPlayerName == null) {
            GameObject mainCanvas = GameObject.Find("MainCanvas_" + this.number);
            Transform namePlate = mainCanvas.transform.FindChild("NamePlate");
            mainCanvasPlayerName = namePlate.FindChild("Name").GetComponent<Text>() as Text;
        }
        mainCanvasPlayerName.text = nameField.value;
    }
}
