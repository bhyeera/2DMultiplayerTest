using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainApplication : MonoBehaviour
{
    public static MainApplication instance;
    //Events
    public event Action scoreIncrement;

    //Player
    public PlayerManager playerManager;
    //UI
    public UIManager uiManager;
    public InputManager inputManager;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        uiManager = FindObjectOfType<UIManager>();
        inputManager = FindObjectOfType<InputManager>();
    }

    public void IncrementScore( int i)
    {
        scoreIncrement?.Invoke();
    }
}
