using TMPro;
using UnityEngine;

namespace FruitAdventure.UI
{
    public class ButtonLevel : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _bestTime;
        [SerializeField] private int _levelIndex;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            float bestTime = PlayerPrefs.GetFloat("Level" + _levelIndex + "BestTime");
            _bestTime.text = $"Лучшее время: {bestTime:00}";
        }

        #endregion

        #region Public methods

        public void SetBestTimeText(int levelIndex)
        {
            _levelIndex = levelIndex;
        }

        #endregion
    }
}