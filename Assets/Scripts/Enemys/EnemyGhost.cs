using UnityEngine;

namespace FruitAdventure.Enemys
{
    public class EnemyGhost : Enemy
    {
        #region Variables

        [Header("EnemyGhost")]
        [SerializeField] private float _speed;
        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private Rigidbody2D _rb;

        private float _idleTimeCounter;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_idleTimeCounter <= 0 && CanMove)
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

        #endregion

        #region Public methods

        public override void Damage()
        {
            base.Damage();
            CanMove = false;
            _animator.SetTrigger("Hit");
        }

        public void DestroyMe()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}