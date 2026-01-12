using UnityEngine;

namespace Game.UI
{
    public class SettingsPopup : MonoBehaviour
    {
        [SerializeField] private GameObject root;

        public void Open() => root.SetActive(true);
        public void Close() => root.SetActive(false);
    }
}
