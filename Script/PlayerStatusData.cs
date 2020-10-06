using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatusData : MonoBehaviour
{
    public static Itemdata _PlayerStatus;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        //シーンのロード時にSceneLoadedを実行
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        //読み込んだシーンがPickUpSceneなら_PlayerStatus初期化
        //(BallKickScene時に実行するとデータが初期化してしまうため)
        if (nextScene.name == "PickUpScene")
        {
            _PlayerStatus = new Itemdata();
        }
    }

    public void SetPlayerStatus(Itemdata getItemdata)
    {
        //Attackにデータを格納
        _PlayerStatus.Attack += getItemdata.Attack;
        //Speedにデータを格納
        _PlayerStatus.Speed += getItemdata.Speed;
    }
    
    public Itemdata GetPlayerStatus()
    {
        return _PlayerStatus;
    }

}
