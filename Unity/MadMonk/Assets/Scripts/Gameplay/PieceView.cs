using TMPro;
using UnityEngine;

namespace Game.Gameplay
{
    public class PieceView : MonoBehaviour
    {
        public int Value { get; private set; } = 1;

        public Vector3 OriginPosition { get; private set; }

        public TextMeshPro textMeshPro;
        public MeshRenderer meshBG;
        public MeshRenderer meshFront;

        [SerializeField] private Animator animator;
        private static readonly int IsDrag = Animator.StringToHash("IsDrag");

        public void Initialize(int value, Vector3 origin)
        {
            textMeshPro.text = value.ToString();
            Value = value;
            OriginPosition = origin;
            transform.position = origin;

            var hexSO = Core.GameManager.Instance.GetHexcellSO(value);
            if (hexSO != null)
            {
                meshBG.material.mainTexture = hexSO.sprite_bg != null ? hexSO.sprite_bg.texture : null;

                if (hexSO.sprite_front != null)
                {
                    meshFront.material.mainTexture = hexSO.sprite_front.texture;
                    meshFront.gameObject.SetActive(true);
                }
                else
                    meshFront.gameObject.SetActive(false);
            }
        }

        public void ResetPosition()
        {
            transform.position = OriginPosition;
        }

        public void Animator_SetDrag(bool isActive)
        {
            animator.SetBool(IsDrag, isActive);
        }

    }
}
