using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Traps
{
    public class Spike : Trap
    {
        #region Protected methods

        protected override void Aplly(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponent<Player>();
                if (!player.IsKnocked)
                {
                    player.KnockBack();
                }
            }
        }

        #endregion
    }
}