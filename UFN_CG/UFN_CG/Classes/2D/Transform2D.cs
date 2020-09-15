using System;

namespace UFN_CG
{
    public class Transform2D : IEquatable<Transform2D>
    {
        Vector2 position;
        Vector2 rotation;
        Vector2 scale;

        #region Getters and Setters

        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
            }
        }
        public Vector2 Rotation { get => rotation; }
        public Vector2 Scale
        {
            get => scale;
            set
            {
            }
        }

        #endregion

        #region Constructors

        public Transform2D()
        {
            position = Vector2.Zero;
            rotation = Vector2.Zero;
            scale = new Vector2(1, 1);
        }

        #endregion

        #region Methods

        public void Reset()
        {
            Position = Vector2.Zero;
            rotation = Vector2.Zero;
            Scale = new Vector2(1, 1);
        }

        public void translate(Vector2 t)
        {
            position = position + t;
        }


        public void rotate(Vector2 r)
        {
            this.rotation += r;
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
