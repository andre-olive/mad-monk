using UnityEngine;
using UnityEngine.UI;
using Game.Core;

namespace Game.UI
{
    public class AudioTab : MonoBehaviour
    {
        [SerializeField] private Slider master;
        [SerializeField] private Slider music;
        [SerializeField] private Slider sfx;

        private void Start()
        {
            master.onValueChanged.AddListener(AudioManager.Instance.SetMaster);
            music.onValueChanged.AddListener(AudioManager.Instance.SetMusic);
            sfx.onValueChanged.AddListener(AudioManager.Instance.SetSfx);
        }
    }
}
