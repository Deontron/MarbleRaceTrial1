using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSpawn : MonoBehaviour
{
    public GameObject greenBlock;
    public GameObject redBlock;
    public GameObject blackBlock;

    public GameObject ball;

    public float movementSpeed;

    private float coordinateX;
    private float maxX = 1.3f;
    private bool moveDirection;

    private GameObject spawnedBall;

    private int bulletAmount = 1;

    public TMP_Text bulletAmountText;

    private int ballSpawnDelay = 0;

    void Update()
    {
        CannonMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        spawnedBall = Instantiate(ball, transform.position, transform.localRotation);

        spawnedBall.GetComponent<Ball>().GetSpawner(gameObject);
    }

    public void EnlargeGreenBlock()
    {
        if (redBlock.transform.localScale.x >= 0.9)
        {

            blackBlock.transform.Translate(-0.06f, 0, 0);
            redBlock.transform.Translate(-0.03f, 0, 0);
            greenBlock.transform.Translate(-0.03f, 0, 0);

            redBlock.transform.localScale = new Vector2(redBlock.transform.localScale.x - 0.06f, redBlock.transform.localScale.y);
            greenBlock.transform.localScale = new Vector2(greenBlock.transform.localScale.x + 0.06f, greenBlock.transform.localScale.y);
        }
        else
        {
            if (ballSpawnDelay % 3 == 0)
            {
                SpawnBall();
            }

            ballSpawnDelay++;
        }
    }

    public void SetBulletAmount(GameObject cannon, bool multiply)
    {
        if (multiply)
        {
            bulletAmount *= 2;

            bulletAmountText.text = bulletAmount.ToString();
        }
        else
        {
            cannon.GetComponent<Cannon>().Fire(bulletAmount);
            bulletAmount = 1;

            bulletAmountText.text = bulletAmount.ToString();
        }
    }

    private void CannonMovement()
    {
        coordinateX = transform.localPosition.x;

        if (coordinateX <= maxX && moveDirection)
        {
            transform.Translate(Time.deltaTime * movementSpeed, 0, 0);
        }
        else
        {
            moveDirection = false;

            transform.Translate(-Time.deltaTime * movementSpeed, 0, 0);

            if (coordinateX <= -maxX)
            {
                moveDirection = true;
            }
        }
    }
}
