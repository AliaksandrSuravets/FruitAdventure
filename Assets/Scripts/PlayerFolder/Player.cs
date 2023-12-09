using System;
using FruitAdventure.Camera;
using FruitAdventure.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FruitAdventure.PlayerFolder
{
    public class Player : MonoBehaviour
    {
        #region Variables

        private const float _powerSlide = 0.1f;

        private const float TimeForWaitCanMove = 0.5f;

        [Header("Move")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _doubleJumpForce;
        [SerializeField] private Rigidbody2D _rb;
        [Header("Ground")]
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private float _groundCheckDistance;
        [Header("Wall")]
        [SerializeField] private LayerMask _whatIsWall;
        [SerializeField] private float _wallCheckDistance;
        [SerializeField] private int _powerWallJump;
        [Header("Animation")]
        [SerializeField] private PlayerAnimation _playerAnimation;
        [Header("Jump")]
        [SerializeField] private float _cayoteJumpTime;
        [Header("Knockback info")]
        [SerializeField] private Vector2 _knockbackDirection;
        [SerializeField] private float _knockbackTime;
        [SerializeField] private CameraShakeFX _cameraShakeFX;

        private bool _canDoubleJump;
        private bool _canHaveCayoteJump;
        private bool _canMove = true;

        private float _cayoteJumpCounter;
        //private bool _canWallSlide = true;
        private int _facingDirection = 1;
        private bool _facingRight = true;

        private bool _isKnocked;
        private bool _isWallSliding;
        private float _movingInput;

        #endregion

        #region Properties

        public bool IsKnocked => _isKnocked;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerAnimation.ChangeAnimSkin(PlayerManager.Instance.ChoosenSkinID);
        }

        public void Update()
        {
            if (_isKnocked)
            {
                return;
            }

            PlayAnimation();
            _cayoteJumpCounter -= Time.deltaTime;
            CheckFlip();
            WallSlide();
            Move();
            Jump();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position,
                new Vector3(transform.position.x, transform.position.y - _groundCheckDistance));

            Gizmos.DrawLine(transform.position,
                new Vector3(transform.position.x + _wallCheckDistance * _facingDirection, transform.position.y));
        }

        #endregion

        #region Public methods

        public void JumpEnemyHeader()
        {
            AudioService.Instance.PlaySFX(1);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }

        public void KnockBack()
        {
            AudioService.Instance.PlaySFX(9);
            _isKnocked = true;
            _cameraShakeFX.ScreenShake(-_facingDirection);
            _playerAnimation.SetIsKnocked();
            _playerAnimation.SetIsBoolKnocked(_isKnocked);
            _rb.velocity = new Vector2(_knockbackDirection.x * -_facingDirection, _knockbackDirection.y);
            Invoke("CancelKnockback", _knockbackTime);
        }

        public void Push(float pushForce)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, pushForce);
        }

        #endregion

        #region Private methods

        private void CancelKnockback()
        {
            _isKnocked = false;
            _playerAnimation.SetIsBoolKnocked(_isKnocked);
        }

        private void CanMove()
        {
            if (CheckGrounded() || _movingInput != 0)
            {
                _canMove = true;
            }
        }

        private void CheckFlip()
        {
            if (_facingRight && _rb.velocity.x < -.1f)
            {
                Flip();
            }
            else if (!_facingRight && _rb.velocity.x > .1f)
            {
                Flip();
            }
        }

        private bool CheckGrounded()
        {
            bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _whatIsGround);
            return isGrounded;
        }

        private bool CheckWall()
        {
            bool isWall = Physics2D.Raycast(transform.position, Vector2.right * _facingDirection, _wallCheckDistance,
                _whatIsWall);
            return isWall;
        }

        private void Flip()
        {
            _facingDirection = _facingDirection * -1;
            _facingRight = !_facingRight;
            transform.Rotate(0, 180, 0);
        }

        private void Jump()
        {
            if (CheckGrounded())
            {
                _canHaveCayoteJump = true;
            }
            else
            {
                if (_canHaveCayoteJump)
                {
                    _canHaveCayoteJump = false;
                    _cayoteJumpCounter = _cayoteJumpTime;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isWallSliding)
                {
                    AudioService.Instance.PlaySFX(12);
                    _canMove = false;
                    WallJump();
                    _canDoubleJump = true;
                }
                else if (CheckGrounded() || _cayoteJumpCounter > 0)
                {
                    AudioService.Instance.PlaySFX(3);
                    _canDoubleJump = true;
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                }
                else if (_canDoubleJump)
                {
                    AudioService.Instance.PlaySFX(3);
                    _canDoubleJump = false;
                    _rb.velocity = new Vector2(_rb.velocity.x, _doubleJumpForce
                    );
                }
            }
        }

        private void Move()
        {
            _movingInput = Input.GetAxisRaw("Horizontal");
            CanMove();
            if (_canMove)
            {
                _rb.velocity = new Vector2(_moveSpeed * _movingInput, _rb.velocity.y);
            }
        }

        private void PlayAnimation()
        {
            if (!_isKnocked)
            {
                _playerAnimation.SetIsGrouded(CheckGrounded());
                _playerAnimation.SetJumpFall(_rb.velocity.y);
                _playerAnimation.SetWalk(Math.Abs(_movingInput));
                _playerAnimation.SetisWallSliding(_isWallSliding);
            }
        }

        private void WallJump()
        {
            StartCoroutine("CanMove");
            _rb.velocity = new Vector2(_powerWallJump * -_facingDirection, _jumpForce);
        }

        private void WallSlide()
        {
            if (Input.GetAxisRaw("Vertical") != 0 || !CheckWall() || CheckWall() && CheckGrounded())
            {
                _isWallSliding = false;
                return;
            }

            if (CheckWall() && _rb.velocity.y < 0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * _powerSlide);
                _isWallSliding = true;
            }
        }

        #endregion
    }
}