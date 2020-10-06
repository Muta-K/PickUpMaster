using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Text _MessateText;
    [SerializeField] private GameObject _UnityChan;
    [SerializeField] private Text _ItemInfoText;
    [SerializeField] private Transform _UIItemObjectPosition;
    [SerializeField] private Text _PickUpCountText;

    private PlayerController _PlayerController;
    private PlayerAnimation _PlayerAnimation;

    public void Start()
    {
        //UnityChanにアタッチしているPlayerControllerスクリプトの取得
        _PlayerController = _UnityChan.GetComponent<PlayerController>();
        //UnityChanにアタッチしているPlayerAnimationスクリプトの取得
        _PlayerAnimation = _UnityChan.GetComponent<PlayerAnimation>();
        //ゲーム開始の処理
        StartCoroutine(GameStart());
        
    }

    private IEnumerator GameStart()
    {
        yield return StartCoroutine(PickRedy());
        yield return StartCoroutine(PickStarting());
        yield return StartCoroutine(PickStart());
        
    }

    private IEnumerator PickRedy()
    {
        //Playerの操作ができないようにする
        DisablePlayerControl();

        _MessateText.text = "よーい...";

        yield return new WaitForSeconds(2);
    }
    private IEnumerator PickStarting()
    {
        _MessateText.text = "すたーと！！";

        yield return new WaitForSeconds(1);
    }
    private IEnumerator PickStart()
    {
        //playerが操作できるようになる
        EnablePlayerControl();

        _MessateText.text = string.Empty;

        yield return new WaitForSeconds(1);
    }


    public void OnClickGameStartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PickUpScene");

    }

    private void DisablePlayerControl()
    {
        _PlayerController.enabled = false;
        _PlayerAnimation.enabled = false;
    }
    private void EnablePlayerControl()
    {
        _PlayerController.enabled = true;
        _PlayerAnimation.enabled = true;
    }

    public void DisplayItemInfo(string itemName,GameObject PickedUpItemObject)
    {
        
        //_UIItemObjectにあるObject(つまりItemObject）を削除
        foreach (Transform Item in _UIItemObjectPosition)
        {
            Destroy(Item.gameObject);
        }
        
        //アイテム名を画面左上に表示
        _ItemInfoText.text = itemName;
        //オブジェクトのレイヤを9(UI 3D Object)に変更
        PickedUpItemObject.layer = 9;
        //アイテムオブジェクトを画面左上に表示
        GameObject UIItem = Instantiate(PickedUpItemObject, _UIItemObjectPosition.position, _UIItemObjectPosition.rotation);
        //UIItemを_UIItemObjectPositionの子オブジェクトとして配置
        UIItem.transform.parent = _UIItemObjectPosition;
    }
    public void DisplayPickUpCount(int count)
    {
        //拾ったアイテムの数を表示
        _PickUpCountText.text = count + "個拾ったよ";
    }

    public void MoveToJumpingScene()
    {
        _MessateText.text = "そこまで！！";
        StartCoroutine(MoveToJumpingMode());
    }

    private IEnumerator MoveToJumpingMode()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("BallKickScene");

    }

}
