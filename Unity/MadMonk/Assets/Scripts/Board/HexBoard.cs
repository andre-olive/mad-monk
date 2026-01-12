using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Grid;

namespace Game.Board
{
    public class HexBoard : Singleton<HexBoard>
    {
        public Dictionary<HexCoord, HexCell> Grid = new();

        protected override void Awake()
        {
            base.Awake();
        }

        private IEnumerable<HexCell> GetNeighbors(HexCell cell)
        {
            foreach (var dir in HexCoord.AxialDirections)
            {
                var neighborCoord = cell.Coord + dir;

                if (Grid.TryGetValue(neighborCoord, out var neighbor))
                    yield return neighbor;
            }
        }

        public bool TryMerge()
        {
            var globalVisited = new HashSet<HexCell>();

            foreach (var cell in Grid.Values)
            {
                if (!cell.IsOccupied || globalVisited.Contains(cell))
                    continue;

                var cluster = FloodFillCluster(cell);

                // Marca como visitado APÓS o flood
                foreach (var c in cluster)
                    globalVisited.Add(c);

                if (cluster.Count >= 3)
                {
                    ApplyMerge(cluster);
                    return true;
                }
            }

            return false;
        }

        private List<HexCell> FloodFillCluster(HexCell origin)
        {
            var result = new List<HexCell>();
            var stack = new Stack<HexCell>();
            var visited = new HashSet<HexCell>();

            int targetValue = origin.Value;

            stack.Push(origin);
            visited.Add(origin);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current);

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (!neighbor.IsOccupied)
                        continue;

                    if (neighbor.Value != targetValue)
                        continue;

                    if (visited.Contains(neighbor))
                        continue;

                    visited.Add(neighbor);
                    stack.Push(neighbor);
                }
            }

            return result;
        }

        private void ApplyMerge(List<HexCell> cluster)
        {
            var target = cluster[0];
            int newValue = Mathf.Min(target.Value + 1, 7);

            foreach (var c in cluster)
                c.Clear();

            target.SetValue(newValue);
        }

        public bool HasMoves()
        {
            return Grid.Values.Any(c => !c.IsOccupied);
        }

        public bool HasValue(int value)
        {
            return Grid.Values.Any(c => c.Value >= value);
        }

        public IEnumerable<HexCell> FreeCells()
        {
            return Grid.Values.Where(c => !c.IsOccupied);
        }
    }
}
