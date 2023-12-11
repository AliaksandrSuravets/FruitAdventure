using FruitAdventure.PlayerFolder;
using UnityEngine;

namespace FruitAdventure.Respawn
{
    public class CheckPoint : MonoBehaviour
    {
        #region Variables

        private static readonly int CheckFlag = Animator.StringToHash("CheckFlag");

        [SerializeField] private Animator _animator;

        private bool _isCheck;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            _isCheck = true;
            _animator.SetBool(CheckFlag, _isCheck);
            PlayerManager.Instance.SetRespawnPoint(transform);
        }

        #endregion
    }
}