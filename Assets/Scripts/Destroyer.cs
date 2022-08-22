using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Full"))
        {
            Debug.Log("KAÇIRDIN AMK");
        }
        
        Destroy(other.gameObject);
    }
}
