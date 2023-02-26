using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D firedBallRB;
    public void BallMovement(GameObject bulletPoint, float ballPower)
    {
        firedBallRB = transform.GetComponent<Rigidbody2D>();

        firedBallRB.AddForce(bulletPoint.transform.forward.normalized * ballPower);
    }
}
