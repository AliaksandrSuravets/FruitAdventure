using UnityEngine;

namespace FruitAdventure.Enemys
{
    public class EnemyBee : Enemy
    {
        #region Variables

        [Header("Bee")]
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _startBulletPosition;
        [SerializeField] private float _timeForShoot;
        [SerializeField] private bool _facingRight;

        private float _shootTimeCounter;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            if (_facingRight)
            {
                Flip();
            }
        }

        private void Update()
        {
            _shootTimeCounter -= Time.deltaTime;
            if (_shootTimeCounter <= 0)
            {
                _shootTimeCounter = _timeForShoot;
                Attack();
            }
        }

        #endregion

        #region Public methods

        public void CreateBullet()
        {
            Bullet newBullet = Instantiate(_bullet, _startBulletPosition.transform.position,
                _startBulletPosition.transform.rotation);
            newBullet.SetUpSpeed(0, -1);
        }

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

        #region Private methods

        private void Attack()
        {
            _animator.SetTrigger("Attack");
        }

        #endregion
    }
}