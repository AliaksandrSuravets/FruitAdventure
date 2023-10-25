using UnityEngine;

namespace FruitAdventure.Traps.SpikedBall
{
    public class SpikedBallTrap : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _pushDirection;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.AddForce(_pushDirection, ForceMode2D.Impulse);
        }

        #endregion
    }
}