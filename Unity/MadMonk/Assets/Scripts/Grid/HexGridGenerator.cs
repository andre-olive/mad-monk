using Game.Board;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Grid
{
    public class HexGridGenerator : Singleton<HexGridGenerator>
    {
        [Header("Grid")]
        [SerializeField] private int radius = 3;
        [SerializeField] private Board.HexCell cellPrefab;
        [SerializeField] private Transform container;

        protected override void Awake()
        {
            base.Awake();
            Generate();
        }

        public void Generate()
        {
            Clear();

            for (int q = -radius; q <= radius; q++)
            {
                int rMin = Mathf.Max(-radius, -q - radius);
                int rMax = Mathf.Min(radius, -q + radius);

                for (int r = rMin; r <= rMax; r++)
                {
                    var coord = new HexCoord(q, r);
                    Vector3 pos = HexMetrics.AxialToWorld(coord);

                    var cell = Instantiate(cellPrefab, pos, Quaternion.identity, container);
                    cell.name = $"Hex {coord}";
                    cell.Coord = coord;
                    cell.SetValue(0);

                    HexBoard.Instance.Grid.Add(coord, cell);
                }
            }

            Debug.Log($"Grid criado com {HexBoard.Instance.Grid.Count} células.");
        }

        private void Clear()
        {
            foreach (Transform c in container)
                DestroyImmediate(c.gameObject);

            HexBoard.Instance.Grid.Clear();
        }
    }
}
