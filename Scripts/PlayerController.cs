using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private Vector3 move;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    public bool isGrounded;
    //public LayerMask groundLayer;
    //public Transform groundCheck;

    public float gravity = -10f;
    public float jumpHeight = 2;
    private Vector3 velocity;

    public Animator animator;
    private bool isSliding = false;

    public float slideDuration = 1.5f;

    bool toggle = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //isGrounded = true;
    }
    private void Update()
    {
        
        if (PlayerManager.isGameStarted)
        {
            direction.z = forwardSpeed;

            if (controller.isGrounded)
            {
                //direction.y = -1;
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                }
            }
            else
            {
                // trong luc
                direction.y += gravity * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Slide();
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                FindObjectOfType<AudioManager>().PlaySound("TurnRight");
                if (desiredLane == 3)
                    desiredLane = 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                FindObjectOfType<AudioManager>().PlaySound("TurnLeft");
                if (desiredLane == -1)
                    desiredLane = 0;
            }

            // di chuyen 2 lane
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (desiredLane == 0)
                targetPosition += Vector3.left * laneDistance;
            else if (desiredLane == 2)
                targetPosition += Vector3.right * laneDistance;

            transform.position = targetPosition;
            controller.center = controller.center;
        }

    }
    private void FixedUpdate()
    {
        if (PlayerManager.isGameStarted)
        {
            controller.Move(direction * Time.fixedDeltaTime);
        }
        
    }

    private void Jump()
    {
        FindObjectOfType<AudioManager>().PlaySound("Jump");
        isGrounded = false;
        direction.y = jumpHeight;
    }

    private void Slide()
    {
        FindObjectOfType<AudioManager>().PlaySound("Slide");
        direction.y -= gravity * -2;
    }

}

