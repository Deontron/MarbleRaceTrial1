using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Color red;
    public Color blue;
    public Color green;
    public Color grey;

    private string blockColor = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>().color != blockColor)
        {
            switch (collision.tag)
            {
                case "RedBullet":
                    GetComponent<SpriteRenderer>().color = red;
                    blockColor = "red";

                    break;

                case "BlueBullet":
                    GetComponent<SpriteRenderer>().color = blue;
                    blockColor = "blue";

                    break;

                case "GreenBullet":
                    GetComponent<SpriteRenderer>().color = green;
                    blockColor = "green";

                    break;

                case "GreyBullet":
                    GetComponent<SpriteRenderer>().color = grey;
                    blockColor = "grey";

                    break;
            }

            Destroy(collision.gameObject);
        }


    }
}
