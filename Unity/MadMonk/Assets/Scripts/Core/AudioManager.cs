using UnityEngine;

namespace Game.Core
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [Range(0, 1)] public float master = 1f;
        [Range(0, 1)] public float music = 1f;
        [Range(0, 1)] public float sfx = 1f;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SetMaster(float v) => master = v;
        public void SetMusic(float v) => music = v;
        public void SetSfx(float v) => sfx = v;
    }
}
