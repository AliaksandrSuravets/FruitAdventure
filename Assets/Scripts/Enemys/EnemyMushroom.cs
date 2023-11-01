using System;
using System.Collections;
using System.Collections.Generic;
using FruitAdventure.Enemys;
using UnityEngine;

namespace FruitAdventure
{
    public class EnemyMushroom : Enemy
    {
        #region Variables

        [Header("EnemyMushroom")]
        [SerializeField] private float _speed;
        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private Rigidbody2D _rb;

        private float _idleTimeCounter;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_idleTimeCounter <= 0)
            {
                _rb.velocity = new Vector2(_speed * _facingDirection, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = new Vector2(0, 0);
            }

            _idleTimeCounter -= Time.deltaTime;

            CollisionChecks();
            if (_wallDetected || !_groundDetected)
            {
                _idleTimeCounter = _idleTime;
                Flip();
            }
        }

        #endregion
    }
}