using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rb;

    #endregion

    #region Unity lifecycle

    public void Update()
    {
        Move();
    }

    #endregion

    #region Private methods

    private void Move()
    {
        float movingInput = Input.GetAxisRaw("Horizontal");
        
        _rb.velocity = new Vector2(_moveSpeed * movingInput, _rb.velocity.y);
    }

    #endregion
}