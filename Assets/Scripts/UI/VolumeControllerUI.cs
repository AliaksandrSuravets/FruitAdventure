using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace FruitAdventure.UI
{
    public class VolumeControllerUI : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _mixerParametr;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Slider _slider;
        [SerializeField] private float _sliderMultiplier;

        #endregion

        #region Unity lifecycle

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(_mixerParametr, _slider.value);
        }

        #endregion

        #region Public methods

        public void SetUpVolume()
        {
            _slider.onValueChanged.AddListener(SliderValue);
            _slider.minValue = .001f;
            _slider.value = PlayerPrefs.GetFloat(_mixerParametr);
        }

        #endregion

        #region Private methods

        private void SliderValue(float value)
        {
            _audioMixer.SetFloat(_mixerParametr, Mathf.Log10(value) * _sliderMultiplier);
        }

        #endregion
    }
}