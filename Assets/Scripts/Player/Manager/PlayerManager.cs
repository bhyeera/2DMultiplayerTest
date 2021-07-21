using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ApplicationElement
{
    public PlayerMovement.PlayerMovementController playerMovementController;
    public PlayerStats playerStats;

    private void Awake()
    {
        playerMovementController = GetComponent<PlayerMovement.PlayerMovementController>();
        playerStats = GetComponent<PlayerStats>();
    }
    private void Start()
    {
        app.playerManager.playerStats.SetPlayerHealth();
    }
    private void Update()
    {
        playerMovementController.AnimatorValues();
    }
    private void FixedUpdate()
    {
        playerMovementController.MovementTick();
    }
}
