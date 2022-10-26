using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 10f;
    // Transform player;

    Vector3 targetRotation;
    float verticalInput;
    float horizontalInput;

    float rotationMin = -5f;
    float rotationMax = 80f;
    [SerializeField] float zoomOut = 5f;
    [SerializeField] float smoothTime = 0.12f;
    Vector3 currentVel;
    public List<GameObject> targets;
    public Transform targetCam;
    bool targetPlayer;


    private void Start()
    {
        targetPlayer = false;
    }

    void Update()
    {
        foreach (GameObject target in targets)
        {
            if (GameManager.instance.GetState() == GameManager.GameState.RollDice)
            {
                targetPlayer = false;
                if (target.name == "TopCamera")
                {
                    targetCam = target.transform;
                    transform.position = targetCam.transform.position;
                    transform.rotation = targetCam.rotation;
                }
            }
            // else
            // {
            //     //add player 1 or 2
            //     targetPlayer = true;
            //     targetCam = target.transform;
            // }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (targetPlayer)
        {
            verticalInput += Input.GetAxis("Mouse X") * mouseSensitivity;
            horizontalInput -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            horizontalInput = Mathf.Clamp(horizontalInput, rotationMin, rotationMax);

            targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(horizontalInput, verticalInput), ref currentVel, smoothTime);
            transform.eulerAngles = targetRotation;

            transform.position = targetCam.position - transform.forward * zoomOut;

        }

    }
}
