using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FruitAdventure
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
            Debug.Log($"Лучшее время: {bestTime:00}  for {_levelIndex}");
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