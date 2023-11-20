using UnityEngine;

namespace FruitAdventure.Respawn
{
    public class EndPoint : MonoBehaviour
    {
        #region Variables

        private static readonly int Active = Animator.StringToHash("Active");
        [SerializeField] private Animator _animator;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            _animator.SetTrigger(Active);
        }

        #endregion
    }
}