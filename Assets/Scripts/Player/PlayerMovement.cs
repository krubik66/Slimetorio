using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private bool isCrouching = false;
    private bool doCrouch = false;
    private bool isSprinting = false;
    private float crouchTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessMove(Vector2 inputMovement, Vector2 inputFlight) {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = inputMovement.x;
        moveDirection.z = inputMovement.y;
        moveDirection.y = inputFlight.y;
        controller.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Sprint() {
        isSprinting = !isSprinting;
        if(isSprinting) {
            speed *= 2;
        }
        else {
            speed /= 2;
        }
    }
}
