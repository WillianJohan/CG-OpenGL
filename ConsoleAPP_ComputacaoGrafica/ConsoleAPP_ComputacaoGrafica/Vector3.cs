using System;

namespace ConsoleAPP_ComputacaoGrafica
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public float x;
        public float y;
        public float z;

        //Getters
        public Vector3 normalized { get => Normalized(); }
        public float magnitude { get => Magnitude(); }
        public static Vector3 zero { get => Zero(); }


        //Constructor
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


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
        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }
        public static float dotProduct(Vector3 a, Vector3 b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 vector && Equals(vector);
        }

        public bool Equals(Vector3 other)
        {
            return x == other.x &&
                   y == other.y &&
                   z == other.z;
        }

        public override string ToString()
        {
            return $"[{x},{y},{z}]";
        }

        #region Operators

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
