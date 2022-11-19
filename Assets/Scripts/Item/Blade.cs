using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Game.life == 0)
        {
            Bomb.BombBumed();
        }
        
        MoveBlade();
    }
    
    
    private void MoveBlade()
    {
        rb.MovePosition(Camera.main!.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FreezeTime(Game.GameOverResponse gameOverResponse)
    {
        Time.timeScale = 0;
    }

    private void NormalizeTİme()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        Game.OnGameOver += FreezeTime;
        Game.OnGameStart += NormalizeTİme;
    }

    private void OnDisable()
    {
        Game.OnGameOver -= FreezeTime;
        Game.OnGameStart -= NormalizeTİme;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fruit fruit))
        {
            fruit.CutFruit();
        }

        if (other.TryGetComponent(out Bomb bomb))
        {
            bomb.Bum();
        }
    }
}
