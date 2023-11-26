using UnityEngine;
using UnityEngine.UI;
namespace FruitAdventure.UI
{
    public class MainMenuUi : MonoBehaviour
    {

        public void SwitchMenuTo(GameObject uiMenu)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                
            }
            
            uiMenu.SetActive(true);
        }
        
        
    }
}
