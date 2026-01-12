using UnityEngine;
using Game.Board;

namespace Game.Gameplay
{
    public class BoardPicker : Singleton<BoardPicker>
    {
        public Camera Cam => cam;
        [SerializeField] private Camera cam;
        [SerializeField] private LayerMask cellMask;

        protected override void Awake()
        {
            base.Awake();
        }

        public HexCell Pick()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100f, cellMask))
                return hit.collider.GetComponentInParent<HexCell>();

            return null;
        }
    }
}
