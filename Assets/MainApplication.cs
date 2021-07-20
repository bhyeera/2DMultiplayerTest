using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainApplication : MonoBehaviour
{

    //Player
    public PlayerMovement.PlayerMovementController playerMovement;
    //UI
    public UIManager.UIManager uiManager;
    //Input

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement.PlayerMovementController>();
        uiManager = FindObjectOfType<UIManager.UIManager>();
    }
    private void Update()
    {
        playerMovement.CheckInput();
        playerMovement.AnimatorValues();
    }
    private void FixedUpdate()
    {
        float fixedDelta = Time.fixedDeltaTime;
        playerMovement.jumpTimer += fixedDelta;
        playerMovement.Jump();
        playerMovement.GroundCheck();
    }
}
