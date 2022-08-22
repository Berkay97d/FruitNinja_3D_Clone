using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Game
{
    private const string HighScoreKey = "HighScoreKey";
    private const int DefaultHighScoreValue = 0;
    private const int DefaultScoreValue = 0;
    
    public static UnityAction <GameOverResponse> OnGameOver;
    public static UnityAction OnGameStart;
    public static UnityAction OnGameRestart;
    public static UnityAction<ScoreChangeResponse> OnScoreChanged;
    public static int Score { get; private set;}

    public static int HighScore
    {
        get => PlayerPrefs.GetInt(HighScoreKey, DefaultHighScoreValue); 
        set
        {
            var newScore = value;
            
            if (newScore > HighScore)
            {
                PlayerPrefs.SetInt(HighScoreKey,newScore);
            }
        }
    }

    public struct GameOverResponse
    {
        public int score, latestHighScore;
        public bool IsRecord => score > latestHighScore;

    }
    
    public struct ScoreChangeResponse
    {
        public int oldScore, newScore;
        public int DeltaScore => newScore - oldScore;
    }

    public static void IncreaseScore(int point)
    {
        var oldScore = Score;
        var newScore = oldScore + point;
        Score = newScore;
        
        OnScoreChanged?.Invoke(new ScoreChangeResponse()
        {
            newScore = newScore,
            oldScore = oldScore
        });

    }

    private static void ResetScore()
    {
        Score = DefaultScoreValue;
        OnScoreChanged?.Invoke(new ScoreChangeResponse()
        {
            newScore = DefaultScoreValue,
            oldScore = DefaultScoreValue
        });
    }

    public static void Start()
    {
        ResetScore();
        OnGameStart?.Invoke();

    }

    public static void Restart()
    {
        Start();
        OnGameRestart?.Invoke();
    }

    
}
