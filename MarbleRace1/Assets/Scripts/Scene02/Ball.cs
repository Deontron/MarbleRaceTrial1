using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ballSpawner;

    public GameObject cannon;

    private void Start()
    {
        switch (gameObject.tag)
        {
            case "RedBall":
                cannon = GameObject.FindGameObjectWithTag("RedCannon");

                break;

            case "BlueBall":
                cannon = GameObject.FindGameObjectWithTag("BlueCannon");

                break;

            case "GreenBall":
                cannon = GameObject.FindGameObjectWithTag("GreenCannon");

                break;

            case "GreyBall":
                cannon = GameObject.FindGameObjectWithTag("GreyCannon");

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "BlockBlue":
                //ballSpawner.GetComponent<BallSpawn>().SpawnBall();
                ballSpawner.GetComponent<BallSpawn>().EnlargeGreenBlock();

                transform.position = ballSpawner.transform.position;
                break;

            case "BlockRed":
                ballSpawner.GetComponent<BallSpawn>().SetBulletAmount(cannon, false);

                transform.position = ballSpawner.transform.position;
                break;

            case "BlockGreen":
                ballSpawner.GetComponent<BallSpawn>().SetBulletAmount(cannon, true);

                transform.position = ballSpawner.transform.position;
                break;
        }
    }

    public void GetSpawner(GameObject spawner)
    {
        ballSpawner = spawner;
    }
}
