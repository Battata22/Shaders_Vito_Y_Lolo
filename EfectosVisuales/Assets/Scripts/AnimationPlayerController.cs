using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
    }

    // Update is called once per frame
    void Update()
    {
        //variables de bool del animator
        bool isWalking = animator.GetBool("IsWalking");
        bool isJumping = animator.GetBool("IsJumping");
        bool isIdle = animator.GetBool("IsIdle");

        //variables de inputs
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool backPressed = Input.GetKey("s");
        bool rightPressed = Input.GetKey("d");
        bool jumpKey = Input.GetKeyDown(KeyCode.Space);
        


        //Anim de Movimiento
        if (!isWalking && forwardPressed || leftPressed || backPressed || rightPressed)
        {
            animator.SetBool(isWalkingHash,true);
        }
        if (isWalking && !forwardPressed || !leftPressed || !backPressed || !rightPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        //Anim de salto
        if (!isJumping && jumpKey)
        {
            animator.SetBool("IsJumping", true);
        }
        if (isJumping && !jumpKey)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
