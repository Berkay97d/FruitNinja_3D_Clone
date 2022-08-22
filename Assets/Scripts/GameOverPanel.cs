using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    

    private void UpdateHighScore(int newHighScore)
    {
        Game.HighScore = newHighScore;
        highScoreText.text = Game.HighScore.ToString();
    }

    private void OnBombBum()
    {
        ActivatePanel();
    }

    public void RestartGame()
    {
        Game.Restart();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private void OnGameOver(Game.GameOverResponse response)
    {
       UpdateScore(response.score);
       UpdateHighScore(response.score);
       
    }
    
    private void OnGameRestarted()
    {
        DisablePanel();
    }
    
    private void ActivatePanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void DisablePanel()
    {
        gameOverPanel.SetActive(false);
    }

    private void OnEnable()
    {
        Bomb.BombBumed += OnBombBum;
        Game.OnGameRestart += OnGameRestarted;
        Game.OnGameOver += OnGameOver;
        
    }

    private void OnDisable()
    {
        Bomb.BombBumed -= OnBombBum;
        Game.OnGameRestart -= OnGameRestarted;
        Game.OnGameOver -= OnGameOver;
    }
}
