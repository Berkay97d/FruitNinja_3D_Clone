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

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CutFruit();
        }
    }
    

    private void CutFruit()
    {
        foreach (var piece in GetComponentsInChildren<CuttedFruitPiece>(true))
        {
            piece.SeparateChildren();
        }
        
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
