using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    public bool isCrouching;
    private CharacterController characterController;
    private Vector3 moveForce;
    private PlayerManager playerManager;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        moveForce = Vector3.zero;
        playerManager = GetComponent<PlayerManager>();
    }

    public bool isGrounded()
    {
        return characterController.isGrounded;
    }

    private void FixedUpdate()
    {
        if (isGrounded())
        {
            //jumpCnt = 0;
        }
    }

    private void Update()
    {
        //if (playerManager.isInteracting) return;
        if (!isGrounded())
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        direction = forward * direction.z + right * direction.x;

        moveForce = new Vector3(direction.x * speed, moveForce.y, direction.z * speed);
    }

    public void Jump()
    {
        if (isGrounded())
        {
            moveForce.y = jumpForce;
        }
    }
}