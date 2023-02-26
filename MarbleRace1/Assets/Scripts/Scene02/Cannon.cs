using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour
{
    public TMP_Text bulletAmount;

    public GameObject firePoint;
    public GameObject bullet;

    private GameObject firedBullet;

    private float fireDelay=0.05f;

    public float turnSpeed;

    private float turnAngle;
    private float maxAngle = 50;
    private bool turnDirection = true;

    private string ballTag;
    private string bulletTag;

    void Start()
    {
        KnowYourBalls();
    }

    void Update()
    {
        CanonRotation();
    }

    public void Fire(int counter)
    {
        StartCoroutine(WaitBabe(counter));
    }

    IEnumerator WaitBabe(int counter)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag(ballTag);

        foreach (var ball in balls)
        {
            ball.GetComponent<Rigidbody2D>().gravityScale = 0;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        for (int i = 0; i < counter; i++)
        {
            firedBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            firedBullet.GetComponent<Bullet>().BulletMovement(firePoint);

            bulletAmount.text = (counter - i).ToString();

            if(counter <= 512)
            {
                yield return new WaitForSeconds(fireDelay);
            }
            else
            {
                yield return new WaitForSeconds(fireDelay / (counter/512));
            }
        }

        foreach (var ball in balls)
        {
            ball.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    public void Die()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag(ballTag);

        foreach (var ball in balls)
        {
            Destroy(ball);
        }

        Destroy(gameObject);
    }

    private void CanonRotation()
    {
        if (turnAngle <= maxAngle && turnDirection)
        {
            turnAngle += Time.deltaTime * turnSpeed;
        }
        else
        {
            turnDirection = false;
            turnAngle -= Time.deltaTime * turnSpeed;

            if (turnAngle <= -maxAngle)
            {
                turnDirection = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, turnAngle);
    }

    private void KnowYourBalls()
    {
        switch (gameObject.tag)
        {
            case "RedCannon":
                ballTag = "RedBall";
                bulletTag = "RedBullet";

                break;

            case "BlueCannon":
                ballTag = "BlueBall";
                bulletTag = "BlueBullet";

                break;

            case "GreenCannon":
                ballTag = "GreenBall";
                bulletTag = "GreenBullet";

                break;

            case "GreyCannon":
                ballTag = "GreyBall";
                bulletTag = "GreyBullet";

                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(bulletTag))
        {
            Die();
        }
    }
}
