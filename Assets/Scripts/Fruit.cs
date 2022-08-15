using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject CuttedFruit;
   

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(RandomForce());
        GetComponent<Rigidbody>().AddTorque(RandomTorque());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CutFruit();
        }
    }

    private Vector3 RandomForce()
    {
        var xForce = Random.Range(-40, 40);
        var yForce = Random.Range(600, 750);
        return new Vector3(xForce, yForce, 0);
    }

    private Vector3 RandomTorque()
    {
        var xTorque = Random.Range(-20, 20);
        var yTorque = Random.Range(-20, 20);
        var zTorque = Random.Range(-20, 20);

        return new Vector3(xTorque, yTorque, zTorque);
    }

    private void CutFruit()
    {
        
        Instantiate(CuttedFruit, transform.position, Quaternion.identity);
        CuttedFruit.SetActive(true);
        
        Destroy(gameObject);
    }


    
}
