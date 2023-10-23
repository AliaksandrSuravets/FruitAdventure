using System;
using UnityEngine;

namespace FruitAdventure.Trap
{
    public class FireTrap : Trap
    {
        #region Variables

        private const string TrapOn = "TrapOn";

        [SerializeField] private Animator _anim;
        [SerializeField] private float _cooldown;
        private bool _isWorking;

        private float _timeForWorking;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _timeForWorking = _cooldown;
        }

        private void Update()
        {
            ChangeFireWorkingWithCooldown();
            PlayAnim();
        }

        #endregion

        #region Protected methods

        protected override void Aplly(Collider2D other)
        {
            if (other.CompareTag("Player") && _isWorking)
            {
                Debug.Log("DAMAGE FIRE");
            }
        }

        #endregion

        #region Private methods

        private void ChangeFireWorkingWithCooldown()
        {
            if (Time.time > _timeForWorking)
            {
                _timeForWorking += _cooldown;
                FireSwitch();
            }
        }

        private void FireSwitch()
        {
            _isWorking = !_isWorking;
        }

        private void PlayAnim()
        {
            _anim.SetBool(TrapOn, _isWorking);
        }

        #endregion
    }
}