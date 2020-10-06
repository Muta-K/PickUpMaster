using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PowerMeterController : MonoBehaviour
{
    //powerMeterオブジェクトへの参照
    [SerializeField] private GameObject _PowerMeterObject;
    //スライダーの速さ
    [SerializeField] private float _MeterSpeed = 0.2f;
    //PlayerのObject
    [SerializeField] private GameObject _PlayerObject;
    //距離表示をしている3Dテキスト
    //[SerializeField] private GameObject _DistanceText;
    //スタートラインオブジェクトの参照
    [SerializeField] private GameObject _StartLineObject;
    //Playerの移動距離を表示するテキスト
    [SerializeField] private Text _PlayerDistanceText;
    //メッセージテキスト
    [SerializeField] private Text _MessageText;
    //メッセージテキストのパネル
    [SerializeField] private GameObject _MessagePanel;
    //Playerステータスを表示するテキスト
    [SerializeField] private Text _PlayerStatusText;
    //ゲームを終了するボタン
    [SerializeField] private GameObject _GameFinishButton;

    //アニメーション動作の待機時間
    public float _AnimationWaitTime = 1.4f;
    //Attack調整
    public float _AttackAjust = 0.1f;
    //Speed調整
    public float _SpeedAjust = 0.01f;

    //DistanceTextのTransform
    private Transform _DistanceTextTransform;
    //DistanceTextのText
    private TextMesh _DistanceTextMesh;
    //PlayerのRigidBody
    private Rigidbody _PlayerRb;
    //Playerの位置
    private Transform _PlayerTransform;
    //加える力の大きさ
    private float _ForceMagnitude = 0f;
    //力を加える向き
    Vector3 _ForceDirection;
    //スライダーコンポーネントへの参照
    Slider _PowerMeterSlider;
    //スタートラインの位置
    private Transform _StartLineTransform;
    //距離の格納用変数
    private Vector3 _JumpTransform;
    //距離の格納用変数(Float)
    private float _JumpDistance;
    //メーターが増加中か減少中か（trueで増加）
    bool _isMeterIncreasing = true;
    //Spaceを押したらメーターが止まる
    bool _isMeterStop = false;
    //Playerが止まっているかフラグ
    private bool _isPlayerStop = false;
    //Playerが飛んだかフラグ
    private bool _isBallMoving = false;
    //拾ったアイテムデータが格納されているオブジェクト
    private GameObject _PlayerStatuDataObject;
    //Playerのステータスを格納する変数
    private Itemdata _PlayerStatus;
    //PlayerのAttackステータスを格納する変数
    private float _PlayerAttackStatus;
    //PlayerのSpeedステータスを格納する変数
    private float _PlayerSpeedStatus;
    //Itemdataオブジェクトを消すために参照
    private GameObject _ItemdataObject;
    //PlayerStatusDataオブジェクトを消すために参照
    private GameObject _PlayerStatusDataObject;



    void Start()
    {
        _PlayerStatuDataObject = GameObject.Find("PlayerStatusData");
        _ItemdataObject = GameObject.Find("Itemdata");
        _PlayerStatusDataObject = GameObject.Find("PlayerStatusData");

        _PowerMeterSlider = _PowerMeterObject.GetComponent<Slider>();
        _ForceDirection = new Vector3(0, 1.0f, 1.0f);
        _PlayerRb = _PlayerObject.GetComponent<Rigidbody>();
        _PlayerTransform = _PlayerObject.GetComponent<Transform>();
        _StartLineTransform = _StartLineObject.GetComponent<Transform>();
        //メーターを生成
        //CreateDistanceText();
        //メッセージを空にする
        _MessageText.text = string.Empty;
        //メッセージテキスト用のパネルの非表示
        _MessagePanel.SetActive(false);
        //拾ったアイテムのステータスを取得する
        SetPlayerStatus();
        //ステータスを表示する
        DisplayPlayerStatus(_PlayerAttackStatus, _PlayerSpeedStatus);
        //ゲーム終了ボタンの無効化
        _GameFinishButton.SetActive(false);


    }

    void Update()
    {
        //メータを動かす
        MovePowerMeter();
        //playerがjumpする
        //isMeterStopがtrueなら抜ける
        StartCoroutine(PlayerJumping());
        if (_isBallMoving)
        {
            //playerの距離を測る
            GetDistance();
        } 
        //結果を出力し、ゲームを終わる
        GameResult();
    }

    private void SetPlayerStatus()
    {
        //PlayerStatusDataからPlayerStatu(Itemdataクラス)の情報を取得
        _PlayerStatus = _PlayerStatuDataObject.GetComponent<PlayerStatusData>().GetPlayerStatus();
        //_PlayerStatusからAttackを取り出す
        _PlayerAttackStatus = _PlayerStatus.Attack * _AttackAjust;
        if(_PlayerAttackStatus <= 0)
        {
            _PlayerAttackStatus = 1;
        }
        //_PlayerStatusからSpeedを取り出す
        _PlayerSpeedStatus = _PlayerStatus.Speed * _SpeedAjust * - 1;

    }

    private IEnumerator PlayerJumping()
    {
        if (!_isBallMoving)
        {
            if (!_isMeterStop)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    //Spaceを押したらメーターを止める
                    _isMeterStop = true;
                    //アニメーションをする為まつ
                    yield return new WaitForSeconds(_AnimationWaitTime);
                    //ボールが動いているフラグ
                    _isBallMoving = true;
                    //_ForceDirectionの方角へ、
                    //初期値の力(_ForceMagnitude)とアイテムで取得したステータスを足したものを加える
                    Vector3 force = _ForceDirection * (_ForceMagnitude + _PlayerAttackStatus);
                    _PlayerRb.AddForce(force, ForceMode.Impulse);

                }
            }
        }
    }

    private void MovePowerMeter()
    {
        //isMeterStopがtrueなら抜ける
        if (_isMeterStop)
        {
            return;
        }

        //SilderのValueが最大もしくは最小になったらフラグ反転
        if (_ForceMagnitude >= _PowerMeterSlider.maxValue)
        {
            _isMeterIncreasing = !_isMeterIncreasing;
        }
        else if (_ForceMagnitude <= _PowerMeterSlider.minValue)
        {
            _isMeterIncreasing = !_isMeterIncreasing;
        }

        //trueならメーター増加、falseなら減少
        //PlayerStatusのSpeedパラメータ(_PlayerSpeedStatus)でメーターのスピードに変化
        if (_isMeterIncreasing)
        {
            _PowerMeterSlider.value += _MeterSpeed + _PlayerSpeedStatus;
        }
        else
        {
            _PowerMeterSlider.value -= _MeterSpeed + _PlayerSpeedStatus;
        }
        //SliderのValueを打ち出す力にする
        _ForceMagnitude = _PowerMeterSlider.value;
    }

    private void WaitAtBoundaryValue()
    {
        //SilderのValueが最大もしくは最小になったらフラグ反転
        if(_ForceMagnitude >= _PowerMeterSlider.maxValue)
        {
            _isMeterIncreasing = !_isMeterIncreasing;
        }
        else if(_ForceMagnitude <= _PowerMeterSlider.minValue)
        {
            _isMeterIncreasing = !_isMeterIncreasing;
        }

    }

    private void GetDistance()
    {
        
        _JumpDistance = Vector3.Distance(_PlayerTransform.position, _StartLineTransform.position);

        _PlayerDistanceText.text = _JumpDistance.ToString("F2") + "m";

    }

    private void GameResult()
    {
        if (!_isBallMoving)
        {
            return;
        }
        if (!_PlayerRb.IsSleeping())
        {
            return;
        }
        if (_isPlayerStop)
        {
            return;
        }
        
        //Playeが止まったフラグ
        _isPlayerStop = true;

        //メッセージテキスト用のパネルの表示
        _MessagePanel.SetActive(true);
        _MessageText.text = "結果は... " + _JumpDistance.ToString("F2") + "m!!";

        //ゲーム終了ボタンの有効化
        _GameFinishButton.SetActive(true);

    }

    private void DisplayPlayerStatus(float atk,float spd)
    {
        string attack = Convert.ToString(atk);
        string speed = Convert.ToString(spd);
        _PlayerStatusText.text = "力は　　" + attack + "\n";
        _PlayerStatusText.text += "速さは　" + speed; 
    }

    public void OnClickGameFinish()
    {
        //ItemdataとPlayerStatusDataの削除
        Destroy(_ItemdataObject);
        Destroy(_PlayerStatusDataObject);

        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }


}

