using FruitAdventure.Services;
using UnityEngine;

namespace FruitAdventure.UI
{
    public class MainMenuUi : MonoBehaviour
    {
        #region Variables

        [SerializeField] private VolumeControllerUI[] _volumeController;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            foreach (VolumeControllerUI volumeController in _volumeController)
            {
                volumeController.SetUpVolume();
            }

            AudioService.Instance.PlayBGM(0);
        }

        #endregion

        #region Public methods

        public void SwitchMenuTo(GameObject uiMenu)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            AudioService.Instance.PlaySFX(4);

            uiMenu.SetActive(true);
        }

        #endregion
    }
}