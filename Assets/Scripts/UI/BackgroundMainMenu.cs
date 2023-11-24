using UnityEngine;

namespace FruitAdventure.UI
{
    public class BackgroundMainMenu : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private Vector2 _speed;
        
        
        // Update is called once per frame
        void Update()
        {
            _mesh.material.mainTextureOffset += _speed * Time.deltaTime;
        }
    }
}
