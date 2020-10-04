using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemysBullet;
    public Transform enemySpawnBulletPos;
    public Rigidbody2D enemysBulletRb;
    public float bulletSpeed = 10;
    public float TimeToShoot;

    void Start()
    {
        TimeToShoot = 0f;
    }

    void Update()
    {
        

        TimeToShoot += Time.deltaTime;

        if(TimeToShoot >= 1.0f)
        {
            GameObject bull = Instantiate(enemysBullet, enemySpawnBulletPos.position, Quaternion.identity);
            bull.GetComponent<Rigidbody2D>().AddForce(enemySpawnBulletPos.up * bulletSpeed, ForceMode2D.Impulse);
            TimeToShoot = 0f;
        }
    }
}
