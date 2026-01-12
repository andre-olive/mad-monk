using UnityEngine;
using Game.Bootstrap;

namespace Game.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private SceneLoader loader;
        [SerializeField] private SettingsPopup settings;

        public void Play()
        {
            loader.LoadGame();
        }

        public void OpenSettings()
        {
            settings.Open();
        }
    }
}
