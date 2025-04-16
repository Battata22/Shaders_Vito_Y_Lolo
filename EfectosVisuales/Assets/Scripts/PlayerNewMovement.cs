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
    [SerializeField] private float _gravedad = 9.8f;
    private float _velocity;
    public float gravityMulti = 3.0f;
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
        //moveDirection.y = 0;
        _cc.Move(moveDirection * Time.deltaTime * _moveSpeed);
        transform.rotation = camara.orientation.rotation;
    }
    void Gravedad()
    {
        //_gravedad = 0f;
        _cc.Move(Vector3.down * _gravedad * Time.deltaTime);
        /*
        if (_cc.isGrounded)
        {
            
        }
        else
        {
            
        }
        
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        if (_cc.isGrounded)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravedad * gravityMulti * Time.deltaTime;        
        }
        moveDirection.y = _velocity;
        
        if (!_cc.isGrounded)
        {
            //_timeInAir = Time.time - _startTime;
            //gravityMulti = _timeInAir;
            

        }
        else if (_cc.isGrounded)
        {
            // _timeInAir = Time.time * 0f;
            //gravityMulti = _timeInAir;
        }
        */
        //_cc.Move(Vector3.down * gravityMulti * _gravedad * Time.deltaTime);
    }
    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && _cc.isGrounded)
        {
            print("salte");
            Jump();
        }
    }
    private void Jump()
    {
        float verticalF = Mathf.Sqrt(2 * 9.8f * jumpHeight); // Salto de 3 unidades de altura
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
