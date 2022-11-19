using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private TMP_Text score;

    [SerializeField] private GameObject healthL;
    [SerializeField] private GameObject healthM;
    [SerializeField] private GameObject healthR;


    private void Update()
    {
        ControlHealth();
        
    }

    private void ControlHealth()
    {
        if (Game.life == 3)
        {
            healthL.SetActive(false);
            healthM.SetActive(false);
            healthR.SetActive(false);
        }
        else if (Game.life == 2)
        {
            healthL.SetActive(false);
            healthM.SetActive(false);
            healthR.SetActive(true);
        }
        else if (Game.life == 1)
        {
            healthL.SetActive(false);
            healthM.SetActive(true);
            healthR.SetActive(true);
        }
        else if (Game.life == 0)
        {
            healthL.SetActive(true);
            healthM.SetActive(true);
            healthR.SetActive(true);
        }
        
    }
    
    private void ActivatePanel()
    {
        inGamePanel.SetActive(true);
    }

    private void DisablePanel()
    {
        inGamePanel.SetActive(false);
    }

    private void UpdateScore(int score)
    {
        this.score.text = score.ToString();
    }

    private void OnGameStarted()
    {
        ActivatePanel();
    }

    private void OnScoreChanged(Game.ScoreChangeResponse scoreChangeResponse)
    {
        UpdateScore(scoreChangeResponse.newScore);
    }

    private void OnGameOver(Game.GameOverResponse response)
    {
        DisablePanel();
    }

    private void OnEnable()
    {
        Game.OnGameStart += OnGameStarted;
        Game.OnGameOver += OnGameOver;
        Game.OnScoreChanged += OnScoreChanged;

    }

    private void OnDisable()
    {
        Game.OnGameStart -= OnGameStarted;
        Game.OnGameOver -= OnGameOver;
        Game.OnScoreChanged -= OnScoreChanged;
    }

   
}
