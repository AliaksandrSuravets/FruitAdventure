using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Fruit
{
    public class FruitItem : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _score;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}