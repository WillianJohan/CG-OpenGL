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
                for (int i = 0; i < mesh.vertices.Length; i++)
                    mesh.vertices[i] = mesh.vertices[i] - new Vector3(position) + new Vector3(value);

                position = value;
            }
        }
        public Vector2 Rotation { get => rotation; }
        public Vector2 Scale
        {
            get => scale;
            set
            {
                for (int i = 0; i < mesh.vertices.Length; i++)
                {
                    mesh.vertices[i].x = (mesh.vertices[i].x - position.x) * value.x + position.x;
                    mesh.vertices[i].y = (mesh.vertices[i].y - position.y) * value.y + position.y;
                }
                scale = value;
            }
        }

        #endregion

        #region Constructors

        public Transform2D()
        {
            position = Vector2.Zero;
            rotation = Vector2.Zero;
            scale = new Vector2(1, 1);

            mesh = new Mesh();
            mesh.vertices[0] = new Vector3(1, 1, 0);
            mesh.vertices[1] = new Vector3(-1, -1, 0);
        }

        #endregion

        #region Methods

        public void Reset()
        {
            Position = Vector2.Zero;
            rotation = Vector2.Zero;
            Scale = new Vector2(1, 1);

            mesh = new Mesh();
            mesh.vertices[0] = new Vector3(1, 1, 0);
            mesh.vertices[1] = new Vector3(-1, -1, 0);
        }

        public void translate(Vector2 t)
        {
            position = position + t;

            if (mesh.vertices.Length == 0) return;
            for (int i = 0; i < mesh.vertices.Length; i++)
                mesh.vertices[i] += new Vector3(t);
        }

        public void rotate(Vector2 r)
        {
            this.rotation += r;

            if (mesh.vertices.Length == 0) return;
            for (int i = 0; i < mesh.vertices.Length; i++)
            {
                float xo = mesh.vertices[i].x;
                float yo = mesh.vertices[i].y;

                mesh.vertices[i].x = (float)((xo - Position.x) * Math.Cos((double)r.x) - (yo - position.y) * Math.Sin((double)r.x)) + position.x;
                mesh.vertices[i].y = (float)((yo - Position.y) * Math.Cos((double)r.y) + (xo - position.x) * Math.Sin((double)r.y)) + position.y;
            }
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
