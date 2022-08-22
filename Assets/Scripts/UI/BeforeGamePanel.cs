using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeforeGamePanel : MonoBehaviour
{
   [SerializeField] private GameObject beforeGamePanel;
   
   
   public void StartGame()
   {
      Game.Start();
      
   }

   private void DisablePanel()
   {
      beforeGamePanel.SetActive(false);
   }

   private void OnGameStarted()
   {
      DisablePanel();
   }
   
   private void OnEnable()
   {
      Game.OnGameStart += OnGameStarted;
   }

   private void OnDisable()
   {
      Game.OnGameStart -= OnGameStarted;
   }
}
