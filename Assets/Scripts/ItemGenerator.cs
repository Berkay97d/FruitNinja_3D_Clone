using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] commonFruits;
    [SerializeField] private GameObject rareFruit;
    [SerializeField] private GameObject bomb;


    private void Start()
    {
        InvokeRepeating(nameof(SpawnFruit),0.1f,3.5f);
    }
    

    private void SpawnFruit()
    {
        var fruitNumberSelector = Random.Range(1, 7);
        

        if (fruitNumberSelector <= 1)
        {
            var fruitTypeSelector = Random.Range(0, 100);
            
            switch (fruitTypeSelector)
            {
                case < 50:
                    Instantiate(commonFruits[ fruitTypeSelector % 8 ], RandomSpawnPosition(),Quaternion.identity );
                    return;
                case < 90:
                    Instantiate(bomb, RandomSpawnPosition(),Quaternion.identity );
                    return;
                default:
                    Instantiate(rareFruit, RandomSpawnPosition(),Quaternion.identity );
                    return;
            }
        }

        var counter = 1;
        while (true)
        {
            var fruitTypeSelector = Random.Range(0, 100);
            counter++;

            switch (fruitTypeSelector)
            {
                case < 90:
                    Instantiate(commonFruits[ fruitTypeSelector % 8 ], RandomSpawnPosition(),Quaternion.identity );
                    break;
                default:
                    Instantiate(bomb, RandomSpawnPosition(),Quaternion.identity );
                    break;
            }

            if (counter > fruitNumberSelector)
            {
                return;
            }
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        var xPos = Random.Range(-7, 7);

        return new Vector3(xPos, -5.5f, 0);
    }

    
    
    
    
}