using UnityEngine;

namespace FruitAdventure.PlayerFolder
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private const string FumpFall = "yVelocity";
        private const string isBoolKnocked = "isBoolKnocked";
        private const string isGrounded = "isGrounded";
        private const string isKnocked = "isKnocked";
        private const string isWallSliding = "isWallSliding";
        private const string Walk = "Walk";
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void ChangeAnimSkin(int skinIndex)
        {
            for (int i = 0; i < _animator.layerCount; i++)
            {
                _animator.SetLayerWeight(i, 0);
            }

            _animator.SetLayerWeight(skinIndex, 1);
        }

        public void SetIsBoolKnocked(bool variable)
        {
            _animator.SetBool(isBoolKnocked, variable);
        }

        public void SetIsGrouded(bool variable)
        {
            _animator.SetBool(isGrounded, variable);
        }

        public void SetIsKnocked()
        {
            _animator.SetTrigger(isKnocked);
        }

        public void SetisWallSliding(bool variable)
        {
            _animator.SetBool(isWallSliding, variable);
        }

        public void SetJumpFall(float variable)
        {
            _animator.SetFloat(FumpFall, variable);
        }

        public void SetWalk(float variable)
        {
            _animator.SetFloat(Walk, variable);
        }

        #endregion
    }
}