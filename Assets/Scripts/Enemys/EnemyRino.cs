using System;
using System.Collections;
using System.Collections.Generic;
using FruitAdventure.Enemys;
using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure
{
    public class EnemyRino : Enemy
    {
        #region Variables

        [Header("EnemyRino")]
        [SerializeField] private float _speed;
        [SerializeField] private float _sppedAggresiv;
        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private float _shockTime;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private LayerMask _whatToIgnore;

        private float _idleTimeCounter;
        private bool _invincible;
        private bool _isAggresive;

        private RaycastHit2D _playerDetected;
        private float _shockTimeCounter;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _invincible = true;
        }

        private void Update()
        {
            _animator.SetFloat("Moving", Math.Abs(_rb.velocity.magnitude));

            Vector2 position = _startCheckGround.position;
            _playerDetected = Physics2D.Raycast(position, Vector2.right * _facingDirection, 20,
                ~_whatToIgnore);

            if (_playerDetected.collider.GetComponent<Player>() != null)
            {
                _isAggresive = true;
            }

            if (!_isAggresive)
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

                if (!_wallDetected || _groundDetected)
                {
                    _idleTimeCounter = _idleTime;
                    Flip();
                }
            }
            else
            {
                _rb.velocity = new Vector2(_sppedAggresiv * _facingDirection, _rb.velocity.y);
                if (_groundDetected)
                {
                    if (_invincible)
                    {
                        _invincible = false;
                        _shockTimeCounter = _shockTime;
                    }

                    if (_shockTimeCounter <= 0)
                    {
                        _invincible = true;
                        Flip();
                        _isAggresive = false;
                    }
                }

                _shockTimeCounter -= Time.deltaTime;
            }

            _animator.SetBool("isHitWall", _invincible);

            CollisionChecks();
        }

        #endregion

        #region Public methods

        public override void Damage()
        {
            base.Damage();
            _animator.SetTrigger("Hit");
        }

        public void DestroyMe()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}