using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleAPP_ComputacaoGrafica
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float x;
        public float y;
        

        //Getters
        public Vector2 normalized { get => Normalized(); }
        public float magnitude { get => Magnitude(); }
        public static Vector2 zero { get => Zero(); }


        //Constructor
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


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
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }
        public static float dotProduct(Vector2 a, Vector2 b)
        {
            return ((a.x * b.x) + (a.y * b.y));
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector && Equals(vector);
        }

        public bool Equals(Vector2 other)
        {
            return x == other.x &&
                   y == other.y;                   
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"[{x},{y}]";
        }




        #region Operators

        public static Vector2 operator +(Vector2 a, Vector2 b)      => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a)                 => a * -1;
        public static Vector2 operator -(Vector2 a, Vector2 b)      => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(float d, Vector2 a)        => new Vector2(a.x * d, a.y * d);
        public static Vector2 operator *(Vector2 a, float d)        => new Vector2(a.x * d, a.y * d);
        public static Vector2 operator /(Vector2 a, float d)        => new Vector2(a.x / d, a.y / d);
        public static bool operator ==(Vector2 lhs, Vector2 rhs)    => ((lhs.x == rhs.x) && (lhs.y == rhs.y)) ? true : false;
        public static bool operator !=(Vector2 lhs, Vector2 rhs)    => ((lhs.x != rhs.x) || (lhs.y != rhs.y)) ? true : false;

        #endregion
    }
}
