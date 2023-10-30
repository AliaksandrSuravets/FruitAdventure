using System;
using FruitAdventure.PlayerFolder;
using Unity.VisualScripting;
using UnityEngine;

namespace FruitAdventure.Enemys
{
    public class Enemy : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            Player player = other.collider.GetComponent<Player>();
            if (player == null)
            {
                return;
            }

            if (!player.IsKnocked)
            {
                player.KnockBack();
            }
        }

        #endregion

        #region Public methods

        public void Damage()
        {
            Debug.Log("DAMAGE ENEMY");
        }

        #endregion
    }
}