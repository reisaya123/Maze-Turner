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
    [SerializeField] float smoothTime = 0.12f;
    Vector3 currentVel;

    public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {

        verticalInput += Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalInput -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        horizontalInput = Mathf.Clamp(horizontalInput, rotationMin, rotationMax);

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(horizontalInput, verticalInput), ref currentVel, smoothTime);
        transform.eulerAngles = targetRotation;
        // target.eulerAngles = targetRotation;
        // Quaternion newRotation = Quaternion.Euler(0f,verticalInput,0f);
        transform.position = target.position - transform.forward * 5f;


        // transform.rotation = Quaternion.Euler(0f, verticalInput, 0f);
        // transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);
        // player.transform.rotation = Quaternion.Euler(0f, verticalInput, 0f);
    }
}
