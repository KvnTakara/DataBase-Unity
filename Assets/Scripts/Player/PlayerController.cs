using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    GameObject Camera;
    [SerializeField] GameObject playerCamera;
    [SerializeField] float walkSpeed = 6f;
    [SerializeField] float runSpeed = 12f;
    [SerializeField] float jumpPower = 7f;
    [SerializeField] float gravity = 10f;


    [SerializeField] float lookSpeed = 2f;
    [SerializeField] float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [SerializeField] bool canMove = true;


    CharacterController characterController;

    #endregion

    #region Initialization

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Camera = GameObject.Find("Main Camera");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!canMove) return;

        MovePlayer();
        RotatePlayer();
        Jump();

        ApplyGravity();
        UpdateCameraPosition();
    }

    #endregion

    #region Functions

    void MovePlayer()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning) ? runSpeed * Input.GetAxis("Vertical") : walkSpeed * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning) ? runSpeed * Input.GetAxis("Horizontal") : walkSpeed * Input.GetAxis("Horizontal");
        
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        characterController.Move(moveDirection * Time.deltaTime);
    }

    void RotatePlayer()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && characterController.isGrounded) moveDirection.y = jumpPower;
    }

    void ApplyGravity()
    {
        if (characterController.isGrounded) moveDirection.y -= gravity * Time.deltaTime;
    }

    void UpdateCameraPosition()
    {
        Camera.transform.position = playerCamera.transform.position;
        Camera.transform.rotation = playerCamera.transform.rotation;
    }

    #endregion
}
