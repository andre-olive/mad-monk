using System;
using UnityEngine;

namespace Game.Grid
{
    [Serializable]
    public struct HexCoord : IEquatable<HexCoord>
    {
        public int q;
        public int r;

        public HexCoord(int q, int r)
        {
            this.q = q;
            this.r = r;
        }

        public bool Equals(HexCoord other)
            => q == other.q && r == other.r;

        public override bool Equals(object obj)
            => obj is HexCoord other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(q, r);

        public static HexCoord operator +(HexCoord a, HexCoord b)
            => new(a.q + b.q, a.r + b.r);

        public override string ToString()
            => $"({q},{r})";

        public static readonly HexCoord[] AxialDirections =
        {
            new( 1,  0),
            new( 1, -1),
            new( 0, -1),
            new(-1,  0),
            new(-1,  1),
            new( 0,  1),
        };
    }
}
