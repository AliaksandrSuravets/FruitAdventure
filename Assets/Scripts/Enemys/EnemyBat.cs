using FruitAdventure.PlayerFolder;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FruitAdventure.Enemys
{
    public class EnemyBat : Enemy
    {
        #region Variables

        private static readonly int CanBeAggresive = Animator.StringToHash("canBeAggresive");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] [BoxGroup("Bat")] private Transform[] _idlePoint;
        [SerializeField] [BoxGroup("Bat")] private float _checkRadius;
        [SerializeField] [BoxGroup("Bat")] private LayerMask _whatIsPlayer;
        [SerializeField] [BoxGroup("Bat")] private float _speed;
        [SerializeField] [BoxGroup("Bat")] private float _idleTime;

        private bool _aggresive;

        [ShowInInspector] [ReadOnly]
        private bool _canBeAggresive = true;
        private float _defaultSpeed;

        [ShowInInspector] [ReadOnly]
        private Vector2 _destination;
        private float _idleTimeCounter;
        private Transform _player;
        private bool _playerDetected;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _player = PlayerManager.Instance.CurrentPlayer.transform;
            _defaultSpeed = _speed;
            _destination = _idlePoint[0].position;
            transform.position = _idlePoint[0].position;
        }

        private void Update()
        {
            _animator.SetBool(CanBeAggresive, _canBeAggresive);
            _animator.SetFloat(Speed, _speed);

            _idleTimeCounter -= Time.deltaTime;
            if (_idleTimeCounter > 0 || !CanMove)
            {
                return;
            }

            _playerDetected = Physics2D.OverlapCircle(transform.position, _checkRadius, _whatIsPlayer);

            if (_playerDetected && !_aggresive && _canBeAggresive)
            {
                _aggresive = true;
                _canBeAggresive = false;
                _destination = _player.transform.position;
            }

            if (_aggresive)
            {
                transform.position = Vector2.MoveTowards(transform.position, _destination,
                    _speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, _destination) < .1f)
                {
                    _aggresive = false;
                    int i = Random.Range(0, +_idlePoint.Length);
                    _destination = _idlePoint[i].position;
                    _speed *= .5f;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _destination,
                    _speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, _destination) < .1f)
                {
                    if (!_canBeAggresive)
                    {
                        _idleTimeCounter = _idleTime;
                    }

                    _canBeAggresive = true;
                    _speed = _defaultSpeed;
                }
            }

            FlipController();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _checkRadius);
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

        #region Private methods

        private void FlipController()
        {
            if (_facingDirection == -1 && transform.position.x < _destination.x)
            {
                Flip();
            }
            else if (_facingDirection == 1 && transform.position.x > _destination.x)
            {
                Flip();
            }
        }

        #endregion
    }
}