using TMPro;
using UnityEngine;

namespace Game.Gameplay
{
    public class PieceView : MonoBehaviour
    {
        public int Value { get; private set; } = 1;

        public Vector3 OriginPosition { get; private set; }

        public TextMeshPro textMeshPro;

        public void Initialize(int value, Vector3 origin)
        {
            textMeshPro.text = value.ToString();
            Value = value;
            OriginPosition = origin;
            transform.position = origin;
        }

        public void ResetPosition()
        {
            transform.position = OriginPosition;
        }
    }
}
