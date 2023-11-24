using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FruitAdventure.Services
{
    public class LevelService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _levelButton;
        [SerializeField] private Transform _levelButtonParent;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string sceneName = "Level" + i;

                GameObject newButton = Instantiate(_levelButton, _levelButtonParent);
                newButton.AddComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
            }
        }

        #endregion

        #region Public methods

        public void LoadLevel(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        #endregion
    }
}