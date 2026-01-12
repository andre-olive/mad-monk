using UnityEngine;

namespace Game.Gameplay
{
    public class PieceCollider : MonoBehaviour
    {
        private PieceInput input;

        private void Awake()
        {
            input = GetComponentInParent<PieceInput>();
            if (input == null)
            {
                Debug.LogError("PieceInput não encontrado no parent.");
            }
        }

        private void OnMouseDown()
        {
            input?.HandleMouseDown();
        }

        private void OnMouseUp()
        {
            input?.HandleMouseUp();
        }
    }
}
