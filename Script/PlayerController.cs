using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    


    public float speed = 500.0f;
    public int _PickUpCountMax = 5;


    //アイテム情報(Itemdataクラス)を一時保存するための変数
    private Itemdata _itemDatatemp = default;
    //Itemdataオブジェクトを格納する変数
    private GameObject _Itemdata = default;
    private GameObject _GameManagerObject = default;
    private GameObject _PlayerStatuDataObject = default;
    private int _ItemId;
    private bool _PickingUp = false;
    private int _PickUpCount = 0;
    




    public void Start()
    {
        //Itemdataオブジェクトの検索
        _Itemdata = GameObject.Find("Itemdata");
        _GameManagerObject = GameObject.Find("GameManager");
        _PlayerStatuDataObject = GameObject.Find("PlayerStatusData");

        //カウントした数字を表示
        _GameManagerObject.GetComponent<GameManager>().DisplayPickUpCount(_PickUpCount);

    }
    public void Update()
    {
        PickUpMaximum();

        if (!_PickingUp)
        {
            if (Input.GetKey("up"))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("right"))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("left"))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("down"))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        

    }

    public void OnTriggerStay(Collider other)
    {
        //OnTriggerしたColliderのgameobjectを実体化
        GameObject enterObject = other.gameObject;
        //OnTriggerしたgameobjectのタグがFoodなら
        if (enterObject.CompareTag("Food"))
　      {
            //スペースキーを押したら
            if (Input.GetKey((KeyCode.Space)))
            {
                //ピックモーション中は操作できない
                StartCoroutine(PikkingUp());

                //範囲内にあるFoodアイテムのID情報を取得
                _ItemId = enterObject.GetComponent<ItemInfo>().GetItemId();

                _itemDatatemp = new Itemdata();
                //ItemdataオブジェクトのItemdataスクリプト内のGetItemData()を実行し、
                //_itemIdに応じたアイテム情報(Itemdataクラス)を取得
                _itemDatatemp = _Itemdata.GetComponent<Itemdata>().GetItemData(_ItemId);
                //アイテム名を画面に表示
                _GameManagerObject.GetComponent<GameManager>().DisplayItemInfo(_itemDatatemp.Itemname, enterObject);

                //範囲内にあるFoodアイテムの削除
                enterObject.GetComponent<ItemInfo>().DestoryItem();

                //拾ったアイテムのステータスをplayerstatudataに格納
                _PlayerStatuDataObject.GetComponent<PlayerStatusData>().SetPlayerStatus(_itemDatatemp);

                //Space押したときにアニメーション
                this.GetComponent<PlayerAnimation>().DoPickUpAnimation();

                //拾った数をカウント
                _PickUpCount++;
                //カウントした数字を表示
                _GameManagerObject.GetComponent<GameManager>().DisplayPickUpCount(_PickUpCount);
            }
        }

    }

    //Pickingアニメーション中に操作できないようにする
    private IEnumerator PikkingUp()
    {
        _PickingUp = true;
        yield  return new WaitForSeconds(1);
        _PickingUp = false;
    }

    private void PickUpMaximum()
    {
        if(_PickUpCount >= _PickUpCountMax)
        {
            //操作を停止する
            _PickingUp = true;
            _GameManagerObject.GetComponent<GameManager>().MoveToJumpingScene();

        }

    }



}
