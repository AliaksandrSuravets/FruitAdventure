using System;
using FruitAdventure.PlayerFolder;
using Unity.VisualScripting;
using UnityEngine;

namespace FruitAdventure.Enemys
{
    public class Enemy : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _animator;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private float _wallCheckDistance;
        [SerializeField] private Transform _startCheckGround;
        [SerializeField] private Transform _startCheckWall;

        private protected int _facingDirection = -1;
        private protected bool _groundDetected;
        private protected bool _wallDetected;

        #endregion

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

        private void OnDrawGizmos()
        {
            Vector2 positionWall = _startCheckWall.position;
            Vector2 positionGround = _startCheckGround.position;
            Gizmos.DrawLine(positionWall,
                new Vector2(positionWall.x,
                    positionWall.y - _groundCheckDistance));
            Gizmos.DrawLine(positionGround,
                new Vector2(positionGround.x + _wallCheckDistance * _facingDirection,
                    positionGround.y));
        }

        #endregion

        #region Public methods

        public void Damage()
        {
            Debug.Log("DAMAGE ENEMY");
        }

        #endregion

        #region Protected methods

        protected virtual void CollisionChecks()
        {
            Vector2 positionWall = _startCheckWall.position;
            Vector2 positionGround = _startCheckGround.position;
            _groundDetected = Physics2D.Raycast(positionWall, Vector2.down, _groundCheckDistance,
                _whatIsGround);
            _wallDetected = Physics2D.Raycast(positionGround, Vector2.right * _facingDirection,
                _wallCheckDistance,
                _whatIsGround);
        }

        protected virtual void Flip()
        {
            _facingDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        #endregion
    }
}