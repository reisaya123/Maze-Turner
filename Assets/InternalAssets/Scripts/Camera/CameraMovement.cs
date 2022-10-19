using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 1f;
    Transform player;
    float verticalInput;

    void Start() {
        player = transform.root.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput += Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.rotation = Quaternion.Euler(0f, verticalInput, 0f);
        player.transform.rotation = Quaternion.Euler(0f, verticalInput, 0f);
    }
}
