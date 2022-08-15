using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttedFruitPiece : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private Fruit parentFruit;
    
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        InheritMomentum();
        Fragmentation();

    }

    public void SeparateChildren()
    {
        gameObject.SetActive(true);
        transform.SetParent(null);
    }

    private void InheritMomentum()
    {
        rb.velocity = parentFruit.DetectLastVelocity();
        rb.angularVelocity = parentFruit.DetectLastAngularVelocity();
    }

    private void Fragmentation()
    {
        var xForce = Random.Range(-30, 30);
        rb.AddForce(xForce,0,0);
    }
    
}
