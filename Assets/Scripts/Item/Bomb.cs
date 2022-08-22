using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    public static UnityAction BombBumed; 

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(RandomForce());
        rb.AddTorque(RandomTorque());
    }
   
    private void YokOl()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Game.OnGameStart += YokOl;
    }

    private void OnDisable()
    {
        Game.OnGameStart -= YokOl;
    }
   

    public void Bum()
    {
        BombBumed?.Invoke();

        Game.OnGameOver?.Invoke(new Game.GameOverResponse()
            {
                score = Game.Score,
                latestHighScore = Game.HighScore
            }
        );
    }
    
    

    private Vector3 RandomForce()
    {
        var xForce = Random.Range(-40, 40);
        var yForce = Random.Range(600, 750);
        return new Vector3(xForce, yForce, 0);
    }

    private Vector3 RandomTorque()
    {
        var xTorque = Random.Range(-50, 50);
        var yTorque = Random.Range(-50, 50);
        var zTorque = Random.Range(-50, 50);

        return new Vector3(xTorque, yTorque, zTorque);
    }
}