using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    private PlayerStats stats;

    public float walkSpeed = 6f;
    private float sprintSpeed = 10f;
    public float targetSpeed;
    private float jumpHeight = 3f;
    public bool isSprinting = false;
    public bool isWalking = false;

    public float gravity = -9.81f;
    public Vector3 velocity;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float smoothVelocity;

    Velocity playerVelocity;
    public float upwardsMomentum;

    private void Start()
    {
        stats = transform.GetComponent<PlayerStats>();
        playerVelocity = transform.GetComponent<Velocity>();
        walkSpeed = stats.speed;
        sprintSpeed = stats.sprintSpeed;
        jumpHeight = stats.jumpHeight;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyUp("left shift") && isSprinting)
        {
            playerVelocity.currentSpeed -= sprintSpeed;
            isSprinting = false;
            Debug.Log("stopped sprinting");
        }

        // If player inputs movement
        if(direction.magnitude >= 0.1f)
        {
            // Player rotation based on camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Movement
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            walk();
            sprint();
            StartCoroutine(velocityCheck());
            
            controller.Move(moveDir * playerVelocity.currentSpeed * Time.deltaTime);
        }

        else
        {
            isWalking = false;
            isSprinting = false;
            velocityCheck();
        }
    }

    void walk()
    {
        if ( !isWalking || (playerVelocity.currentSpeed < walkSpeed && isWalking) )
        {
            targetSpeed = walkSpeed;
            isWalking = true;
            Debug.Log("walking");
        }
        
        else if (playerVelocity.currentSpeed != 0 && playerVelocity.velocity.x == 0 && playerVelocity.velocity.z == 0)
        {
            playerVelocity.currentSpeed = 0;
            isWalking = false;
            Debug.Log("stopped walking");
        }
    }

    void sprint()
    {
        if (Input.GetKey("left shift") && isWalking && isGrounded && isSprinting)
        {
            targetSpeed = sprintSpeed;
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    IEnumerator velocityCheck()
    {
        if (playerVelocity.currentSpeed > targetSpeed)
        {
            playerVelocity.currentSpeed--;
            yield return new WaitForFixedUpdate();
        }
        else if (playerVelocity.currentSpeed < targetSpeed)
        {
            playerVelocity.currentSpeed++;
            yield return new WaitForSeconds(0.1f);
        }

        if (!isWalking && !isSprinting)
        {
            targetSpeed = 0;
        }
    }
}
