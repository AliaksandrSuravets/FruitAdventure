using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    [Header("Move")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rb;
    [Header("Ground")]
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundCheckDistance;
    [Header("Animation")]
    [SerializeField] private PlayerAnimation _playerAnimation;
    
    #endregion

    private bool _canDoubleJump;
    
    #region Unity lifecycle
    
    public void Update()
    {
        Move();
        Jump();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,
            new Vector3(transform.position.x, transform.position.y - _groundCheckDistance));
    }

    #endregion

    #region Private methods

    private bool CheckGrounded()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _whatIsGround);
        return isGrounded;
    }

    private void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        if (CheckGrounded())
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

    private void Move()
    {
        float movingInput = Input.GetAxisRaw("Horizontal");
        _playerAnimation.SetWalk(Math.Abs(movingInput));
        _rb.velocity = new Vector2(_moveSpeed * movingInput, _rb.velocity.y);
    }

    #endregion
}