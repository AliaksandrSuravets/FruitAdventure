using FruitAdventure.UI;
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
            _levelOpen[1] = true;
            LoadNewGame();
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string sceneName = "Level" + i;
                string sceneNameText = "Уровень " + i;
                GameObject newButton = Instantiate(_levelButton, _levelButtonParent);
                newButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = sceneNameText;
                newButton.GetComponent<ButtonLevel>().SetBestTimeText(i);

                if (!_levelOpen[i])
                {
                    newButton.GetComponent<Button>().enabled = false;
                }
            }
        }

        #endregion

        #region Public methods

        public void LoadLevel(string sceneName)
        {
            AudioService.Instance.PlaySFX(4);
            SceneManager.LoadScene(sceneName);
        }

        #endregion

        #region Private methods

        private void LoadNewGame()
        {
            AudioService.Instance.PlaySFX(4);
            for (int i = 2; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                bool isUnlocked = PlayerPrefs.GetInt($"Level{i}Unlocked") == 1;
                if (!isUnlocked)
                {
                    PlayerPrefs.SetInt($"Level{i}Unlocked", 0);
                }

                _levelOpen[i] = isUnlocked;
            }
        }

        #endregion
    }
}