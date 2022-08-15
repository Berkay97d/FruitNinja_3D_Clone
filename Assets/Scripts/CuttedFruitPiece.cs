using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttedFruitPiece : MonoBehaviour
{

    private Rigidbody rb;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void InheritMomentum(Vector3 velocity, Vector3 angularVelocity)
    {
        rb.angularVelocity += angularVelocity;
        rb.velocity += velocity;
    }
    
}
