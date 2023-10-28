using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Traps
{
    public class FireTrap : Trap
    {
        #region Variables

        private const string TrapOn = "TrapOn";

        [SerializeField] private Animator _anim;
        [SerializeField] private float _cooldown;
        private bool _inCollider;
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
            ApplyDamage();
            PlayAnim();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _inCollider = false;
            }
        }

        #endregion

        #region Protected methods

        protected override void Aplly(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _inCollider = true;
            }
        }

        #endregion

        #region Private methods

        private void ApplyDamage()
        {
            if (_isWorking && _inCollider)
            {
                _inCollider = false;
                Player player = FindObjectOfType<Player>();
                if (!player.IsKnocked)
                {
                    player.KnockBack();
                }
            }
        }

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