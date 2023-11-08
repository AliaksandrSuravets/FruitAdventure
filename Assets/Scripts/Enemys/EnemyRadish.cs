using System;
using System.Collections;
using System.Collections.Generic;
using FruitAdventure.Enemys;
using UnityEngine;

namespace FruitAdventure
{
    public class EnemyRadish : Enemy
    {
        #region Variables

        [Header("EnemyRadish")]
        [SerializeField] private float _speed;
        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private Rigidbody2D _rb;
        private bool _canDestroy;
        private float _idleTimeCounter;
        private bool _isFly = true;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _animator.SetBool("isFly", _isFly);
            if (!_isFly && _wallDetected && CanMove)
            {
                _animator.SetFloat("Moving", Math.Abs(_rb.velocity.magnitude));
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
                if (!_wallDetected || _groundDetected)
                {
                    _idleTimeCounter = _idleTime;
                    Flip();
                }
            }

            CollisionChecks();
        }

        #endregion

        #region Public methods

        public override void Damage()
        {
            base.Damage();
            if (!_isFly)
            {
                CanMove = false;
                _animator.SetTrigger("Hit");
            }

            if (_isFly)
            {
                _isFly = false;
                _canDestroy = true;
                _rb.gravityScale = 5;
            }
        }

        public void DestroyMe()
        {
            if (_canDestroy)
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}