using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAPP_ComputacaoGrafica
{

    public class Transform : IEquatable<Transform>
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;


        #region Methods

        public void translate(Vector3 translation)
        {
            Position = Position + translation;
        }


        #endregion


        #region Constructors and Operators

        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public override bool Equals(object obj)
        {
            return obj is Transform transform && Equals(transform);
        }

        public bool Equals(Transform other)
        {
            return Position.Equals(other.Position) &&
                   Rotation.Equals(other.Rotation) &&
                   Scale.Equals(other.Scale);
        }

        public static bool operator ==(Transform left, Transform right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Transform left, Transform right)
        {
            return !(left == right);
        }

        #endregion
    }
}

/*
public struct Transform
{
    public float[,] lc;

    //Getters
    public Matrix_3x3 zero { get => Zero(); }

    //Static methods
    public static Matrix_3x3 Zero()
    {
        return new Matrix_3x3(Vector3.zero, Vector3.zero, Vector3.zero);
    }
    public static Matrix_3x3 T(Matrix_3x3 a)
    {
        Matrix_3x3 t = new Matrix_3x3();
        t.lc = new float[3, 3];

        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                t.lc[l, c] = a.lc[c, l];
            }
        }

        return t;
    }

    //Construtores
    public Matrix_3x3(Vector3 line0, Vector3 line1, Vector3 line2)
    {
        lc = new float[3, 3];

        lc[0, 0] = line0.x;
        lc[0, 1] = line0.y;
        lc[0, 2] = line0.z;

        lc[1, 0] = line1.x;
        lc[1, 1] = line1.y;
        lc[1, 2] = line1.z;

        lc[2, 0] = line2.x;
        lc[2, 1] = line2.y;
        lc[2, 2] = line2.z;
    }
    public Matrix_3x3(float[,] lc)
    {
        this.lc = lc;
    }


    public bool Equals([AllowNull] Matrix_3x3 other)
    {
        return (new Matrix_3x3(lc) == other);
    }

    public static Matrix_3x3 operator +(Matrix_3x3 a, Matrix_3x3 b)
    {
        Matrix_3x3 result = new Matrix_3x3();
        result.lc = new float[3, 3];

        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                result.lc[l, c] = a.lc[l, c] + b.lc[l, c];
            }
        }

        return result;

    }
    public static Matrix_3x3 operator -(Matrix_3x3 a)
    {
        return a * -1;
    }
    public static Matrix_3x3 operator -(Matrix_3x3 a, Matrix_3x3 b)
    {
        Matrix_3x3 result = new Matrix_3x3();
        result.lc = new float[3, 3];

        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                result.lc[l, c] = a.lc[l, c] - b.lc[l, c];
            }
        }

        return result;
    }
    public static Matrix_3x3 operator *(float d, Matrix_3x3 a)
    {
        Matrix_3x3 result = new Matrix_3x3();
        result.lc = new float[3, 3];

        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                result.lc[l, c] = a.lc[l, c] * d;
            }
        }

        return result;
    }
    public static Matrix_3x3 operator *(Matrix_3x3 a, float d)
    {
        Matrix_3x3 result = new Matrix_3x3();
        result.lc = new float[3, 3];

        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                result.lc[l, c] = a.lc[l, c] * d;
            }
        }

        return result;
    }
    public static Matrix_3x3 operator *(Matrix_3x3 a, Matrix_3x3 b)
    {
        Matrix_3x3 result = new Matrix_3x3();
        result.lc = new float[3, 3];

        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                float value = 0;
                for (int i = 0; i < 3; i++)
                    value += a.lc[l, i] * b.lc[i, c];
                result.lc[l, c] = value;
            }
        }

        return result;
    }
    public static Vector3 operator *(Vector3 v, Matrix_3x3 m)
    {
        Vector3 result = new Vector3();

        result.x = ((v.x * m.lc[0, 0]) + (v.y * m.lc[1, 0]) + (v.z * m.lc[2, 0]));
        result.y = ((v.x * m.lc[0, 1]) + (v.y * m.lc[1, 1]) + (v.z * m.lc[2, 1]));
        result.x = ((v.x * m.lc[0, 2]) + (v.y * m.lc[1, 2]) + (v.z * m.lc[2, 2]));

        return result;
    }
    public static bool operator ==(Matrix_3x3 lhs, Matrix_3x3 rhs)
    {
        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (lhs.lc[l, c] != rhs.lc[l, c]) return false;
            }
        }
        return true;
    }
    public static bool operator !=(Matrix_3x3 lhs, Matrix_3x3 rhs)
    {
        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (lhs.lc[l, c] == rhs.lc[l, c]) return false;
            }
        }
        return true;
    }

}
*/

