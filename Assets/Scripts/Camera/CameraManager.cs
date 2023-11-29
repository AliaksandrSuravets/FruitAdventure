using System;
using FruitAdventure.PlayerFolder;
using UnityEngine;
using Cinemachine;

namespace FruitAdventure.Camera
{
    public class CameraManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _myCamera;
        [SerializeField] private PolygonCollider2D _cd;
        [SerializeField] private Color _corlorGizmo;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _myCamera.GetComponent<CinemachineVirtualCamera>().Follow = PlayerManager.Instance.CurrentPlayer.transform;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _corlorGizmo;
            Gizmos.DrawWireCube(_cd.bounds.center, _cd.bounds.size);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null)
            {
                _myCamera.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null)
            {
                _myCamera.SetActive(false);
            }
        }

        #endregion
    }
}