using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float turnSpeed;

    private float turnAngle = 0;
    private float angleLimit = 65;
    private bool turnDirection = true;

    public int ballAmount;
    public GameObject ball;
    public GameObject bulletPoint;
    public float ballPower;

    private GameObject firedBall;
    private Rigidbody2D firedBallRB;

    void Start()
    {
        StartCoroutine(FireTrigger());
    }

    void Update()
    {
        CannonRotation();
    }

    void CannonRotation()
    {
        if (turnAngle <= angleLimit && turnDirection)
        {
            turnAngle += Time.deltaTime * turnSpeed;
        }
        else
        {
            turnDirection = false;

            turnAngle -= Time.deltaTime * turnSpeed;

            if (turnAngle <= -angleLimit)
            {
                turnDirection = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, turnAngle);
    }

    public IEnumerator FireTrigger()
    {
        for (int i = 0; i < ballAmount; i++)
        {
            yield return new WaitForSeconds(2f);
            firedBall = Instantiate(ball, bulletPoint.transform.position, Quaternion.identity);
            firedBall.GetComponent<BallScript>().BallMovement(bulletPoint, ballPower);
        }
    }
}
