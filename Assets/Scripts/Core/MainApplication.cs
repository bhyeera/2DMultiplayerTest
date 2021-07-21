using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainApplication : MonoBehaviour
{
    //Player
    public PlayerManager playerManager;
    //UI
    public UIManager.UIManager uiManager;
    public InputManager inputManager;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        uiManager = FindObjectOfType<UIManager.UIManager>();
        inputManager = FindObjectOfType<InputManager>();
    }
}
