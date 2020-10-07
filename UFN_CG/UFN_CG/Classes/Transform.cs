using System;

namespace UFN_CG
{
    public class Transform : IEquatable<Transform>
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
        
        #region Getters and Setters

        public Matrix4x4 TransformationMatrix { get => CalculateTransformationMatrix(); }

        Matrix4x4 CalculateTransformationMatrix()
        {
            Matrix4x4 TranslationMatrix = Matrix4x4.TranslationMatrix(Position.x, Position.y, Position.z);
            Matrix4x4 RotationMatrix = Matrix4x4.RotationMatrix(Rotation.x, Rotation.y, Rotation.z);
            Matrix4x4 ScaleMatrix = Matrix4x4.ScaleMatrix(Scale.x, Scale.y, Scale.z);

            return (TranslationMatrix * RotationMatrix) * ScaleMatrix;
        }

        #endregion

        #region Constructors

        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = new Vector3(1, 1, 1);
        }

        #endregion

        #region Methods

        public void Reset()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }

        public void translate(Vector3 translation)
        {
            this.Position += translation;
        }

        public void translate(float x,float y,float z)
        {
            Position.x += x;
            Position.y += y;
            Position.z += z;
        }

        public void rotate(Vector3 rotation)
        {
            Rotation += rotation;
        }

        public void rotate(float x, float y, float z)
        {
            Rotation.x += x;
            Rotation.y += y;
            Rotation.z += z;
        }

        public void rotate(Vector3 Axis, float angle)
        {
            this.Rotation += Axis * angle;
        }

        #endregion

        #region Operators
        
        public override bool Equals(object obj) => obj is Transform transform && Equals(transform);
        public bool Equals(Transform other)     => Position.Equals(other.Position) && Rotation.Equals(other.Rotation) && Scale.Equals(other.Scale);
        public override string ToString()       => $"Position {Position} ; Rotation {Rotation} ; Scale {Scale}";
        
        public static bool operator ==(Transform left, Transform right)     => left.Equals(right);
        public static bool operator !=(Transform left, Transform right)     => !(left == right);

        #endregion

    }
}
