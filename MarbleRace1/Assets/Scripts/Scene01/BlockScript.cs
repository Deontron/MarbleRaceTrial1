using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockScript : MonoBehaviour
{
    private GameObject gm;

    private Color color;

    private GameObject redPointText;
    public static int redPoint = 0;
    private GameObject bluePointText;
    public static int bluePoint = 0;

    void Start()
    {
        redPointText = GameObject.FindGameObjectWithTag("RedPoint");
        bluePointText = GameObject.FindGameObjectWithTag("BluePoint");

        gm = GameObject.FindGameObjectWithTag("GameManager");

        redPointText.GetComponent<TextMeshProUGUI>().text = redPoint.ToString();
        bluePointText.GetComponent<TextMeshProUGUI>().text = bluePoint.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.name == "Ball(Clone)")
            {
                color = Color.red;
                redPoint++;
                redPointText.GetComponent<TextMeshProUGUI>().text = redPoint.ToString();
            }
            else
            {
                color = Color.blue;
                bluePoint++;
                bluePointText.GetComponent<TextMeshProUGUI>().text = bluePoint.ToString();
            }

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }

        if(bluePoint + redPoint >= 392)
        {
            gm.gameObject.GetComponent<GameManager>().FinishGame();
        }
    }
}
