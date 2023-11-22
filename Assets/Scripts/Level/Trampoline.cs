using System;
using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Level
{
    public class Trampoline : MonoBehaviour
    {
        #region Variables

        private static readonly int Activate = Animator.StringToHash("Activate");

        [SerializeField] private float _pushForce;
        [SerializeField] private Animator _animator;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                _animator.SetTrigger(Activate);
                player.Push(_pushForce);
            }
        }

        #endregion
    }
}