using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject CuttedFruit;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CutFruit();
        }
    }

    private void CutFruit()
    {
        //CuttedFruit.SetActive(true);
        Instantiate(CuttedFruit, transform.position, Quaternion.identity);
        CuttedFruit.SetActive(true);
        
        Destroy(gameObject);
    }
}
