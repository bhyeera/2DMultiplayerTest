using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class CoinScript : MonoBehaviour
{
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            MainApplication.instance.IncrementScore(1);
                Destroy(this.gameObject);
            }
        }
    }