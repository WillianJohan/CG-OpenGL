using System;

namespace UFN_CG
{
    public struct Vector4 : IEquatable<Vector4>
    {
        public float x;
        public float y;
        public float z;
        public float w;

        #region Getters

        public Vector4 normalized { get => Normalized(); }
        public float magnitude { get => Magnitude(); }


        //Static getters
        public static Vector4 Zero    { get => new Vector4(0, 0, 0, 0); }
        public static Vector4 Right   { get => new Vector4(1, 0, 0, 0); }
        public static Vector4 Up      { get => new Vector4(0, 1, 0, 0); }
        public static Vector4 Forward { get => new Vector4(0, 0, 1, 0); }

        #endregion

        #region Constructors

        public Vector4(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.w = 0;
        }

        public Vector4(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 0;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        #endregion

        #region Methods

        float Magnitude()
        {
            float magnitude = 0;

            magnitude += MathF.Pow(x, 2);
            magnitude += MathF.Pow(y, 2);
            magnitude += MathF.Pow(z, 2);
            magnitude += MathF.Pow(w, 2);
            magnitude = MathF.Sqrt(magnitude);

            return magnitude;
        }

        Vector4 Normalized()
        {
            float _magnitude = Magnitude();
            Vector4 normalizedVector = (_magnitude <= 1.0f) ? new Vector4(x, y, z, w) : new Vector4(this.x / _magnitude, this.y / _magnitude, this.z / _magnitude, this.w / _magnitude);

            return normalizedVector;
        }

        public static float DotProduct(Vector4 a, Vector4 b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w));
        }

        #endregion

        #region Operators

        public override bool Equals(object obj) => obj is Vector4 vector && Equals(vector);
        public bool Equals(Vector4 other) => x == other.x && y == other.y && z == other.z && w == other.w;
        public override string ToString() => $"({x}, {y}, {z}, {w})";


        public static Vector4 operator +(Vector4 a, Vector4 b) => new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static Vector4 operator -(Vector4 a) => a * -1;
        public static Vector4 operator -(Vector4 a, Vector4 b) => new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        public static Vector4 operator *(float d, Vector4 a) => new Vector4(a.x * d, a.y * d, a.z * d * a.w * d);
        public static Vector4 operator *(Vector4 a, float d) => new Vector4(a.x * d, a.y * d, a.z * d, a.w * d);
        public static Vector4 operator /(Vector4 a, float d) => new Vector4(a.x / d, a.y / d, a.z / d, a.w / d);
        public static bool operator ==(Vector4 lhs, Vector4 rhs) => ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z) && (lhs.w == rhs.w)) ? true : false;
        public static bool operator !=(Vector4 lhs, Vector4 rhs) => ((lhs.x != rhs.x) || (lhs.y != rhs.y) || (lhs.z != rhs.z) || (lhs.w == rhs.w)) ? true : false;

        #endregion
    }
}
