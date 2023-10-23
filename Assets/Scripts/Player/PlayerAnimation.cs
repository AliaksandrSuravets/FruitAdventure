using UnityEngine;

namespace FruitAdventure.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private const string Walk = "Walk";
        private const string FumpFall = "yVelocity";
        private const string isGrounded = "isGrounded";
        private const string isWallSliding = "isWallSliding";
        public void SetWalk(float variable)
        {
            _animator.SetFloat(Walk, variable);
        }

        public void SetIsGrouded(bool variable)
        {
            _animator.SetBool(isGrounded, variable);
        }
    
        public void SetJumpFall(float variable)
        {
            _animator.SetFloat(FumpFall, variable);
        }
    
        public void SetisWallSliding(bool variable)
        {
            _animator.SetBool(isWallSliding, variable);
        }
    
    }
}