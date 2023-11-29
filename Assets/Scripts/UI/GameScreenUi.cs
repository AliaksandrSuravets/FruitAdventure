using System;
using FruitAdventure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FruitAdventure.UI
{
    public class GameScreenUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private TMP_Text _scoreText;

        private void Start()
        {
            GameService.Instance.ChangeLevelNumber(SceneManager.GetActiveScene().buildIndex);
        }

        private void Update()
        {
            _timerText.text = $"Время: {GameService.Instance.Timer:00}";
            _scoreText.text = ($"Фруктов: {GameService.Instance.Score}");
        }
    }
}