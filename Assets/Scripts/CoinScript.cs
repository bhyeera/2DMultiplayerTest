using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMovement;
public class CoinScript : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovementController>().IncrementScore(1);
            Destroy(this.gameObject);
        } 
    }
}
