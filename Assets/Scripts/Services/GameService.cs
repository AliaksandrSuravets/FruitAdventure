using System;
using UnityEngine;

namespace FruitAdventure.Services
{
    public class GameService : MonoBehaviour
    {
        #region Variables

        public static GameService Instance;

        #endregion

        #region Events

        public event Action OnChangeScore;

        #endregion

        #region Properties

        public bool IsStartTime { get; private set; }
        public int LevelNumber { get; private set; }

        public int Score { get; private set; }
        public float Timer { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Score = PlayerPrefs.GetInt("Score");
        }

        private void Update()
        {
            if (IsStartTime)
            {
                Timer += Time.deltaTime;
            }
        }

        #endregion

        #region Public methods

        public void ChangeIsStartTime(bool value)
        {
            IsStartTime = value;
        }

        public void ChangeLevelNumber(int value)
        {
            LevelNumber = value;
        }

        public void ChangeScore(int value)
        {
            Score += value;
            Debug.Log(Score);
            OnChangeScore?.Invoke();
            SaveScore();
        }

        public void SaveBestTime()
        {
            IsStartTime = false;
            float lastTime = PlayerPrefs.GetFloat("Level" + LevelNumber + "BestTime");

            if (Timer < lastTime || lastTime == 0)
            {
                PlayerPrefs.SetFloat("Level" + LevelNumber + "BestTime", Timer);
            }

            Debug.Log($"sdfsdf Лучшее время: {Timer}  for {LevelNumber} lastTime {lastTime}");
            Timer = 0;
        }

        public void SaveLevelInfo()
        {
            int nextLevelNumber = LevelNumber + 1;
            PlayerPrefs.SetInt("Level" + nextLevelNumber + "Unlocked", 1);
        }

        #endregion

        #region Private methods

        private void SaveScore()
        {
            PlayerPrefs.SetInt("Score", Score);
        }

        #endregion
    }
}