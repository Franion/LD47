using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBooerController : MonoBehaviour
{
    public PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMovement.Hp += 10;
        }
    }
}
