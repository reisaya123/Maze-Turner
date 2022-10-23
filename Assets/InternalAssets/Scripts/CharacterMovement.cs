using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float motionSmoothTime = 0.25f;
    PlayerControls playerControls;

    public Vector3 move;
    float currentSpeed;
    float speedVelocity;
    float verticalSpeed = 0;
    float gravity = 9.87f;
    private State state;

    private enum State{
        Idle,
        TurnToMove
    }


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerControls.Player.Player1Move.started += ctx => OnMove(ctx);
        // playerControls.Player.Player1Move.canceled += ctx => OnMove(ctx);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        Move();
    }

    // void OnStop(InputAction.CallbackContext context)
    // {
    //     StopCoroutine(Movement());
    // }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 movement = playerControls.Player.Player1Move.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y);
        move = (transform.forward * movement.y) + (transform.right * movement.x);
        move = move.normalized;


        if (characterController.isGrounded)
        {
            verticalSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                move.y = 8f;
            }

        }

        //char rotation
        characterController.transform.Rotate(Vector3.up * movement.x * (100f * Time.deltaTime));

        // if (move != Vector3.zero)
        // {
        //     float rotation = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg + playerCam.eulerAngles.y;
        //     transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, rotationSmoothTime);
        // }

        float targetSpeed = moveSpeed * move.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.1f);

        verticalSpeed -= gravity;
        move.y = verticalSpeed;

        characterController.Move(move * currentSpeed * Time.deltaTime);

        Vector3 horizontalVelocity = characterController.velocity;
        horizontalVelocity = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;

        animator.SetFloat("Speed", horizontalSpeed, motionSmoothTime, Time.deltaTime);
    }
}
