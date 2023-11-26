using System;
using TMPro;
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

        [SerializeField] private bool[] _levelOpen;
        
        
        #endregion

        #region Unity lifecycle

        private void Start()
        {
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {

                if (!_levelOpen[i])
                {
                    return;
                }
                string sceneName = "Level" + i;
                string sceneNameText = "Level " + i;
                GameObject newButton = Instantiate(_levelButton, _levelButtonParent);
                newButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = sceneNameText;
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