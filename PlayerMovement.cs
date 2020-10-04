using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb2d;
    Vector2 movement;

    private Vector2 mousePos;
    public Camera cam;

    public Weapon weapon;

    public int Hp;
    public Text hpTxt;
    public bool isDead;
    public GameObject deadCanvas;
    public int score;
    public Text scoreText;
    public Text scoreAfterDeathText;
    public Text bestScoreAfterDeathText;
    public GameObject Booster;

    void Start()
    {
        movementSpeed = 5.0f;
        Hp = 100;
        isDead = false;
        deadCanvas.gameObject.SetActive(false);
        score = 0;
    }

    void Update()
    {
        if(isDead == false)
        {
            hpTxt.text = "Hp: " + Hp.ToString();
            scoreText.text = "Score: " + score.ToString();
        }

        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Fire();
        }

        if(Hp <= 0)
        {
            isDead = true;
            deadCanvas.gameObject.SetActive(true);
            scoreAfterDeathText.text = "Score: " + score.ToString();

            if(score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
            }

            bestScoreAfterDeathText.text = "BestScore: " + PlayerPrefs.GetInt("BestScore").ToString();
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            movementSpeed = 8.0f;
        }
        else
        {
            movementSpeed = 5.0f;
        }

        rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 aimDirection = mousePos - rb2d.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemBullet")
        {
            Hp -= 10;
        }

        if(collision.gameObject.tag == "Booster")
        {
                Hp += 10;
                Booster.gameObject.SetActive(false);
        }
    }

}
