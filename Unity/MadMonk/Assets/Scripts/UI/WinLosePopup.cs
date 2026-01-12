using UnityEngine;

namespace Game.UI
{
    public class WinLosePopup : MonoBehaviour
    {
        [SerializeField] private GameObject win;
        [SerializeField] private GameObject lose;

        public void ShowWin()
        {
            win.SetActive(true);
        }

        public void ShowLose()
        {
            lose.SetActive(true);
        }
    }
}
