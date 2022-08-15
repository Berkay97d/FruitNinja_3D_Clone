using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CuttedFruit : MonoBehaviour
{
    private void Start()
    {
        foreach (var cutted in gameObject.GetComponentsInChildren<Rigidbody>() )
        {
            cutted.AddForce(RandomForce());
            cutted.AddTorque(RandomTorque());
        }
    }


    private void Update()
    {
        DestroyEmptyParent();
    }

    public void SeparateChild()
    {
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
    }

    private void DestroyEmptyParent()
    {
        if (transform.childCount.Equals(0))
        {
            Destroy(gameObject);
        }
    }

    private Vector3 RandomForce()
    {
        var xForce = Random.Range(-20, 0);
        var yForce = Random.Range(-20, 0);
        return new Vector3(xForce, yForce, 0);
    }

    private Vector3 RandomTorque()
    {
        var xTorque = Random.Range(-20, 20);
        var yTorque = Random.Range(-20, 20);
        var zTorque = Random.Range(-20, 20);

        return new Vector3(xTorque, yTorque, zTorque);
    }
}
