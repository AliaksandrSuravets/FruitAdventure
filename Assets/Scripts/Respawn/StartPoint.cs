﻿using System;
using FruitAdventure.PlayerFolder;
using FruitAdventure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FruitAdventure.Respawn
{
    public class StartPoint : MonoBehaviour
    {
        private void Start()
        {
            GameService.Instance.ChangeLevelNumber(SceneManager.GetActiveScene().buildIndex);
            PlayerManager.Instance.SetRespawnPoint(transform);
            PlayerManager.Instance.RespawnPlayer();

            if (!GameService.Instance.IsStartTime)
            {
                GameService.Instance.ChangeIsStartTime(true);
            }
            
        }
        
    }
}