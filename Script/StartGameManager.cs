using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    //[SerializeField] private GameObject _Itemdata;

    private GameObject _Itemdata;
    private int _PlayCount;


    void Start()
    {
        _Itemdata = default;
        //シーンのロード時にSceneLoadedを実行
        SceneManager.sceneLoaded += SceneLoaded;

        _Itemdata = GameObject.Find("Itemdata");

    }

    
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        //読み込んだシーンがLoadSceneならGetJsonWebRequest()の実行
        if (nextScene.name == "PickUpScene")
        {
            _Itemdata.GetComponent<Itemdata>().GetJsonWebRequest();
        }
    }
    

    public void OnClickGameStartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PickUpScene");

    }
}
