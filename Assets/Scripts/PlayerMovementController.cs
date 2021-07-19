using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerMovement { 
    public class PlayerMovementController : MonoBehaviour
    {
        public Animator playerAnimator;

        private float movementInputDirection;
        public float playerSpeed = 10.0f;
        public float jumpForce = 0.1f;
        private Rigidbody2D rigidBodyInstance;

        public Transform groundCheckPosition;
        public float groundCheckRadius;
        public LayerMask groundLayer;

        [Header("States")]
        public bool isMoving;
        public bool isJumping;
        public bool isGrounded;
        public bool isFalling;

        [Header("Inputs")]
        public bool jumpInput;


        public int playerScore;
        public Text scoreUI;

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
            rigidBodyInstance = GetComponent<Rigidbody2D>();
        }
        void Start()
        {

        }
        void Update()
        {
            CheckInput();
            AnimatorValues();
        }
        void FixedUpdate()
        {
            ApplyMovement();
            Jump();
            GroundCheck();
        }
        private void CheckInput()
        {
            movementInputDirection = Input.GetAxisRaw("Horizontal");
            jumpInput = Input.GetButton("Jump");
        }
        private void AnimatorValues()
        {
            playerAnimator.SetFloat("horizontal", movementInputDirection);
        }
        private void ApplyMovement()
        {
            rigidBodyInstance.velocity = new Vector2(playerSpeed * movementInputDirection, rigidBodyInstance.velocity.y);
            if (rigidBodyInstance.velocity.x > 0 || rigidBodyInstance.velocity.x < 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        private void Jump()
        {
            if (jumpInput && !isJumping)
            {
                rigidBodyInstance.velocity = new Vector2(rigidBodyInstance.velocity.x, jumpForce);
                isJumping = true;
                playerAnimator.Play("Jump");
            }

            if (isGrounded)
            {
                isJumping = false;
            }
        }

        private void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);

        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckPosition.position,groundCheckRadius);
        }

        public void IncrementScore(int i)
        {
            playerScore += i;
            scoreUI.text = playerScore.ToString();
        }
    }
}