using Cinemachine;
using UnityEngine;

namespace FruitAdventure.Camera
{
    public class CameraShakeFX : MonoBehaviour
    {
        #region Variables

        [SerializeField] private CinemachineImpulseSource _impulse;
        [SerializeField] private Vector3 _shakeDirection;

        #endregion

        #region Public methods

        public void ScreenShake(int facingDir)
        {
            _impulse.m_DefaultVelocity = new Vector3(_shakeDirection.x * facingDir, _shakeDirection.y);
            _impulse.GenerateImpulse();
        }

        #endregion
    }
}