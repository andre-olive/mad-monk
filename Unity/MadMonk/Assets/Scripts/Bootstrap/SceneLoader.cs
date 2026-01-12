using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Bootstrap
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
