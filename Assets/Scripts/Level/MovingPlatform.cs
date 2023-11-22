using DG.Tweening;
using UnityEngine;

namespace FruitAdventure.Level
{
    public class MovingPlatform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Vector3 _startPoint;
        [SerializeField] private Vector3 _endPoint;
        [SerializeField] private float _moveDuration = 3;
        [SerializeField] private float _moveDelay = 1;

        [SerializeField] private bool _isLoop;
        [SerializeField] private bool _isFastMoveToStart;
        [SerializeField] private bool _needToComeBack;

        private Tween _tween;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            transform.position = _startPoint;
        }

        private void Start()
        {
            Move();
        }

        private void OnDestroy()
        {
            _tween?.Kill();
            _tween = null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_startPoint, 0.3f);
            Gizmos.DrawSphere(_endPoint, 0.3f);
            Gizmos.DrawLine(_startPoint, _endPoint);
        }

        #endregion

        #region Private methods

        private void Move()
        {
            _tween?.Kill();

            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_moveDelay);
            sequence.Append(transform.DOMove(_endPoint, _moveDuration));

            if (_needToComeBack)
            {
                sequence.AppendInterval(_moveDelay);
                if (_isFastMoveToStart)
                {
                    sequence.Append(transform.DOMove(_startPoint, 0));
                }
                else
                {
                    sequence.Append(transform.DOMove(_startPoint, _moveDuration));
                }
            }

            if (_isLoop)
            {
                sequence.SetLoops(-1);
            }

            sequence.SetUpdate(UpdateType.Fixed);
            _tween = sequence;
        }

        #endregion
    }
}