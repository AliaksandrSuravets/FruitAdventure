using System.Collections.Generic;
using UnityEngine;

namespace FruitAdventure.Level
{
    public class ParentChanger : MonoBehaviour
    {
        #region Variables

        private readonly Dictionary<Collider2D, Transform> _baseTransformByColliders = new ();

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            _baseTransformByColliders.Add(other, other.transform.parent);
            other.transform.SetParent(transform);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Transform parent = _baseTransformByColliders[other];
            _baseTransformByColliders.Remove(other);
            other.transform.SetParent(parent);
        }

        #endregion
    }
}