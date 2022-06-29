using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] private Rigidbody[] commonFruits;
    [SerializeField] private Rigidbody rareFruits;
    [SerializeField] private Rigidbody bomb;


    private void Update()
    {
        ThrowObject(PickRandomObject());
    }


    private void ThrowObject(Rigidbody obj)
    {

        obj.AddForce(RandomForce());
        obj.AddTorque(RandomAngularForce());
    }
    
    
    
    private Rigidbody PickRandomObject()
    {
        
        var objectTypePicker = Random.Range(0, 100);
        var fruitPicker = Random.Range(0, 8);

        if (objectTypePicker < 5)
        {
            return Instantiate(rareFruits,Vector3.zero, Quaternion.identity,transform);
            
        }

        if (objectTypePicker < 35)
        {
            return Instantiate(bomb,Vector3.zero, Quaternion.identity,transform);
        }

        return Instantiate(commonFruits[fruitPicker],Vector3.zero, Quaternion.identity,transform);
    }
    

    
    private Vector3 RandomForce()
    {
        var xForce = Random.Range(-5,5);
        var yForce = Random.Range(5,10);

        return new Vector3(xForce, yForce, 0);
    }

    
    
    private Vector3 RandomAngularForce()
    {
        var xForce = Random.Range(-10,10);
        var yForce = Random.Range(-10,10);
        var zForce = Random.Range(-10,10);

        return new Vector3(xForce, yForce, zForce);
    }
    
    
    
    
}