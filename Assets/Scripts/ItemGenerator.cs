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
            var randomPos = RandomSpawnPosition();
            var spawnPos = new Vector3(randomPos.x, randomPos.y, (counter * 3) - 3 );
            counter++;

            switch (fruitTypeSelector)
            {
                case < 75:
                    Instantiate(commonFruits[ fruitTypeSelector % 8 ], spawnPos,Quaternion.identity );
                    break;
                default:
                    Instantiate(bomb, spawnPos,Quaternion.identity );
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
        var xPos = Random.Range(-8, 8);
        
        return new Vector3(xPos, -5.5f, 0);
    }

    


    private void StopThrowing()
    {
        CancelInvoke();
    }

    private void OnBombBum()
    {
        StopThrowing();
    }

    private void OnGameStarted()
    {
        InvokeRepeating(nameof(SpawnFruit),0.1f,3.5f);
    }

    private void OnEnable()
    {
        Bomb.BombBumed += OnBombBum;
        Game.OnGameStart += OnGameStarted;
    }

    private void OnDisable()
    {
        Bomb.BombBumed -= OnBombBum;
        Game.OnGameStart -= OnGameStarted;
    }


    

    
    
    
    
}