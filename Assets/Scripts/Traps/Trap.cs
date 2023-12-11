using UnityEngine;

namespace FruitAdventure.Traps
{
    public abstract class Trap : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            Aplly(other);
        }

        #endregion

        #region Protected methods

        protected abstract void Aplly(Collider2D other);

        #endregion
    }
}