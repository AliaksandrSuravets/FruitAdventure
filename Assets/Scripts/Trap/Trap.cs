using System;
using UnityEngine;

namespace Trap
{
    public abstract class Trap : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Aplly(other);
        }

        protected abstract void Aplly(Collider2D other);
    }
    
}
