using System;

namespace UFN_CG
{
    public class Transform2D : IEquatable<Transform2D>
    {
        Vector2 position;
        float   rotation;
        Vector2 scale;

        Matrix3x3 RotationMatrix;           //Matriz que acumula as rotações
        Matrix3x3 transformationMatrix;     //Matriz que representa as transformações

        #region Getters and Setters

        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                CalculateTransformationMatrix();
            }
        }
        public float Rotation 
        { 
            get => rotation;
            set 
            {
                rotation = value;
                RotationMatrix = Matrix3x3.RotationMatrix(value);
                CalculateTransformationMatrix();
            }
        }
        public Vector2 Scale
        {
            get => scale;
            set
            {
                scale = value;
                CalculateTransformationMatrix();
            }
        }
        public Matrix3x3 TransformationMatrix { get => transformationMatrix; }

        #endregion

        #region Constructors

        public Transform2D()
        {
            position = Vector2.Zero;
            rotation = 0;
            scale = new Vector2(1, 1);

            RotationMatrix = Matrix3x3.RotationMatrix(0);
            CalculateTransformationMatrix();
        }

        #endregion

        #region Methods
        
        private void CalculateTransformationMatrix()
        {
            Matrix3x3 TranslationMatrix = Matrix3x3.TranslationMatrix(position.x, position.y);
            Matrix3x3 ScaleMatrix = Matrix3x3.ScaleMatrix(scale.x, scale.y);

            transformationMatrix = ScaleMatrix * RotationMatrix * TranslationMatrix;
        }
        
        public void Reset()
        {
            Position = Vector2.Zero;
            rotation = 0;
            Scale = Vector2.One;
            RotationMatrix = Matrix3x3.RotationMatrix(0);

            CalculateTransformationMatrix();
        }

        public void translate(Vector2 translation)
        {
            this.position += translation;
            CalculateTransformationMatrix();
        }

        public void translate(float x, float y)
        {
            this.position.x += x;
            this.position.y += y;
            CalculateTransformationMatrix();
        }

        public void rotate(float angle)
        {
            this.rotation += angle;
            RotationMatrix *= Matrix3x3.RotationMatrix(angle);
            CalculateTransformationMatrix();
        }

        #endregion

        #region Operators

        public override bool Equals(object obj) => obj is Transform2D transform && Equals(transform);
        public bool Equals(Transform2D other) => position.Equals(other.position) && rotation.Equals(other.rotation) && scale.Equals(other.scale);

        public override string ToString()
        {
            return  $"Position: {this.position}\n" +
                    $"Rotation: {this.rotation}\n" +
                    $"Scale: {this.scale}\n";
        }

        public static bool operator ==(Transform2D left, Transform2D right) => left.Equals(right);
        public static bool operator !=(Transform2D left, Transform2D right) => !(left == right);

        #endregion

    }
}
