using System;
using System.Collections;
using FruitAdventure.Enemys;
using FruitAdventure.PlayerFolder;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

namespace FruitAdventure
{
    public class BlueBird : Enemy
    {
        #region Variables

        [Header("EnemyBlueBird")]
        [SerializeField] private float _speed;
        [SerializeField] private float _idleTime = 2f;
        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private Transform[] _movePoints;
        [SerializeField] private float _timeToNewMove;

        [SerializeField] private int _currentPoint;

        private float _idleTimeCounter;
        private bool _isGoingForward = true;
        private bool _isWorking = true;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            MovingToPoint();
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

        private IEnumerator Coldawn()
        {
            _isWorking = false;
            yield return new WaitForSeconds(_timeToNewMove);

            if (_currentPoint == 0)
            {
                _isGoingForward = true;
            }

            if (_isGoingForward)
            {
                _currentPoint++;
                Flip();
            }
            else
            {
                _currentPoint--;
            }

            _isWorking = true;
            
            if (_currentPoint >= _movePoints.Length)
            {
                _currentPoint = _movePoints.Length - 1;
                _isGoingForward = false;
            }
        }
        
        private void MovingToPoint()
        {
            if (!_isWorking || !CanMove)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, _movePoints[_currentPoint].position,
                _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _movePoints[_currentPoint].position) < 0.15f)
            {
                StartCoroutine(Coldawn());
            }
        }

        #endregion
    }
}