using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    public float moveSpeed = 5f;

    float _horizontalInput;
    float _verticalInput;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    public float groundDrag;
    [SerializeField] public KeyCode jumpKey = KeyCode.Space;

    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }
    private void Update()
    {
        MyInput();
        SpeedControl();
        //ground checking
        grounded = Physics.Raycast(transform.position + new Vector3(0,0.1f,0), Vector3.down, 0.3f, whatIsGround);
        if (grounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }
    }
    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            print("entre a jump");
            readyToJump = false;

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void Movement()
    {
        Vector3 moveDirection;
        
        moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
        if (grounded)
        {
            _rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }
        else if (!grounded)
        {
            _rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
        }
        
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}