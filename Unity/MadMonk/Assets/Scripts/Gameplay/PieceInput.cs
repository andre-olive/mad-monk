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
            view.Animator_SetDrag(true);
        }

        public void HandleMouseUp()
        {
            DragController.Instance.EndDrag();
            view.Animator_SetDrag(false);
        }
    }
}
