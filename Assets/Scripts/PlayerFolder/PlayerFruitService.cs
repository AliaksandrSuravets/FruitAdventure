using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FruitAdventure
{
    public class PlayerFruitService : MonoBehaviour
    {
        #region Variables

        public static PlayerFruitService Instance;
        [SerializeField] private int _fruits;

        #endregion

        #region Properties

        public int Fruits
        {
            get => _fruits;
            set => _fruits = value;
        }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region Public methods

        public void ChangeFruit(int value)
        {
            Debug.Log("ADD");
            _fruits += value;
        }

        #endregion
    }
}