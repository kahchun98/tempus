using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

    public float maxSpeed = 3;
    public int jumpForce = 100;
    public float gravity = 20.0f;
    public int collisionDis = 1;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private bool crouching = false;
    private const int maxHeight = 2;
    private const int crouchHeight = 1;
    private float currentSpeed;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = maxSpeed;
    }
    // Update is called once per frame
    void Update () {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = Quaternion.Euler(0, this.transform.eulerAngles.y, 0) * moveDirection;
            moveDirection *= currentSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
            if (Input.GetButton("Crouch") && !crouching)
            {

                this.crouching = true;
                crouch();
            }
            if (Input.GetButtonUp("Crouch"))   
            {
                this.crouching = false;
            }

            if (!crouching)
            {
                uncrouch();
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
        
    }

    private void crouch()
    {
        controller.height = crouchHeight;
        currentSpeed = maxSpeed/3;
    }

    private void uncrouch()
    {
        if (!Physics.Raycast(transform.position, Vector3.up, 5))
        {
            currentSpeed = maxSpeed;
            controller.height = maxHeight;
            this.crouching = false;    
        }
    }
}
