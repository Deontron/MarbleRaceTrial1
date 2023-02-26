using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public GameObject block;

    private Vector2 spawnPoint;
    private GameObject spawnedBlock;

    void Start()
    {
        spawnPoint = transform.position;

        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        for (int i = 0; i < 48; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                spawnedBlock = Instantiate(block, spawnPoint, Quaternion.identity);

                spawnedBlock.gameObject.transform.SetParent(transform);

                spawnPoint.x += 0.2f;
            }

            spawnPoint.x = transform.position.x;
            spawnPoint.y -= 0.2f;
        }
    }
}
