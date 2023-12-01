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

        private bool isPaused;

        [SerializeField] private GameObject _inGameUi;
        [SerializeField] private GameObject _pauseUi;
        [SerializeField] private GameObject _endLevelUi;

        private void Start()
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        private void Update()
        {
            _timerText.text = $"Время: {GameService.Instance.Timer:00}";
            _scoreText.text = ($"Фруктов: {GameService.Instance.Score}");

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CheckIfNotPaused();
            }
            
        }

        private bool CheckIfNotPaused()
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                SwitchMenuTo(_pauseUi);
                return true;
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1;
                SwitchMenuTo(_inGameUi);
                return false;
            }
        }
         
        public void SwitchMenuTo(GameObject uiMenu)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
            uiMenu.SetActive(true);
        }

        public void LoadMenu()
        {
            GameService.Instance.ChangeLevelNumber(0);
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void OnLevelFinished()
        {
            SwitchMenuTo(_endLevelUi);
        }
    }
}