using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UIManager
{
    public class UIManager : ApplicationElement
    {
        public Text scoreUI;

        private void Awake()
        {
           // ui = this;
        }
        private void Start()
        {
            scoreUI.text = "0";
        }
        public void SetScore(string score)
        {
           scoreUI.text = score;
        }
    }
}