using FruitAdventure.Services;
using UnityEngine;

namespace FruitAdventure.PlayerFolder
{
    public class PlayerManager : MonoBehaviour
    {
        #region Variables

        public static PlayerManager Instance;

        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _respawnPoint;

        #endregion

        #region Properties

        public int ChoosenSkinID { get; private set; }

        public Player CurrentPlayer { get; private set; }

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

        public void MoveToCheckPoint()
        {
            AudioService.Instance.PlaySFX(0);
            CurrentPlayer.enabled = false;
            CurrentPlayer.transform.position = _respawnPoint.position;
            CurrentPlayer.enabled = true;
        }

        public void RespawnPlayer()
        {
            GameService.Instance.SetTimerToZero();
            if (CurrentPlayer == null)
            {
                AudioService.Instance.PlaySFX(11);
                CurrentPlayer = Instantiate(_playerPrefab, _respawnPoint.position, Quaternion.identity);
            }
        }

        public void SetRespawnPoint(Transform point)
        {
            _respawnPoint = point;
        }

        public void SetSkinId(int Value)
        {
            ChoosenSkinID = Value;
        }

        #endregion
    }
}