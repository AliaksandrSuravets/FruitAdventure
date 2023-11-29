using System;
using FruitAdventure.PlayerFolder;
using FruitAdventure.Services;
using UnityEngine;

namespace FruitAdventure.Respawn
{
    public class StartPoint : MonoBehaviour
    {
        private void Start()
        {
            PlayerManager.Instance.SetRespawnPoint(transform);
            PlayerManager.Instance.RespawnPlayer();

            if (!GameService.Instance.IsStartTime)
            {
                GameService.Instance.ChangeIsStartTime(true);
            }
            
        }
        
    }
}