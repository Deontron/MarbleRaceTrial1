using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloaderScript : MonoBehaviour
{
    public GameObject cannon;

    public GameObject firePoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = firePoint.transform.position;
        collision.gameObject.GetComponent<BallScript>().BallMovement(firePoint.gameObject, cannon.GetComponent<CannonScript>().ballPower);
    }
}
