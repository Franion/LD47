using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    private Rigidbody2D enemyRigidbody;

    public int Hp = 50;
    public ParticleSystem DeadParticles;
    public int score;
    public PlayerMovement playerMovement;


    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

       if (Vector2.Distance(transform.position, player.transform.position) < 10)
       {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
       }

        if(Hp <= 20)
        {
            DeadParticles.Emit(1);
            if(Hp <= 1 && playerMovement.isDead == false)
            {
                playerMovement.score++;
                playerMovement.Hp += 5;
                Destroy(this.gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Hp = Hp -= 10;
        }
    }

    private void FixedUpdate()
    {

        Vector2 PlayPosVec = new Vector2(player.transform.position.x, player.transform.position.y);

        Vector2 aimDirection = PlayPosVec - enemyRigidbody.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        enemyRigidbody.rotation = angle;
    }

}
