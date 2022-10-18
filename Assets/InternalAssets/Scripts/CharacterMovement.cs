using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float motionSmoothTime = 0.1f;

    Vector3 movement;
    float verticalSpeed = 0;
    float gravity = 9.87f;
    float verticalMouseInput;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 characterControllerCurrentPos = characterController.transform.position;
        movement = new Vector3(horizontalInput, 0f, verticalInput);

        movement = movement.normalized * moveSpeed;
        movement = transform.worldToLocalMatrix.inverse * movement;

        if (characterController.isGrounded)
        {
            verticalSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.y = 8f;
            }

        }

        // apply gravity acceleration to vertical speed
        verticalSpeed -= gravity;
        movement.y = verticalSpeed;

        characterController.Move(movement);

        Vector3 horizontalVelocity = characterController.velocity;
        horizontalVelocity = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;

        //(string name, float value, float dampTime, deltaTime)
        animator.SetFloat("Speed", horizontalSpeed, motionSmoothTime, Time.deltaTime);
    }

}
