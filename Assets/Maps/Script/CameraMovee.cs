using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovee : MonoBehaviour {

    public Transform cameraTransform;
    public float moveSpeed = 10.0f;
    CharacterController characterController = null;    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;    float yVelocity = 0.0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;


        if (characterController.isGrounded == true)
            yVelocity = 0.0f;
        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpSpeed;
        }
        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
