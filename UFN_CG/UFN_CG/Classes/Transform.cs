using System;

namespace UFN_CG
{
    public class Transform : IEquatable<Transform>
    {
        Vector3 position;
        Vector3 rotation;
        Vector3 scale;

        Matrix4x4 transformationMatrix;

        #region Getters and Setters

        public Vector3 Position
        {
            get => position;
            set
            {
                position = value;
                CalculateTransformationMatrix();
            }
        }
        public Vector3 Rotation 
        { 
            get => rotation;
            set
            {
                rotation = value;
                CalculateTransformationMatrix();
            }
        }
        public Vector3 Scale
        {
            get => scale; 
            set
            {
                scale = value;
                CalculateTransformationMatrix();
            }
        }
        public Matrix4x4 TransformationMatrix { get => transformationMatrix; }

        #endregion

        #region Constructors

        public Transform()
        {
            position = Vector3.Zero;
            rotation = Vector3.Zero;
            scale = new Vector3(1, 1, 1);

            CalculateTransformationMatrix();
        }

        #endregion

        #region Methods

        private void CalculateTransformationMatrix()
        {
            Matrix4x4 TranslationMatrix = Matrix4x4.TranslationMatrix(position.x, position.y, position.z);
            Matrix4x4 RotationMatrix = Matrix4x4.RotationMatrix(rotation.x, rotation.y, rotation.z);
            Matrix4x4 ScaleMatrix = Matrix4x4.ScaleMatrix(scale.x, scale.y, scale.z);

            transformationMatrix = ScaleMatrix * RotationMatrix * TranslationMatrix;
        }

        public void Reset()
        {
            Position = Vector3.Zero;
            rotation = Vector3.Zero;
            Scale = Vector3.One;

            CalculateTransformationMatrix();
        }

        public void translate(Vector3 translation)
        {
            this.position += translation;
            CalculateTransformationMatrix();
        }

        public void translate(float x,float y,float z)
        {
            position.x += x;
            position.y += y;
            position.z += z;
            CalculateTransformationMatrix();
        }

        public void rotate(Vector3 rotation)
        {
            this.rotation += rotation;
            
            CalculateTransformationMatrix();
        }

        public void rotate(Vector3 Axis, float angle)
        {
            this.rotation += Axis * angle;
            CalculateTransformationMatrix();
        }

        #endregion

        #region Operators
        
        public override bool Equals(object obj) => obj is Transform transform && Equals(transform);
        public bool Equals(Transform other)     => position.Equals(other.position) && rotation.Equals(other.rotation) && scale.Equals(other.scale);
        public override string ToString()       => $"Position {position} ; Rotation {rotation} ; Scale {scale}";
        
        public static bool operator ==(Transform left, Transform right)     => left.Equals(right);
        public static bool operator !=(Transform left, Transform right)     => !(left == right);

        #endregion

    }
}
