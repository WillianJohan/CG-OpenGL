using System;

namespace ConsoleAPP_ComputacaoGrafica
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
        public static Vector3 Zero { get => new Vector3(0,0,0); }
        public static Vector3 Right { get => new Vector3(1, 0, 0); }
        public static Vector3 Up { get => new Vector3(0, 1, 0); }
        
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

            magnitude += MathF.Pow(x, 2);
            magnitude += MathF.Pow(y, 2);
            magnitude += MathF.Pow(z, 2);
            magnitude = MathF.Sqrt(magnitude);

            return magnitude;
        }

        Vector3 Normalized()
        {
            float _magnitude = Magnitude();
            Vector3 normalizedVector = (_magnitude <= 1.0f) ? new Vector3(x, y, z) : new Vector3(this.x / _magnitude, this.y / _magnitude, this.z / _magnitude);

            return normalizedVector;
        }

        public static float DotProduct(Vector3 a, Vector3 b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
        }
        #endregion

        #region Operators

        public override bool Equals(object obj)                         => obj is Vector3 vector && Equals(vector);
        public bool Equals(Vector3 other)                               => x == other.x && y == other.y && z == other.z;
        public override string ToString()                               => $"[{x},{y},{z}]";


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
