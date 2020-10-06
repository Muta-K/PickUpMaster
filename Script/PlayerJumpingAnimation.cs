using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingAnimation : MonoBehaviour
{
    private Animator animator;

    private const string _isJump = "isJump";


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.animator.SetBool(_isJump, true);
        }
        
    }
}
