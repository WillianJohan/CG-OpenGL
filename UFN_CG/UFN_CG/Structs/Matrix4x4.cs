using System;
using System.Diagnostics.CodeAnalysis;

namespace UFN_CG
{
    public struct Matrix4x4
    {
        public float    m00, m01, m02, m03,
                        m10, m11, m12, m13,
                        m20, m21, m22, m23,
                        m30, m31, m32, m33;

        #region Getters and Setters

        public Vector4 getColumn(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector4(m00, m10, m20, m30);
                case 1:
                    return new Vector4(m01, m11, m21, m31);
                case 2:
                    return new Vector4(m02, m12, m22, m32);
                case 3:
                    return new Vector4(m03, m13, m23, m33);
                default:
                    return Vector4.Zero;
            }            
        }
        public Vector4 getLine(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector4(m00, m01, m02, m03);
                case 1:
                    return new Vector4(m10, m11, m12, m13);
                case 2:
                    return new Vector4(m20, m21, m22, m23);
                case 3:
                    return new Vector4(m30, m31, m32, m33);
                default:
                    return Vector4.Zero;
            }
        }

        //Static methods
        public static Matrix4x4 Zero()
        {
            return new Matrix4x4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);
        }

        public static Matrix4x4 Identity()
        {
            return new Matrix4x4(new Vector4(1, 0, 0, 0),
                                 new Vector4(0, 1, 0, 0),
                                 new Vector4(0, 0, 1, 0),
                                 new Vector4(0, 0, 0, 1));
        }
        #endregion

        #region Constructors

        public Matrix4x4(Vector4 line00, Vector4 line01, Vector4 line02, Vector4 line03)
        {
            this.m00 = line00.x;
            this.m01 = line00.y;
            this.m02 = line00.z;
            this.m03 = line00.w;
                       
            this.m10 = line01.x;
            this.m11 = line01.y;
            this.m12 = line01.z;
            this.m13 = line01.w;

            this.m20 = line02.x;
            this.m21 = line02.y;
            this.m22 = line02.z;
            this.m23 = line02.w;

            this.m30 = line03.x;
            this.m31 = line03.y;
            this.m32 = line03.z;
            this.m33 = line03.w;
        }

        #endregion

        #region Methods

        public Matrix4x4 Transpose()
        {
            return new Matrix4x4(getColumn(0), getColumn(1), getColumn(2), getColumn(3));
        }

        //Transformações
        public Matrix4x4 TranslationMatrix(float x, float y, float z)
        {
            // 1  0  0  Tx
            // 0  1  0  Ty
            // 0  0  1  Tz
            // 0  0  0  1
            
            Matrix4x4 matriz_Translacao = Matrix4x4.Identity();
            matriz_Translacao.m03 = x;
            matriz_Translacao.m13 = y;
            matriz_Translacao.m23 = z;
            
            return matriz_Translacao;
        }
        
        public Matrix4x4 RotationMatrix(float x, float y, float z)
        {
            Matrix4x4 Mat_X = Identity();     
            Mat_X.m11 = (float)Math.Cos(x);         // Rx   |1       0       0       0|  
            Mat_X.m12 = (float)-Math.Sin(x);        //      |0       Sen()   Cos()   0|  
            Mat_X.m21 = (float)Math.Sin(x);         //      |0       0       0       0|
            Mat_X.m22 = (float)Math.Cos(x);         //      |0       cos()   -Sen()  1|  

            Matrix4x4 Mat_Y = Identity();
            Mat_Y.m00 = (float)Math.Cos(y);         // Ry   |cos()   0       -sen()  0|
            Mat_Y.m02 = (float)-Math.Sin(y);        //      |0       1       0       0|  
            Mat_Y.m20 = (float)-Math.Sin(y);        //      |-sen()  0       cos()   0|  
            Mat_Y.m22 = (float)Math.Cos(y);         //      |0       0       0       1|

            Matrix4x4 Mat_Z = Identity();
            Mat_Z.m00 = (float)Math.Cos(z);         // Rz   |cos()   -sen()  0       0|  
            Mat_Z.m01 = (float)-Math.Sin(z);        //      |sen()   -cos()  0       0|  
            Mat_Z.m10 = (float)Math.Sin(z);         //      |0       0       1       0|  
            Mat_Z.m11 = (float)-Math.Cos(z);        //      |0       0       0       1|  

            return Mat_X * Mat_Y * Mat_Z;
        }

        public Matrix4x4 RotationMatrix(Vector3 axis, float angle)
        {
            Matrix4x4 rotationMatrix = Identity();
            
            if (axis.x == 1) // X
            {
                rotationMatrix.m11 = (float)Math.Cos(angle);
                rotationMatrix.m12 = (float)-Math.Sin(angle);
                rotationMatrix.m21 = (float)Math.Sin(angle);
                rotationMatrix.m22 = (float)Math.Cos(angle);
            }else if (axis.y == 1) // Y
            {
               rotationMatrix.m00 = (float)Math.Cos(angle);
               rotationMatrix.m02 = (float)-Math.Sin(angle);
               rotationMatrix.m20 = (float)-Math.Sin(angle);
               rotationMatrix.m22 = (float)Math.Cos(angle);
            }else if (axis.z == 1) // Z
            {
               rotationMatrix.m00 = (float)Math.Cos(angle);
               rotationMatrix.m01 = (float)-Math.Sin(angle);
               rotationMatrix.m10 = (float)Math.Sin(angle);
               rotationMatrix.m11 = (float)-Math.Cos(angle);
            }

            return rotationMatrix;
        }

        public Matrix4x4 ScaleMatrix(float x, float y, float z)
        {
            //  sX  0   0   0
            //  0   Sy  0   0
            //  0   0   Sz  0
            //  0   0   0   1
            
            Matrix4x4 matriz_Rotacao = Matrix4x4.Identity();
            matriz_Rotacao.m00 = x;
            matriz_Rotacao.m11 = y;
            matriz_Rotacao.m22 = z;

            return matriz_Rotacao;
        }

        #endregion

        #region Operators

        public override string ToString() => $"|{m00} ,{m01}, {m02}, {m03}|\n" +
                                             $"|{m10} ,{m11}, {m12}, {m13}|\n" +
                                             $"|{m20} ,{m21}, {m22}, {m23}|\n" +
                                             $"|{m30} ,{m31}, {m32}, {m33}|\n";
        public static Vector3 operator *(Vector3 vector, Matrix4x4 rhs)
        {
            Vector4 resultado = Vector4.Zero;

            Vector4 column = rhs.getColumn(0);
            resultado.x = (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (1 * column.w);

            column = rhs.getColumn(1);
            resultado.y = (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (1 * column.w);

            column = rhs.getColumn(2);
            resultado.z = (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (1 * column.w);

            column = rhs.getColumn(3);
            resultado.w = (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (1 * column.w);

            return new Vector3(resultado.x, resultado.y, resultado.z);
        }
        public static Vector4 operator *(Vector4 vector, Matrix4x4 rhs) 
        {
            Vector4 resultado = Vector4.Zero;
            
            Vector4 column = rhs.getColumn(0);
            resultado.x =   (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (vector.w * column.w);
            
            column = rhs.getColumn(1);
            resultado.y =   (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (vector.w * column.w);
            
            column = rhs.getColumn(2);
            resultado.z =   (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (vector.w * column.w);
            
            column = rhs.getColumn(3);
            resultado.w =   (vector.x * column.x) +
                            (vector.y * column.y) +
                            (vector.z * column.z) +
                            (vector.w * column.w);

            return resultado;
        }
        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs) 
        {
            Vector4[] lineArray = new Vector4[4];

            for (int i = 0; i < 4; i++)
            {
                lineArray[i] = Vector4.Zero;
                Vector4 lhs_line = lhs.getLine(i);
                Vector4 rhs_column = rhs.getColumn(0);
                
                lineArray[i].x =    (lhs_line.x * rhs_column.x) +
                                    (lhs_line.y * rhs_column.y) +
                                    (lhs_line.z * rhs_column.z) +
                                    (lhs_line.w * rhs_column.w);

                rhs_column = rhs.getColumn(1);
                lineArray[i].y =    (lhs_line.x * rhs_column.x) +
                                    (lhs_line.y * rhs_column.y) +
                                    (lhs_line.z * rhs_column.z) +
                                    (lhs_line.w * rhs_column.w);

                rhs_column = rhs.getColumn(2);
                lineArray[i].z =    (lhs_line.x * rhs_column.x) +
                                    (lhs_line.y * rhs_column.y) +
                                    (lhs_line.z * rhs_column.z) +
                                    (lhs_line.w * rhs_column.w);

                rhs_column = rhs.getColumn(3);
                lineArray[i].w =    (lhs_line.x * rhs_column.x) +
                                    (lhs_line.y * rhs_column.y) +
                                    (lhs_line.z * rhs_column.z) +
                                    (lhs_line.w * rhs_column.w);

             
            }
            return new Matrix4x4(lineArray[0], lineArray[1], lineArray[2], lineArray[3]);
        }
        public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs) 
        {
            for(int i = 0; i < 4; i++)
            {
                if (lhs.getLine(i) != rhs.getLine(i)) return false;
            }
            return true;
        }
        public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs) 
        {
            for (int i = 0; i < 4; i++)
            {
                if (lhs.getLine(i) == rhs.getLine(i)) return false;
            }
            return true;
        }

        #endregion

    }
}
