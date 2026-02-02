using UnityEngine;
using Game.Grid;
using TMPro;
using Game.Core;

namespace Game.Board
{
    public class HexCell : MonoBehaviour
    {
        public HexCoord Coord { get; set; }

        public int Value { get; private set; }
        public bool IsOccupied => Value > 0;

        public TextMeshPro textMeshPro;
        public MeshRenderer meshBG;
        public MeshRenderer meshFront;

        [SerializeField] private Animator animator;
        private static readonly int Merged = Animator.StringToHash("Merged");

        public void SetValue(int value)
        {
            Value = value;
            textMeshPro.text = value.ToString();

            var hexSO = GameManager.Instance.GetHexcellSO(value);
            if (hexSO != null)
            {
                meshBG.material.mainTexture = hexSO.sprite_bg != null ? hexSO.sprite_bg.texture : null;

                if (hexSO.sprite_front != null)
                {
                    meshFront.material.mainTexture = hexSO.sprite_front.texture;
                    meshFront.gameObject.SetActive(true);
                    animator.SetTrigger(Merged);
                }
                else
                    meshFront.gameObject.SetActive(false);
            }
        }

        public void Clear()
        {
            SetValue(0);
        }
    }
}
