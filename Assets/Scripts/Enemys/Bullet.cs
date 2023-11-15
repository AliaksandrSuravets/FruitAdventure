using System;
using FruitAdventure.PlayerFolder;
using FruitAdventure.Traps;
using UnityEngine;

namespace FruitAdventure.Enemys
{
    public class Bullet : Trap
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        private float _xSpeed;
        private float _ySpeed;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _rb.velocity = new Vector2(_xSpeed * _speed, _ySpeed);
        }

        #endregion

        #region Public methods

        public void SetUpSpeed(float x, float y)
        {
            _xSpeed = x;
            _ySpeed = y;
        }

        #endregion

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

            Destroy(gameObject);
        }

        #endregion
    }
}