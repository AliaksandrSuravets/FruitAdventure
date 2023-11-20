using System;
using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Respawn
{
    public class StartPoint : MonoBehaviour
    {
        private void Start()
        {
            PlayerManager.Instance.SetRespawnPoint(transform);
            PlayerManager.Instance.RespawnPlayer();
        }
    }
}