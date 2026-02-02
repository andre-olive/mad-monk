using Game.Board;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Grid
{
    public class HexGridGenerator : Singleton<HexGridGenerator>
    {
        [Header("Grid")]
        [SerializeField] private int radius = 2;
        [SerializeField] private HexCell cellPrefab;
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
                    GenerateHex(new HexCoord(q, r));
            }

            // Cria os hexagonos das pontas (para radius == 2)
            GenerateHex(new HexCoord(-3, 2));
            GenerateHex(new HexCoord(-1, -2));
            GenerateHex(new HexCoord(1, 2));
            GenerateHex(new HexCoord(3, -2));

            Debug.Log($"Grid criado com {HexBoard.Instance.Grid.Count} células.");
        }

        private void GenerateHex(HexCoord hexCoord)
        {
            Vector3 pos = HexMetrics.AxialToWorld(hexCoord);

            var cell = Instantiate(cellPrefab, pos, Quaternion.identity, container);
            cell.name = $"Hex {hexCoord}";
            cell.Coord = hexCoord;
            cell.SetValue(0);

            HexBoard.Instance.Grid.Add(hexCoord, cell);
        }

        private void Clear()
        {
            foreach (Transform c in container)
                DestroyImmediate(c.gameObject);

            HexBoard.Instance.Grid.Clear();
        }
    }
}
