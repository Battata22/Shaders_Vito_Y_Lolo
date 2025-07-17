using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    float xAxis, yAxis;

    [SerializeField] CharacterController _cc;
    void Start()
    {
        _cc = EntityManager.instance.player.GetComponent<PlayerNewMovement>()._cc;
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");

        Input.GetKeyDown(KeyCode.Space);
        
    }
    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        //Anim de Movimiento
        if (xAxis != 0 || yAxis != 0)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
        //Anim de salto
        if (_cc.isGrounded && animator.GetBool("IsJumping"))
        {
            animator.SetBool("IsJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        
    }
}
