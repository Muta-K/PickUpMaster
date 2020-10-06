using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Itemdata : MonoBehaviour
{
    public int Id { set; get; }
    public string Itemname { set; get; }
    public int Attack { set; get; }
    public int Speed { set; get; }

    

    public List<Itemdata> _ItemData = null;
    private Itemdata _OneItem;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
    }

    public Itemdata()
    {
        Itemname = "";
        Attack = 0;
        Speed = 0;
    }


    
    /// <summary>
    /// ItemIdを引数に渡し該当のアイテム情報をItemdataクラスで返す
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public Itemdata GetItemData(int itemId)
    {
        _OneItem = new Itemdata();
        //IdがitemIdのものをラムダ式で検索し抽出
        _OneItem = _ItemData.Find(x => x.Id == itemId);

        return _OneItem;
    }
    public void GetJsonWebRequest()
    {
        StartCoroutine(DownloadJson(CallbackWebRequestSuccess, CallbackWebRequestFailed));
    }
    private IEnumerator DownloadJson(Action<string> cbkSuccess = null, Action cbkFailed = null)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/PickUpMaster/pickupmaster/getItemlist");
        yield return www.SendWebRequest();


        if (www.error != null)
        {
            //レスポンスエラーの場合
            Debug.LogError(www.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else if (www.isDone)
        {
            // リクエスト成功の場合
            Debug.Log($"Success:{www.downloadHandler.text}");
            if (null != cbkSuccess)
            {
                cbkSuccess(www.downloadHandler.text);
            }
        }
    }
    private void CallbackWebRequestSuccess(string response)
    {
        //Json の内容を MemberData型のリストとしてデコードする。
        _ItemData = ItemDataModel.DeserializeFromJson(response);

        Debug.Log("Success!");
    }
    private void CallbackWebRequestFailed()
    {
        Debug.Log("WebRequest Failed");
    }
}
