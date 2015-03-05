using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public class PlayerData {
        public string PlayerName;
        public int[] FieldDates = new int[17];
    }

    public class DecodeData {
        public string dateTime;
        public List<PlayerData> playerDatas = new List<PlayerData>();
        /*
        public int Sheep;
        public int Ass;
        public int Boar;
        public int Cattle;
        public int Dog;
        public int Wheat;
        public int Vegetable;
        public int Ruby;
        public int Dwarf;
        public int Money;
        public int Room;
        public int WereHouse;
        public int BedRoom;
        public int BlankSpace;
        public int Beggar;
        */
    }

    GameObject playerAddButton;
    GameObject playerRemoveButton;
    public List<Player> players = new List<Player>();
    float posY = 212.12f;
    float posYDistance = 26.26f;
    float scaleX = 0.6060606f;
    float scaleY = 0.4385965f;
    Vector3 playerVec;
    // メイン入力画面のx座標増分
    float playerViewCameraDistancePositionX = 82.306f;
    int playerCountMax = 7;
    string SAVEDATA_KEY = "CavernaScorer";

    void Start() {
        playerAddButton    = GameObject.Find("PlayerAddButton");
        playerRemoveButton = GameObject.Find("PlayerRemoveButton");
        players.Clear();
        playerVec = new Vector3();
        playerVec.x = scaleX;
        playerVec.y = scaleY;
        addPlayer(); // 初めの１playerだけ作っておく
    }

    // ボタンから呼ばれる
    public void addPlayerButtonPush() {
        // プレイヤー数がmax未満なら追加できる
        if(players.Count < playerCountMax) {
            addPlayer();
        }
    }

    public void removePlayerButtonPush() {
        // プレイヤー数が1を越えていれば削除できる
        if(players.Count > 1) {
            removePlayer();
        }
    }

    // Player作成
    private void addPlayer() {
        // Playerを作成する
        GameObject PlayerObj = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
        // 名前を「Player(clone)」から「Player_カウント」に変更する
        PlayerObj.name = "Player_" + players.Count;

        Player player = PlayerObj.GetComponent<Player>();
//        Debug.Log("players.count:" + players.Count);
        player.init(players.Count, playerViewCameraDistancePositionX * (players.Count + 1));
        // Listへaddする。
        players.Add(player);

        // Playersの子供にする。
        PlayerObj.transform.parent = this.gameObject.transform;
        // 位置を修正する。Player数に応じてY座標を変更する。
        PlayerObj.transform.localPosition = new Vector3(0.0f, posY - (posYDistance * players.Count), 0.0f);
        PlayerObj.transform.localScale = playerVec;

        // ボタンの位置をPlayer数に応じてずらす。
        moveButtons(PlayerObj.transform.localPosition.y);
    }

    // Player削除
    private void removePlayer() {
        int playersCount = players.Count - 1;
        GameObject PlayerObj = GameObject.Find("Player_" + playersCount);
        Destroy(PlayerObj);
        players.RemoveAt(playersCount);
        GameObject PlayerObjLast = GameObject.Find("Player_" + (playersCount - 1));
        // ボタンの位置をPlayer数に応じてずらす。
        moveButtons(PlayerObjLast.transform.localPosition.y);

        GameObject mainCanvasObj = GameObject.Find("MainCanvas_" + playersCount);
        MainCanvas mainCanvas = mainCanvasObj.GetComponent<MainCanvas>() as MainCanvas;
        mainCanvas.init();
    }

    private void moveButtons(float y) {
        Transform playerAddButtonTran = playerAddButton.transform;
        playerAddButton.transform.localPosition = new Vector3(playerAddButtonTran.localPosition.x, y - posYDistance, playerAddButtonTran.localPosition.z);
        Transform playerRemoveButtonTran = playerRemoveButton.transform;
        playerRemoveButton.transform.localPosition = new Vector3(playerRemoveButtonTran.localPosition.x, y - posYDistance, playerRemoveButtonTran.localPosition.z);
    }

    // データを保存する
    public void save() {
        DecodeData data = new DecodeData();
        // 日付を記録
        DateTime thisDay = DateTime.Now;
        data.dateTime = thisDay.ToString();
        foreach(var player in players) {
            PlayerData playerData = new PlayerData();
            // プレイヤー名を記録
            playerData.PlayerName = player.nameField.value;
            GameObject mainCanvasObj = GameObject.Find("MainCanvas_" + player.number);
            MainCanvas mainCanvas = mainCanvasObj.GetComponent<MainCanvas>() as MainCanvas;
            // MainCanvas内の得点フィールドを取得
            List<InputFieldUpdate> inputFieldUpdates = mainCanvas.inputFieldUpdates;

            // 得点を記録
            foreach(var i in inputFieldUpdates) {
                playerData.FieldDates[i.FieldName] = i.getInputField();
            }
            data.playerDatas.Add(playerData);
        }
        string json = LitJson.JsonMapper.ToJson( data );
//        Debug.Log("json:" + json);
        //データを保存
//        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString(SAVEDATA_KEY, json);
    }

    public void load() {
        string json = PlayerPrefs.GetString(SAVEDATA_KEY);
//        Debug.Log("loadData:" + json);
        DecodeData loadData = LitJson.JsonMapper.ToObject<DecodeData>(json);
        // MainCanvasを全て初期化する
        initMainCanvas();
        // プレイヤー数を初期化する
        initPlayers();
        // TODO 読み込んだデータを画面に反映させる
        int cnt = 0;
        foreach(PlayerData playerData in loadData.playerDatas) {
            if(cnt > 0) {
                // 先に初期化しているのでデフォルトの1件以外の場合はプレイヤーを追加してから処理を行う
                addPlayer();
            }
            Player player = players[cnt];
//            Debug.Log("cnt:" + cnt + " playerData.PlayerName:" + playerData.PlayerName + " players.count:" + players.Count + " player.name:" + player.name);
            InputField nameField = player.transform.FindChild("Name").GetComponent<InputField>() as InputField;
            // プレイヤー名をロード
            nameField.value = playerData.PlayerName;
            GameObject mainCanvasObj = GameObject.Find("MainCanvas_" + cnt);
            MainCanvas mainCanvas = mainCanvasObj.GetComponent<MainCanvas>() as MainCanvas;
            // MainCanvas内の得点フィールドを取得
            List<InputFieldUpdate> inputFieldUpdates = mainCanvas.inputFieldUpdates;

            // 得点を記録
            foreach(var i in inputFieldUpdates) {
                i.setInputField(playerData.FieldDates[i.FieldName]);
            }

            // 得点を入れただけでは合計値が計算されないので再計算
            GameObject sumObject = mainCanvasObj.transform.FindChild("Summary").FindChild("Total").FindChild("SumField").gameObject;
            SumField sumField = sumObject.GetComponent<SumField>() as SumField;
            sumField.CalcSum();

            Text playerSumText = player.transform.FindChild("PlayerSum").GetComponent<Text>() as Text;
            playerSumText.text = sumField.sum.ToString();

            cnt++;
        }
    }

    // MainCanvasを全て初期化する
    private void initMainCanvas() {
        for(int cnt = 0; cnt < (players.Count); cnt++) {
//            Debug.Log("initMainCanvas count:" + cnt);
            GameObject mainCanvasObj = GameObject.Find("MainCanvas_" + cnt);
            MainCanvas mainCanvas = mainCanvasObj.GetComponent<MainCanvas>() as MainCanvas;
            mainCanvas.init();
        }
    }

    // プレイヤー数1件の状態にする
    private void initPlayers() {
        for(; players.Count > 1;) {
            removePlayer();
        }
    }
}
