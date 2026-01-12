using UnityEngine;
using Game.Board;
using Game.Core;

namespace Game.Gameplay
{
    public class DragController : Singleton<DragController>
    {
        private PieceView draggingPiece;
        private Plane dragPlane;

        protected override void Awake()
        {
            base.Awake();
            dragPlane = new Plane(Vector3.up, Vector3.zero);
        }

        private void Update()
        {
            if (draggingPiece == null)
                return;

            Drag();

            if (Input.GetMouseButtonUp(0))
                EndDrag();
        }

        private void Drag()
        {
            Ray ray = BoardPicker.Instance.Cam.ScreenPointToRay(Input.mousePosition);

            if (dragPlane.Raycast(ray, out float enter))
            {
                Vector3 point = ray.GetPoint(enter);
                draggingPiece.transform.position = point + Vector3.up * 0.2f;
            }
        }

        public void BeginDrag(PieceView piece)
        {
            draggingPiece = piece;
        }

        public void EndDrag()
        {
            HexCell target = BoardPicker.Instance.Pick();

            if(target != null)
                GameManager.Instance.OnPlayerMove(draggingPiece, target);

            draggingPiece = null;
        }
    }
}
