using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemysController : MonoBehaviour
{
    public GameObject Enemy;
    public NewLapConroller newLapConroller;
    public Transform spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4;


    void Start()
    {
        
    }

    void Update()
    {

        if(newLapConroller.CanSpawnEnemys == true)
        {
            print("1234");
            Instantiate(Enemy, spawnPoint1.position, Quaternion.identity);
            Instantiate(Enemy, spawnPoint2.position, Quaternion.identity);
            Instantiate(Enemy, spawnPoint3.position, Quaternion.identity);
            Instantiate(Enemy, spawnPoint4.position, Quaternion.identity);
            newLapConroller.CanSpawnEnemys = false;
        }
    }
}
