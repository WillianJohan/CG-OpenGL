using System;

namespace UFN_CG
{
    public struct Matrix3x3
    {
        public float m00, m01, m02,
                     m10, m11, m12,
                     m20, m21, m22;
                        

        #region Getters and Setters

        public Vector3 getColumn(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector3(m00, m10, m20);
                case 1:
                    return new Vector3(m01, m11, m21);
                case 2:
                    return new Vector3(m02, m12, m22);
                default:
                    return Vector3.Zero;
            }
        }
        public Vector3 getLine(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector3(m00, m01, m02);
                case 1:
                    return new Vector3(m10, m11, m12);
                case 2:
                    return new Vector3(m20, m21, m22);
                default:
                    return Vector3.Zero;
            }
        }

        //Static methods
        public static Matrix3x3 Zero()
        {
            return new Matrix3x3(Vector3.Zero, Vector3.Zero, Vector3.Zero);
        }

        public static Matrix3x3 Identity()
        {
            return new Matrix3x3(new Vector3(1, 0, 0),
                                 new Vector3(0, 1, 0),
                                 new Vector3(0, 0, 1));
        }
        #endregion

        #region Constructors

        public Matrix3x3(Vector3 line00, Vector3 line01, Vector3 line02)
        {
            this.m00 = line00.x;
            this.m01 = line00.y;
            this.m02 = line00.z;

            this.m10 = line01.x;
            this.m11 = line01.y;
            this.m12 = line01.z;

            this.m20 = line02.x;
            this.m21 = line02.y;
            this.m22 = line02.z;
        }

        #endregion

        #region Methods

        public Matrix3x3 Transpose()
        {
            return new Matrix3x3(getColumn(0), getColumn(1), getColumn(2));
        }

        //Transformações
        public static Matrix3x3 TranslationMatrix(float x, float y)
        {
            // 1  0  Tx
            // 0  1  Ty
            // 0  0  1

            Matrix3x3 matriz_Translacao = Matrix3x3.Identity();
            matriz_Translacao.m02 = x;
            matriz_Translacao.m12 = y;

            return matriz_Translacao;
        }

        public static Matrix3x3 RotationMatrix(float angle)
        {
            Matrix3x3 rotationMatrix = Identity();
            angle = (float)Math.PI * angle / 180;

            rotationMatrix.m00 = (float)Math.Cos(angle);    // |cos()   -sen()  0|
            rotationMatrix.m01 = (float)-Math.Sin(angle);   // |sen()   cos()   0|
            rotationMatrix.m10 = (float)Math.Sin(angle);    // |0       0       1|
            rotationMatrix.m11 = (float)Math.Cos(angle);

            return rotationMatrix;
        }

        public static Matrix3x3 ScaleMatrix(float x, float y)
        {
            //  sX  0   0 
            //  0   Sy  0 
            //  0   0   1

            Matrix3x3 matriz_Rotacao = Matrix3x3.Identity();
            matriz_Rotacao.m00 = x;
            matriz_Rotacao.m11 = y;

            return matriz_Rotacao;
        }

        #endregion

        #region Operators

        public override string ToString() => $"|{m00} ,{m01}, {m02}|\n" +
                                             $"|{m10} ,{m11}, {m12}|\n" +
                                             $"|{m20} ,{m21}, {m22}|\n";
        public static Matrix3x3 operator +(Matrix3x3 lhs, Matrix3x3 rhs)
        {
            Vector3[] lineArray = new Vector3[3];
            for (int i = 0; i < 3; i++)
                lineArray[i] = lhs.getLine(i) + rhs.getLine(i);
            return new Matrix3x3(lineArray[0], lineArray[1], lineArray[2]);
        }
        public static Vector3 operator *(Vector3 vector, Matrix3x3 rhs)
        {
            Vector3 resultado = Vector3.One;

            Vector3 line = rhs.getLine(0);
            resultado.x = (vector.x * line.x) +
                          (vector.y * line.y) +
                          (vector.z * line.z);

            line = rhs.getLine(1);
            resultado.y = (vector.x * line.x) +
                          (vector.y * line.y) +
                          (vector.z * line.z);

            line = rhs.getLine(2);
            resultado.z = (vector.x * line.x) +
                          (vector.y * line.y) +
                          (vector.z * line.z);

            return resultado;
        }
        public static Matrix3x3 operator *(Matrix3x3 lhs, Matrix3x3 rhs)
        {
            Vector3[] lineArray = new Vector3[3];

            for (int i = 0; i < 3; i++)
            {
                lineArray[i] = Vector3.Zero;
                Vector3 lhs_line = lhs.getLine(i);
                Vector3 rhs_column = rhs.getColumn(0);

                lineArray[i].x = (lhs_line.x * rhs_column.x) +
                                 (lhs_line.y * rhs_column.y) +
                                 (lhs_line.z * rhs_column.z);

                rhs_column = rhs.getColumn(1);
                lineArray[i].y = (lhs_line.x * rhs_column.x) +
                                 (lhs_line.y * rhs_column.y) +
                                 (lhs_line.z * rhs_column.z);
                                 

                rhs_column = rhs.getColumn(2);
                lineArray[i].z = (lhs_line.x * rhs_column.x) +
                                 (lhs_line.y * rhs_column.y) +
                                 (lhs_line.z * rhs_column.z);
            }
            return new Matrix3x3(lineArray[0], lineArray[1], lineArray[2]);
        }
        public static bool operator ==(Matrix3x3 lhs, Matrix3x3 rhs)
        {
            for (int i = 0; i < 3; i++)
            {
                if (lhs.getLine(i) != rhs.getLine(i)) return false;
            }
            return true;
        }
        public static bool operator !=(Matrix3x3 lhs, Matrix3x3 rhs)
        {
            for (int i = 0; i < 3; i++)
            {
                if (lhs.getLine(i) == rhs.getLine(i)) return false;
            }
            return true;
        }

        #endregion

    }
}
