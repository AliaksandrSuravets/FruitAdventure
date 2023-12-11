using FruitAdventure.Enemys;
using UnityEngine;

namespace FruitAdventure.PlayerFolder
{
    public class PlayerDamage : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _enemyCheck;
        [SerializeField] private float _enemyCheckRadius;
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private Player _player;
        [SerializeField] private Rigidbody2D _rb;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Collider2D[] hitedColliders =
                Physics2D.OverlapCircleAll(_enemyCheck.position, _enemyCheckRadius, _enemyMask);

            foreach (Collider2D enemy in hitedColliders)
            {
                if (enemy.TryGetComponent(out Enemy enemys))
                {
                    if (_rb.velocity.y < 0)
                    {
                        enemys.Damage();
                        _player.JumpEnemyHeader();
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_enemyCheck.position, _enemyCheckRadius);
        }

        #endregion
    }
}