using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] effectors;

    private void Start()
    {
        effectors = GameObject.FindGameObjectsWithTag("Effector");
    }
    public void FinishGame()
    {
        foreach (var item in effectors)
        {
            item.SetActive(false);
        }
    }
}
