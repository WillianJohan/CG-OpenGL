using System;

namespace UFN_CG
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public float x;
        public float y;
        public float z;

        #region Getters
        
        public Vector3 normalized { get => Normalized(); }
        public float magnitude { get => Magnitude(); }
        
        //Static getters
        public static Vector3 Zero     { get => new Vector3(0, 0, 0); }
        public static Vector3 Right    { get => new Vector3(1, 0, 0); }
        public static Vector3 Up       { get => new Vector3(0, 1, 0); }
        public static Vector3 Forward  { get => new Vector3(0, 0, 1); }
        public static Vector3 One      { get => new Vector3(1, 1, 1); }

        #endregion

        #region Constructors

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }

        public Vector3(Vector2 value)
        {
            this.x = value.x;
            this.y = value.x;
            this.z = 0;
        }

        #endregion

        #region Methods

        float Magnitude()
        {
            float magnitude = 0;

            magnitude += (float)Math.Pow(x, 2);
            magnitude += (float)Math.Pow(y, 2);
            magnitude += (float)Math.Pow(z, 2);
            magnitude =  (float)Math.Sqrt(magnitude);

            return magnitude;
        }

        Vector3 Normalized()
        {
            float _magnitude = Magnitude();
            Vector3 normalizedVector = (_magnitude <= 1.0f) ? new Vector3(x, y, z) : new Vector3(this.x / _magnitude, this.y / _magnitude, this.z / _magnitude);

            return normalizedVector;
        }

        public static float Distance(Vector3 p1, Vector3 p2)
        {
            double a = Math.Pow(p1.x - p2.x, 2);
            double b = Math.Pow(p1.y - p2.y, 2);
            double c = Math.Pow(p1.z - p2.z, 2);
            return (float)Math.Sqrt(a + b + c);
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
        }
        #endregion

        #region Operators

        public override bool Equals(object obj)                         => obj is Vector3 vector && Equals(vector);
        public bool Equals(Vector3 other)                               => x == other.x && y == other.y && z == other.z;
        public override string ToString()                               => $"({x}, {y}, {z})";


        public static explicit operator Vector3(Vector2 v)              => new Vector3(v.x, v.y);
        public static explicit operator Vector3(Vector4 v)              => new Vector3(v.x, v.y, v.z);
        public static Vector3 operator +(Vector3 a, Vector3 b)          => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a)                     => a * -1;
        public static Vector3 operator -(Vector3 a, Vector3 b)          => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator *(float d, Vector3 a)            => new Vector3(a.x * d, a.y * d, a.z * d);
        public static Vector3 operator *(Vector3 a, float d)            => new Vector3(a.x * d, a.y * d, a.z * d);
        public static Vector3 operator /(Vector3 a, float d)            => new Vector3(a.x / d, a.y / d, a.z / d);
        public static bool operator ==(Vector3 lhs, Vector3 rhs)        => ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z)) ? true : false;
        public static bool operator !=(Vector3 lhs, Vector3 rhs)        => ((lhs.x != rhs.x) || (lhs.y != rhs.y) || (lhs.z != rhs.z)) ? true : false;

        #endregion
    }
}
