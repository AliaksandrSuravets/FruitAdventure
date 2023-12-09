using FruitAdventure.Services;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace FruitAdventure.UI
{
    public class MainMenuUi : MonoBehaviour
    {
        private void Start()
        {
            AudioService.Instance.PlayBGM(0);
        }
        

        public void SwitchMenuTo(GameObject uiMenu)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                
            }
            
            AudioService.Instance.PlaySFX(4);
            
            uiMenu.SetActive(true);
        }
        
        
    }
}
