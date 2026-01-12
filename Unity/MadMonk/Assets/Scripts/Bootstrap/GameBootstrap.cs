using UnityEngine;
using Game.Core;

namespace Game.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private AudioManager audioManagerPrefab;

        private void Awake()
        {
            if (AudioManager.Instance == null)
                Instantiate(audioManagerPrefab);
        }
    }
}
