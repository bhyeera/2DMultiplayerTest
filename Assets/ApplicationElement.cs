using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    public MainApplication app { get { return GameObject.FindObjectOfType<MainApplication>(); } }
}
