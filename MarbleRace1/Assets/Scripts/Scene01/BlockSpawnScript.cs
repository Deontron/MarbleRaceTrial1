using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnScript : MonoBehaviour
{
    public GameObject block;
    public GameObject spawnPointCenter;

    private Vector2 spawnPoint;
    private GameObject SpawnedBlock;

    void Start()
    {
        spawnPoint = spawnPointCenter.transform.position;

        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                SpawnedBlock = Instantiate(block, spawnPoint, Quaternion.identity);

                SpawnedBlock.gameObject.transform.SetParent(spawnPointCenter.transform);
                spawnPoint.x += 0.5f;
            }

            spawnPoint.x = spawnPointCenter.transform.position.x;
            spawnPoint.y -= 0.5f;
        }
    }
}
