using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_controller : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeJump = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeCrouch = KeyCode.C;

    private Camera mainCamera;
    private Quaternion originalCameraRotation;
    private RotateToMouse rotateToMouse;
    private MovementCharacterController movement;
    private PlayerManager playerManager;

    private void Awake()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();

        mainCamera = Camera.main;
        originalCameraRotation = mainCamera.transform.localRotation;

        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        //if (playerManager.isInteracting) return;
        UpdateRotate();
        UpdateJump();
        UpdateMove();
        UpdateCrouch();
    }

    private void UpdateCrouch()
    {
        if (Input.GetKeyDown(keyCodeCrouch))
        {
            CharacterController cc = GetComponent<CharacterController>();
            cc.height /= 2;
            movement.isCrouching = true;
        }

        if (Input.GetKeyUp(keyCodeCrouch))
        {
            CharacterController cc = GetComponent<CharacterController>();
            cc.height *= 2;
            movement.isCrouching = false;
        }
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void UpdateMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement.MoveTo(new Vector3(x, 0, z));
    }

    private void UpdateJump()
    {
        if (Input.GetKey(keyCodeJump))
        {
            movement.Jump();
        }
    }
}