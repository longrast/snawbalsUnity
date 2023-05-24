using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovementV3 : NetworkBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    public CharacterController characterController;
    public bool ground;

    public AudioSource jumpAudio;
    public AudioSource walkAudio;
    public AudioSource runAudio;
    private float ySpeed;
    private float originalStepOffset;
    
    private bool isTouchingGround;
    private bool isWalking;
    private bool isRunning;
    private bool isPressed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        isWalking = false;
        isRunning = false;
        walkAudio.loop = true;
        runAudio.loop = true;
        isPressed = false;
    }
/*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "ground")
        {
            if (ground && !isTouchingGround)
            {
                isTouchingGround = true;
                jumpAudio.Play();
            }
            else if (!ground && isTouchingGround)
            {
                isTouchingGround = false;
            } 
        }
    }
*/
    void Update()
    {
        if (!IsOwner) return;
        ground = characterController.isGrounded;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (ground && !isTouchingGround)
        {
            isTouchingGround = true;
            jumpAudio.Play();
        }
        else if (!ground && isTouchingGround)
        {
            isTouchingGround = false;
        }
        /*
        if (Input.GetButtonDown("Fire3"))
        {
            speed *= 2;
            if (!ground || (horizontalInput == 0) && (verticalInput == 0))
            {
                isRunning = false;
                runAudio.loop = isRunning;
            }
            else if (((horizontalInput != 0) || (verticalInput != 0)) && ground && !isRunning)
            {
                isRunning = true;
                runAudio.loop = isRunning;
                runAudio.Play();
            }
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed /= 2;
            isRunning = false;
            runAudio.Stop();
        }
        */

        //if (!isRunning)
        //{

        if (Input.GetButtonDown("Fire3"))
        {
            isRunning = true;
            walkAudio.Stop();
            speed *= 2;
            isPressed = true;
            if (((horizontalInput != 0) || (verticalInput != 0)) && ground)
            {
                if (!runAudio.isPlaying)
                {
                    runAudio.Play();
                }
            }
            /*
            else
            {
                runAudio.Stop();
            }
            */
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            isRunning = false;
            runAudio.Stop();
            speed /= 2;
            isPressed = false;
        }

        if (isPressed)
        {
            if (((horizontalInput != 0) || (verticalInput != 0)) && ground)
            {
                if (!runAudio.isPlaying)
                {
                    runAudio.Play();
                }
            }
            if (((horizontalInput != 0) || (verticalInput != 0)) && !ground)
            {
                if (runAudio.isPlaying)
                {
                    runAudio.Stop();
                }
            }
        }

        if (!isRunning)
        {
            if (((horizontalInput != 0) || (verticalInput != 0)) && ground)
            {
                if (!walkAudio.isPlaying)
                {
                    walkAudio.Play();
                }
            }
            else
            {
                walkAudio.Stop();
            }
        }

        /*
            if (!ground || (horizontalInput == 0) && (verticalInput == 0))
            {
                isWalking = false;
                walkAudio.loop = isWalking;
            }
            else if (((horizontalInput != 0) || (verticalInput != 0)) && ground && !isWalking)
            {
                isWalking = true;
                walkAudio.loop = isWalking;
                walkAudio.Play();
            }
        */


        //}
        //else
        //{
            //isWalking = false;
            //walkAudio.Stop();
        //}


        Vector3 movementDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -1f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
