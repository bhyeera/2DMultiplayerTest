using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ApplicationElement
{
    [Header("Inputs")]
    public float horizontal;
    public float vertical;
    public bool jumpInput;

    private void Update()
    {
        TickInput();
    }
    public void TickInput()
    {
        PlayerInputs();
    }
    private void PlayerInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetButton("Jump");
    }
}
