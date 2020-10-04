using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLapConroller : MonoBehaviour
{
    public bool CanSpawnEnemys;
    public PlayerMovement playerMovement;
    public GameObject HpBooster;

    void Start()
    {
        CanSpawnEnemys = false;
        HpBooster.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanSpawnEnemys = true;
            HpBooster.gameObject.SetActive(true);
        }
    }
}
