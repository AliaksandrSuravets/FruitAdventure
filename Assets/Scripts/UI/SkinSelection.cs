using System;
using FruitAdventure.PlayerFolder;
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

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _skinPurchased[0] = true;
        }

        #endregion

        #region Public methods

        public void Buy()
        {
            _skinPurchased[_skinId] = true;
            SetUpSkinInfo();
        }

        public void Equip()
        {
            PlayerManager.Instance.ChoosenSkinID = _skinId;
        }

        public void NextSkin()
        {
            _skinId++;
            if (_skinId > 3)
            {
                _skinId = 0;
            }

            SetUpSkinInfo();
        }

        public void PreviousSkin()
        {
            _skinId--;
            if (_skinId < 0)
            {
                _skinId = 3;
            }

            SetUpSkinInfo();
        }

        #endregion

        #region Private methods

        private void SetUpSkinInfo()
        {
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