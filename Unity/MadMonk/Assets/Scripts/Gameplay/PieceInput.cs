using UnityEngine;

namespace Game.Gameplay
{
    public class PieceInput : MonoBehaviour
    {
        private PieceView view;

        private void Awake()
        {
            view = GetComponent<PieceView>();
        }

        public void HandleMouseDown()
        {
            DragController.Instance.BeginDrag(view);
        }

        public void HandleMouseUp()
        {
            DragController.Instance.EndDrag();
        }
    }
}
