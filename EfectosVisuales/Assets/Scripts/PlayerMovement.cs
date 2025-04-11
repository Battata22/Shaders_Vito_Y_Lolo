using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    //Inputs
    float _horizontalInput;
    float _verticalInput;

    //Keybinds
    [Header("Keybinds")]
    [SerializeField] public KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] public KeyCode jumpKey = KeyCode.Space;

    //Variables de velocidad
    [SerializeField] private float _moveSpeed;
    public float walkspeed;
    public float sprintSpeed;
    Vector3 moveDirection;

    //Variables de salto
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    //GroundChecker
    [Header("GroundCheck")]
    //public float playerHeight;
    public float groundDrag;
    public LayerMask whatIsGround;
    bool grounded;

    //Para rampas y piso con distintos angulos
    [Header("Rampas")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool _exitRampa; //al saltar en la rampa

    public Transform orientation;
    //Preguntando los estados del jugador)
    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        air
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }
    private void Update()
    {
        MyInput();
        SpeedControl();
        StateHandler();
        OnSlope();
        //ground checking
        grounded = Physics.Raycast(transform.position + new Vector3(0,0.1f,0), Vector3.down, 0.3f, whatIsGround);
        //if (grounded)
        //{
        //    _rb.drag = grounddrag;
        //}

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
        moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
        //en rampa
        if (OnSlope() && !_exitRampa)
        {
            _rb.AddForce(GetSlopeMoveDirection() * _moveSpeed, ForceMode.Force);
            if (_rb.velocity.y > 0)
            {
                _rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }
        // en el piso
        if (grounded)
        {
            _rb.AddForce(moveDirection.normalized * _moveSpeed, ForceMode.Force);
        }
        //en el aire
        else if (!grounded)
        {
            _rb.AddForce(moveDirection.normalized * _moveSpeed * airMultiplier, ForceMode.Force);
        }
        _rb.useGravity = !OnSlope();
        
    }
    private void StateHandler()
    {
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            _moveSpeed = sprintSpeed;
        }
        else if (grounded)
        {
            state = MovementState.walking;
            _moveSpeed = walkspeed;
        }
        else
        {
            state = MovementState.air;
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void SpeedControl()
    {
        //en rampas
        if (OnSlope() && !_exitRampa)
        {
            if (_rb.velocity.magnitude > _moveSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * _moveSpeed;
            }
        }
        //en ground
        else
        {
            Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (flatVel.magnitude > _moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * _moveSpeed;
                _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
            }
        }
        
    }
    private void Jump()
    {
        //en una rampa
        _exitRampa = true; 
        //velocidad
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        _exitRampa = false;
    }
    float angle;
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position + new Vector3(0,0.1f,0), Vector3.down, out slopeHit, 0.3f))
        {
            angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized);
    }
}