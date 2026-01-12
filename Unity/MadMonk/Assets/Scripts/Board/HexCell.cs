using UnityEngine;
using Game.Grid;
using TMPro;

namespace Game.Board
{
    public class HexCell : MonoBehaviour
    {
        public HexCoord Coord { get; set; }

        public int Value { get; private set; }
        public bool IsOccupied => Value > 0;

        public TextMeshPro textMeshPro;

        public void SetValue(int value)
        {
            Value = value;
            textMeshPro.text = value.ToString();
        }

        public void Clear()
        {
            SetValue(0);
        }
    }
}
