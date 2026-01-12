using UnityEngine;

namespace Game.Gameplay
{
    public class PieceSpawner : Singleton<PieceSpawner>
    {
        [SerializeField] private PieceView piecePrefab;
        [SerializeField] private Transform spawnPoint;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Spawn(int value = 1)
        {
            var piece = Instantiate(piecePrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            piece.Initialize(value, spawnPoint.position);
        }
    }
}
