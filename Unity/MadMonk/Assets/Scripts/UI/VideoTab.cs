using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Game.UI
{
    public class VideoTab : MonoBehaviour
    {
        [SerializeField] private Dropdown resolutionDropdown;
        [SerializeField] private Toggle fullscreenToggle;

        private Resolution[] resolutions;

        private void Start()
        {
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(
                resolutions.Select(r => $"{r.width} x {r.height}").Distinct().ToList()
            );

            fullscreenToggle.isOn = Screen.fullScreen;
        }

        public void ApplyResolution(int index)
        {
            var r = resolutions[index];
            Screen.SetResolution(r.width, r.height, Screen.fullScreen);
        }

        public void SetFullscreen(bool value)
        {
            Screen.fullScreen = value;
        }
    }
}
