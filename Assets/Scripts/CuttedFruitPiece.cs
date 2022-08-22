using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        var minxForce = Random.Range(-300, -200);
        var maxForce = Random.Range(200, 300);
        var xForce = Random.Range(minxForce, maxForce);
        rb.AddForce(xForce,0,0);
    }

    
    
}
