using System;
using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

namespace FruitAdventure.Traps
{
    public class SawTrap : Trap
    {
        #region Variables

        private const string SawOn = "SawOn";

        [SerializeField] private Animator _anim;
        [SerializeField] private Transform[] _movePoints;
        [SerializeField] private float _speed;
        [SerializeField] private float _timeToNewMove;

        private int _currentPoint;
        private bool _isWorking = true;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            PlayAnim();
            MovingToPoint();
            
        }

        #endregion

        #region Protected methods

        protected override void Aplly(Collider2D other)
        {
            if (other.CompareTag("Player")) { }
        }

        #endregion

        #region Private methods

        private IEnumerator Coldawn()
        {
            _isWorking = false;
            yield return new WaitForSeconds(_timeToNewMove);
            _currentPoint++;
            _isWorking = true;
            Flip(_currentPoint);
            if (_currentPoint >= _movePoints.Length)
            {
                _currentPoint = 0;
            }
        }

        private void Flip(int value)
        {
            if (value == 0 || value >= _movePoints.Length)
            {
                transform.localScale = new Vector3(1, transform.localScale.y * -1);
            }
        }

        private void MovingToPoint()
        {
            if (!_isWorking)
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

        private void PlayAnim()
        {
            _anim.SetBool(SawOn, _isWorking);
        }

        #endregion
    }
}