using UnityEngine;
using Game.Board;
using Game.Gameplay;
using Game.UI;
using System.Linq;

namespace Game.Core
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private WinLosePopup popup;
        [SerializeField] private LevelSO levelSO;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            PieceSpawner.Instance.Spawn();
        }

        /// <summary>
        /// Chamado exclusivamente quando uma peça foi posicionada com sucesso.
        /// </summary>
        public void OnPlayerMove(PieceView pv, HexCell hc)
        {
            if (!hc.IsOccupied)
            {
                hc.SetValue(pv.Value);
                Destroy(pv.gameObject);
                PieceSpawner.Instance.Spawn();

                ResolveBoard();
                CheckEndGame();
            }
            else
            {
                pv.ResetPosition();
            }
            
        }

        private void ResolveBoard()
        {
            // Continua aplicando merges enquanto houver combinações
            while (HexBoard.Instance.TryMerge())
            {
                // futuramente: animações, delay, score, etc
            }
        }

        private void CheckEndGame()
        {
            if (HexBoard.Instance.HasValue(7))
            {
                popup.ShowWin();
                return;
            }

            if (!HexBoard.Instance.HasMoves())
            {
                popup.ShowLose();
            }
        }

        public HexCellSO GetHexcellSO(int index)
        {
            return levelSO.hexcellList.FirstOrDefault(x => x.index == index);
        }
    }
}
