using FruitAdventure.Services;
using FruitAdventure.UI;
using UnityEngine;

namespace FruitAdventure.Respawn
{
    public class EndPoint : MonoBehaviour
    {
        #region Variables

        private static readonly int Active = Animator.StringToHash("Active");
        [SerializeField] private Animator _animator;
        [SerializeField] private GameScreenUi _gameScreenUi;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            AudioService.Instance.PlaySFX(2);

            Destroy(other.gameObject);
            GameService.Instance.SaveBestTime();
            GameService.Instance.SaveLevelInfo();
            _animator.SetTrigger(Active);
            _gameScreenUi.OnLevelFinished();
        }

        #endregion
    }
}