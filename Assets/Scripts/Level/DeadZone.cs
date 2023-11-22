using System;
using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Level
{
    public class DeadZone : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                PlayerManager.Instance.MoveToCheckPoint();
            }
        }

        #endregion
    }
}