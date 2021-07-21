using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIManager;

namespace PlayerMovement
{ 
    public class PlayerMovementController : ApplicationElement
    {
        public Animator playerAnimator;

        public float movementInputDirection;
        public float playerSpeed = 10.0f;
        public float jumpForce = 0.1f;
        public Rigidbody2D rigidBodyInstance;

        public Transform groundCheckPosition;
        public float groundCheckRadius;
        public LayerMask groundLayer;

        [Header("States")]
        public bool isMoving;
        public bool isJumping;
        public bool isGrounded;
        public bool isFalling;
        // jump mechanics

        public int jumpCount = 0;
        public int allowedJumps = 1;
        public float jumpTimer = 0.0f;
        public bool firstJump = true;

        public int playerScore;

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
            rigidBodyInstance = GetComponent<Rigidbody2D>();
        }
        public void MovementTick()
        {
            float fixedDelta = Time.fixedDeltaTime;
            jumpTimer += fixedDelta;
            Jump();
            GroundCheck();
            ApplyMovement();
        }
        public void AnimatorValues()
        {
            playerAnimator.SetFloat("horizontal", movementInputDirection);
        }
        public void ApplyMovement()
        {
            movementInputDirection = app.inputManager.horizontal;
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
        public void Jump()
        {
            if (app.inputManager.jumpInput)
            {
                if (jumpTimer >= 0.25f || firstJump)
                {
                    firstJump = false;
                    if (jumpCount < allowedJumps)
                    {
                        rigidBodyInstance.velocity = new Vector2(rigidBodyInstance.velocity.x, jumpForce);
                        playerAnimator.Play("Jump");
                        isJumping = true;
                        jumpTimer = 0.0f;
                        jumpCount++;
                    }
                }

            }
            if (isGrounded)
            {
                isJumping = false;
                jumpCount = 0;
                jumpTimer = 0.0f;
                firstJump = true;
            }
        }

        public void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);

        }
        public void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckPosition.position,groundCheckRadius);
        }

        public void IncrementScore(int i)
        {
            playerScore += i;
        }
    }
}