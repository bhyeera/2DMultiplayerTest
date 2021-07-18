using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement { 
    public class PlayerMovementController : MonoBehaviour
    {
        private float movementInputDirection;
        public float playerSpeed = 10.0f;
        public float jumpForce = 0.1f;
        private Rigidbody2D rigidBodyInstance;

        // Start is called before the first frame update
        void Start()
        {
            rigidBodyInstance = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();   
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ApplyMovement();
        }
        private void CheckInput()
        {
            movementInputDirection = Input.GetAxisRaw("Horizontal");
            if(Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        private void ApplyMovement()
        {
            rigidBodyInstance.velocity = new Vector2(playerSpeed * movementInputDirection, rigidBodyInstance.velocity.y);
        }
        private void Jump()
        {
            rigidBodyInstance.velocity = new Vector2(rigidBodyInstance.velocity.x, jumpForce);
        }
    }
}