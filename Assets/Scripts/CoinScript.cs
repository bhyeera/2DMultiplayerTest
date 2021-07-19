using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           print(collision.gameObject.tag);
           collision.gameObject.GetComponent<PlayerMovement.PlayerMovementController>().IncrementScore(1);
           Destroy(this.gameObject);
        } 
    }
}
