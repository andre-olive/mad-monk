using UnityEngine;

namespace Game.Grid
{
    public static class HexMetrics
    {
        /// <summary>
        /// Raio do hexágono (centro → vértice)
        /// </summary>
        public const float HexSize = 0.5f;

        /// <summary>
        /// Espaçamento adicional entre células (em unidades do mundo).
        /// 0 = hexágonos encostados
        /// </summary>
        public const float Spacing = 0.05f;

        private static float EffectiveSize => HexSize + Spacing;

        /// <summary>
        /// Layout pointy-top no plano XZ.
        /// </summary>
        public static Vector3 AxialToWorld(HexCoord h)
        {
            float size = EffectiveSize;

            float x = size * Mathf.Sqrt(3f) * (h.q + h.r * 0.5f);
            float z = size * 1.5f * h.r;

            return new Vector3(x, 0f, z);
        }
    }
}
