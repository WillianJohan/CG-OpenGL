using System;

namespace UFN_CG
{
    public struct Vector2Int : IEquatable<Vector2Int>
    {
        public int x;
        public int y;


        #region Getters

        public Vector2 normalized { get => Normalized(); }
        public float magnitude { get => Magnitude(); }
        
        //Static getters
        public static Vector2Int Zero { get => new Vector2Int(0, 0); }
        public static Vector2Int Right { get => new Vector2Int(1, 0); }
        public static Vector2Int Up { get => new Vector2Int(0, 1); }
        public static Vector2Int One { get => new Vector2Int(1, 1); }
        #endregion

        #region Constructors

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Methods
        
        float Magnitude()
        {
            float magnitude = 0;

            magnitude += MathF.Pow(x, 2);
            magnitude += MathF.Pow(y, 2);
            magnitude = MathF.Sqrt(magnitude);

            return magnitude;
        }

        Vector2 Normalized()
        {
            float _magnitude = Magnitude();
            Vector2 normalizedVector = (_magnitude <= 1.0f) ? new Vector2(x, y) : new Vector2(this.x / _magnitude, this.y / _magnitude);

            return normalizedVector;
        }
        
        public static float Dot(Vector2Int a, Vector2Int b)
        {
            return ((a.x * b.x) + (a.y * b.y));
        }

        #endregion

        #region Operators
        
        public override bool Equals(object obj)                     => obj is Vector2Int vector && Equals(vector);
        public bool Equals(Vector2Int other)                        => x == other.x && y == other.y;
        public override int GetHashCode()                           => HashCode.Combine(x, y);
        public override string ToString()                           => $"({x} , {y})";


        public static Vector2Int operator +(Vector2Int a, Vector2Int b)     => new Vector2Int(a.x + b.x, a.y + b.y);
        public static Vector2Int operator -(Vector2Int a)                   => a * -1;
        public static Vector2Int operator -(Vector2Int a, Vector2Int b)     => new Vector2Int(a.x - b.x, a.y - b.y);
        public static Vector2Int operator *(float d, Vector2Int a)          => new Vector2Int((int)Math.Round(a.x * d), (int)Math.Round(a.y * d));
        public static Vector2Int operator *(Vector2Int a, float d)          => new Vector2Int((int)Math.Round(a.x * d), (int)Math.Round(a.y * d));
        public static Vector2Int operator /(Vector2Int a, float d)          => new Vector2Int((int)Math.Round(a.x / d), (int)Math.Round(a.y / d));
        public static bool operator ==(Vector2Int lhs, Vector2Int rhs)   => ((lhs.x == rhs.x) && (lhs.y == rhs.y)) ? true : false;
        public static bool operator !=(Vector2Int lhs, Vector2Int rhs)   => ((lhs.x != rhs.x) || (lhs.y != rhs.y)) ? true : false;

        #endregion
    }
}
