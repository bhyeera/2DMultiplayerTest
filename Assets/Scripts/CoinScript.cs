using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMovement;


namespace Coin
{
    public class CoinScript : ApplicationElement
    {
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                app.playerManager.playerMovementController.IncrementScore(1);
                Destroy(this.gameObject);
            }
        }
    }
}