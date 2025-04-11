using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewMovement : MonoBehaviour
{
    private CharacterController _cc;
    [SerializeField] PlayerCam camara;

    //Inputs
    float _horizontalInput;
    float _verticalInput;

    //Keybinds
    [Header("Keybinds")]
    //[SerializeField] public KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] public KeyCode jumpKey = KeyCode.Space;

    //Variables de velocidad
    [SerializeField] private float _moveSpeed;
    //public float walkspeed;
    //public float sprintSpeed;

    Vector3 moveDirection;

    //Variables de salto
    public float jumpHeight;
    public float jumpTime;

    //public float jumpCooldown;
    //bool readyToJump = true;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        MyInput();
        Move();
        Gravedad();
    }
    void Move()
    {
        Vector3 moveDirection = (transform.right * _horizontalInput + transform.forward * _verticalInput).normalized;
        moveDirection.y = 0;
        _cc.Move(moveDirection * Time.deltaTime * _moveSpeed);
        transform.rotation = camara.orientation.rotation;
    }
    void Gravedad()
    {
        _cc.Move(Vector3.down * 9.8f * Time.deltaTime);
    }
    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && _cc.isGrounded)
        {
            //readyToJump = false;
            print("salte");
            Jump();

            //Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void Jump()
    {
        float verticalF = Mathf.Sqrt(2 * 9.8f * jumpHeight); // Salto de 3 unidades de altura
        //_cc.Move(new Vector3(0, verticalF,0));
        StartCoroutine(JumpTime(new Vector3(0, verticalF, 0)));
        
    }
    IEnumerator JumpTime(Vector3 force)
    {
        var startJump = Time.time;
        while (Time.time < startJump + jumpTime)
        {
            _cc.Move(force/jumpTime * Time.deltaTime);
            yield return null; 
        }      
    }
    //private void ResetJump()
    //{
    //    //readyToJump = true;
    //    //_exitRampa = false;
    //}
}
