using UnityEngine;
using Random = UnityEngine.Random;

namespace FruitAdventure.Services
{
    public class AudioService : MonoBehaviour
    {
        #region Variables

        public static AudioService Instance;
        [SerializeField] private AudioSource[] _bgm;

        [SerializeField] private AudioSource[] _sfx;
        private int _bgmToPlay;

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

        private void Update()
        {
            if (!_bgm[_bgmToPlay].isPlaying)
            {
                _bgm[_bgmToPlay].Play();
            }
        }

        #endregion

        #region Public methods

        public void PlayBGM(int bgmToPlay)
        {
            _bgmToPlay = bgmToPlay;
            for (int i = 0; i < _bgm.Length; i++)
            {
                _bgm[i].Stop();
            }

            _bgm[_bgmToPlay].Play();
        }

        public void PlayRandomBGM()
        {
            _bgmToPlay = Random.Range(1, _bgm.Length);
            PlayBGM(_bgmToPlay);
        }

        public void PlaySFX(int sfxToPlay)
        {
            if (sfxToPlay <= _sfx.Length)
            {
                _sfx[sfxToPlay].pitch = Random.Range(0.85f, 1.15f);
                _sfx[sfxToPlay].Play();
            }
        }

        #endregion
    }
}