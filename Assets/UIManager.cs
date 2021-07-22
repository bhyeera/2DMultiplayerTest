using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class UIManager : MonoBehaviour
{
        public Text scoreUI;

        private void Awake()
        {
           // ui = this;
        }
        private void Start()
        {
            MainApplication.instance.scoreIncrement += SetScore;
            scoreUI.text = "0";
        }
        public void SetScore()
        {
           scoreUI.text = MainApplication.instance.playerManager.playerStats.playerScore.ToString();
        }
    }