using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FruitAdventure
{
    public class WinScrren : MonoBehaviour
    {

        public void LoadMenu()
        {
            Debug.Log("WIN");
            SceneManager.LoadScene(0);
        }
      
    }
}
