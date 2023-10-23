using System;
using UnityEngine;

namespace FruitAdventure.Player
{
    public class Player : MonoBehaviour
    {
        #region Variables

        private const float _powerSlide = 0.1f;
        
        private const float TimeForWaitCanMove = 0.5f;
    
        [Header("Move")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
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

        private bool _canDoubleJump;
        private bool _canMove = true;
        //private bool _canWallSlide = true;
        private int _facingDirection = 1;
        private bool _facingRight = true;
        private bool _isWallSliding;
        private float _movingInput;

        #endregion

        #region Unity lifecycle

        public void Update()
        {
            PlayAnimation();
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

        #region Private methods

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isWallSliding)
                {
                    _canMove = false;
                    WallJump();
                }
                else if (CheckGrounded())
                {
                    _canDoubleJump = true;
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                }
                else if (_canDoubleJump)
                {
                    _canDoubleJump = false;
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
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
            _playerAnimation.SetIsGrouded(CheckGrounded());
            _playerAnimation.SetJumpFall(_rb.velocity.y);
            _playerAnimation.SetWalk(Math.Abs(_movingInput));
            _playerAnimation.SetisWallSliding(_isWallSliding);
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