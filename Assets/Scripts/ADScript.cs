using UnityEngine;
using System.Collections;

public class ADScript : MonoBehaviour {

    private AppCCloud appCCloud;

    void Awake()
    {
        // 仕様するAPIを各種設定してください
        appCCloud = new AppCCloud().SetMK_iOS("mediaKey")
            .On(AppCCloud.API.Data)
//            .On(AppCCloud.API.Gamers)
//            .On(AppCCloud.API.Purchase)
            .On(AppCCloud.API.Push)
            .On(AppCCloud.API.Reward)
            .Start();
        // シンプル表示
//        appCCloud.Ad.ShowSimpleView(AppCCloud.Vertical.Top);
        appCCloud.Ad.ShowSimpleView(AppCCloud.Vertical.Bottom);
    }
    private void Hide()
    {    
        // 非表示
        appCCloud.Ad.HideSimpleView();
    }
}
