using UnityEngine;

namespace FruitAdventure.Traps.SpikedBall
{
    public class SpikedBallTrapDamage : Trap
    {
        #region Protected methods

        protected override void Aplly(Collider2D other)
        {
            if (other.CompareTag("Player")) { }
        }

        #endregion
    }
}