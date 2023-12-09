using System;
using FruitAdventure.PlayerFolder;
using FruitAdventure.Services;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FruitAdventure.UI
{
    public class SkinSelection : MonoBehaviour
    {
        #region Variables

        private static readonly int SkinId = Animator.StringToHash("SkinId");

        [SerializeField] private Animator _animator;
        [SerializeField] private int _skinId;

        [SerializeField] private bool[] _skinPurchased;
        [SerializeField] private int[] _priceForSkin;

        [SerializeField] private GameObject _buyButton;
        [SerializeField] private TMP_Text _textPrice;

        [SerializeField] private GameObject _equipButton;
        [SerializeField] private TMP_Text _bankText;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _skinPurchased[0] = true;
            GameService.Instance.OnChangeScore += OnChangeScore;
            _bankText.text = $"Фруктов: {GameService.Instance.Score}";
        }

        private void OnDestroy()
        {
            GameService.Instance.OnChangeScore -= OnChangeScore;
        }

        #endregion

        #region Public methods

        public void Buy()
        {
            if (EnoughMoney())
            {
                AudioService.Instance.PlaySFX(5);
                GameService.Instance.ChangeScore(-_priceForSkin[_skinId]);
                PlayerPrefs.SetInt($"SkinPurchased{_skinId}", 1);
                _skinPurchased[_skinId] = true;
                SetUpSkinInfo();
            }
            AudioService.Instance.PlaySFX(6);
        }

        public void Equip()
        {
            PlayerManager.Instance.SetSkinId(_skinId);
        }

        public void NextSkin()
        {
            AudioService.Instance.PlaySFX(4);
            _skinId++;
            if (_skinId > 3)
            {
                _skinId = 0;
            }

            SetUpSkinInfo();
        }

        public void PreviousSkin()
        {
            AudioService.Instance.PlaySFX(4);
            _skinId--;
            if (_skinId < 0)
            {
                _skinId = 3;
            }

            SetUpSkinInfo();
        }

        #endregion

        #region Private methods

        private bool EnoughMoney()
        {
            return GameService.Instance.Score > _priceForSkin[_skinId];
        }

        private void OnChangeScore()
        {
            _bankText.text = $"Фруктов: {GameService.Instance.Score}";
        }

        private void SetUpSkinInfo()
        {
            _skinPurchased[0] = true;
            for (int i = 1; i < _skinPurchased.Length; i++)
            {
                bool isSkinUnlocked = PlayerPrefs.GetInt($"SkinPurchased{_skinId}") == 1;
                _skinPurchased[i] = isSkinUnlocked;
            }

            _buyButton.SetActive(!_skinPurchased[_skinId]);
            _equipButton.SetActive(_skinPurchased[_skinId]);
            if (!_skinPurchased[_skinId])
            {
                _textPrice.text = $"Price : {_priceForSkin[_skinId]}";
            }

            _animator.SetInteger(SkinId, _skinId);
        }

        #endregion
    }
}