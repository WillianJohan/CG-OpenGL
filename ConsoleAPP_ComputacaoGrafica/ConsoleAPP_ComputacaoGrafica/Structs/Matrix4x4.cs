using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleAPP_ComputacaoGrafica
{
    public struct Matrix4x4 : IEquatable<Matrix4x4>
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

        public Matrix4x4 transpose()
        {
            return new Matrix4x4(getColumn(0), getColumn(1), getColumn(2), getColumn(3));
        }

        #endregion

        #region Operators
        
        public bool Equals([AllowNull] Matrix4x4 other)
        {
            throw new NotImplementedException();
        }
        public override string ToString() => $"|{m00},{m01},{m02},{m03}|\n" +
                                             $"|{m10},{m11},{m12},{m13}|\n" +
                                             $"|{m20},{m21},{m22},{m23}|\n" +
                                             $"|{m30},{m31},{m32},{m33}|\n";

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
                Vector4 line = lhs.getLine(i);
                Vector4 column = rhs.getColumn(0);
                
                lineArray[i].x =    (line.x * column.x) +
                                    (line.y * column.y) +
                                    (line.z * column.z) +
                                    (line.w * column.w);

                column = rhs.getColumn(1);
                lineArray[i].y =    (line.x * column.x) +
                                    (line.y * column.y) +
                                    (line.z * column.z) +
                                    (line.w * column.w);

                column = rhs.getColumn(2);
                lineArray[i].z =    (line.x * column.x) +
                                    (line.y * column.y) +
                                    (line.z * column.z) +
                                    (line.w * column.w);

                column = rhs.getColumn(3);
                lineArray[i].w =    (line.x * column.x) +
                                    (line.y * column.y) +
                                    (line.z * column.z) +
                                    (line.w * column.w);

             
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
