using UnityEngine;

namespace FruitAdventure.UI
{
    public class BackgroundMainMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private Vector2 _speed;

        #endregion

        #region Unity lifecycle

        // Update is called once per frame
        private void Update()
        {
            _mesh.material.mainTextureOffset += _speed * Time.deltaTime;
        }

        #endregion
    }
}