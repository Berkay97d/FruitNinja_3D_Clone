using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    
    private Rigidbody rb;


    private void Start()
    {
        
        
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(RandomForce());
        rb.AddTorque(RandomTorque());
        
    }

    private void YokOl(Game.GameOverResponse gameOverResponse)
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Game.OnGameOver += YokOl;
    }

    private void OnDisable()
    {
        Game.OnGameOver -= YokOl;
    }


    public void CutFruit()
    {
        foreach (var piece in GetComponentsInChildren<CuttedFruitPiece>(true))
        {
            piece.SeparateChildren();
        }
        
        Game.IncreaseScore(10);
        Destroy(gameObject);
    }
    
    

    public Vector3 DetectLastVelocity()
    {
        return rb.velocity;
    }
    
    public Vector3 DetectLastAngularVelocity()
    {
        return rb.angularVelocity;
    }
    

    private Vector3 RandomForce()
    {
        var xForce = Random.Range(-35, 35);
        var yForce = Random.Range(600, 700);
        return new Vector3(xForce, yForce, 0);
    }

    private Vector3 RandomTorque()
    {
        var xTorque = Random.Range(-100, 100);
        var yTorque = Random.Range(-100, 100);
        var zTorque = Random.Range(-100, 100);

        return new Vector3(xTorque, yTorque, zTorque);
    }
    
    
}
