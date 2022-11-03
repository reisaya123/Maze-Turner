using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    [SerializeField] float motionSmoothTime = 0.25f;
    PlayerControls playerControls;

    public Vector3 move;
    float currentSpeed;
    float speedVelocity;
    float verticalSpeed = 0;
    float gravity = 9.87f;

    bool isTurn = false;
    int turnDuration;

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
        characterController = transform.GetComponent<CharacterController>();
        animator = transform.GetComponent<Animator>();
        if (transform.name == "Player1")
        {
            playerControls.Player.Player1Move.started += ctx => OnMove(ctx);
        }
        else if (transform.name == "Player2")
        {
            playerControls.Player.Player2Move.started += ctx => OnMove(ctx);
        }

        StartCoroutine(CheckIfTurn());
    }

    void OnMove(InputAction.CallbackContext context)
    {
        Move();
    }

    private void Update()
    {
        isTurn = transform.GetComponent<Player>().myTurn;
    }

    IEnumerator CheckIfTurn()
    {
        yield return new WaitUntil(CanMove);
        StartCoroutine(Move());
        StartCoroutine(MoveDuration());
    }

    bool CanMove()
    {
        if (isTurn)
        {
            turnDuration = transform.GetComponent<Player>().turnDuration;
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator MoveDuration()
    {
        while (true)
        {

            Debug.Log(turnDuration);
            if (turnDuration == 0)
            {
                if (GameManager.instance.GetState() == GameManager.GameState.PlayerTurn)
                {
                    GameManager.instance.UpdateGameState(GameManager.GameState.OtherPlayerTurn);
                }
                else if (GameManager.instance.GetState() == GameManager.GameState.OtherPlayerTurn)
                {
                    GameManager.instance.UpdateGameState(GameManager.GameState.RollDice);
                }
                yield break;
            }

            turnDuration--;

            yield return new WaitForSeconds(1f);

        }
    }

    IEnumerator Move()
    {
        Vector2 movement = new Vector2(0f, 0f);
        while (true)
        {

            if (turnDuration == 0)
            {
                isTurn = false;
                yield break;
            }

            if (transform.name == "Player1")
            {
                movement = playerControls.Player.Player1Move.ReadValue<Vector2>();
            }
            else if (transform.name == "Player2")
            {
                movement = playerControls.Player.Player2Move.ReadValue<Vector2>();
            }


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

            float targetSpeed = transform.GetComponent<AnimalCharacter>().moveSpeed * move.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.1f);

            verticalSpeed -= gravity;
            move.y = verticalSpeed;

            characterController.Move(move * currentSpeed * Time.deltaTime);

            Vector3 horizontalVelocity = characterController.velocity;
            horizontalVelocity = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
            float horizontalSpeed = horizontalVelocity.magnitude;

            animator.SetFloat("Speed", horizontalSpeed, motionSmoothTime, Time.deltaTime);

            yield return null;
        }
    }

}
