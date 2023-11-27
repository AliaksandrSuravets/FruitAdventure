using System;
using UnityEngine;

namespace FruitAdventure.Services
{
    public class GameService : MonoBehaviour
    {
        #region Variables

        public static GameService Instance;

        #endregion

        #region Properties

        public int Score { get; private set; }

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

        #endregion

        #region Public methods

        public void ChangeScore(int Value)
        {
            Score += Value;
        }

        private void Start()
        {
            Score = PlayerPrefs.GetInt("Score");
        }

        #endregion
    }
}