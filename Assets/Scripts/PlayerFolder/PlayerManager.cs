using System;
using UnityEngine;
using UnityEngine.UIElements;

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

        public Player CurrentPlayer { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region Public methods

        public void RespawnPlayer()
        {
            if (CurrentPlayer == null)
            {
                CurrentPlayer = Instantiate(_playerPrefab, _respawnPoint.position, Quaternion.identity);
            }
        }

        public void SetRespawnPoint(Transform point)
        {
            _respawnPoint = point;
        }

        #endregion
    }
}