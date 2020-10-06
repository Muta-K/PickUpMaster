using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;

    private const string _isRun = "isRun";
    private const string _isWalkBack = "isWalkBack";
    private const string _isLeft = "isLeftRun";
    private const string _isRight = "isRightRun";
    private const string _isPick = "isPick";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            // WaitからRunに遷移する
            this.animator.SetBool(_isRun, true);
        }
        else
        {
            // RunからWaitに遷移する
            this.animator.SetBool(_isRun, false);
        }

        if (Input.GetKey("down"))
        {
            // WaitからWalkBackに遷移する
            this.animator.SetBool(_isWalkBack, true);
        }
        else
        {
            this.animator.SetBool(_isWalkBack, false);
        }

        if (Input.GetKey("left"))
        {
            // WaitからWalkBackに遷移する
            this.animator.SetBool(_isLeft, true);
        }
        else
        {
            this.animator.SetBool(_isLeft, false);
        }

        if (Input.GetKey("right"))
        {
            // WaitからWalkBackに遷移する
            this.animator.SetBool(_isRight, true);
        }
        else
        {
            this.animator.SetBool(_isRight, false);
        }

    }

    public void DoPickUpAnimation()
    {
        //PickUpアニメーションの実行
        this.animator.SetBool(_isPick, true);
        //1秒後にアニメーション終了
        StartCoroutine(PickUpAnimationFalse());
    }

    public IEnumerator PickUpAnimationFalse()
    {
        //1秒間待機
        yield return new WaitForSeconds(1);
        //isPickUpをFalseにする
        this.animator.SetBool(_isPick, false);
    }
}
