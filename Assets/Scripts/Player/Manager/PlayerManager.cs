using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovementController playerMovementController;
    public PlayerStats playerStats;

    private void Awake()
    {
        playerMovementController = GetComponent<PlayerMovementController>();
        playerStats = GetComponent<PlayerStats>();
    }
    private void Start()
    {
        playerStats.SetPlayerHealth();
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
