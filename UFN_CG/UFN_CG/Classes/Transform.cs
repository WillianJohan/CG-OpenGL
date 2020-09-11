using System;

namespace UFN_CG
{
    public class Transform : IEquatable<Transform>
    {
        Vector3 position;
        Vector3 rotation;
        Vector3 scale;

        //Mesh mesh;

        #region Getters and Setters

        public Vector3 Position
        {
            get => position;
            set
            {
                //for (int i = 0; i < mesh.vertices.Length; i++)
                //    mesh.vertices[i] = mesh.vertices[i] - position + value;

                position = value;
            }
        }
        public Vector3 Rotation { get => rotation; }
        public Vector3 Scale
        {
            get => scale; 
            set
            {
                //for (int i = 0; i < mesh.vertices.Length; i++)
                //{
                //    mesh.vertices[i].x = (mesh.vertices[i].x - position.x) * value.x + position.x;
                //    mesh.vertices[i].y = (mesh.vertices[i].y - position.y) * value.y + position.y;
                //    mesh.vertices[i].z = (mesh.vertices[i].z - position.z) * value.z + position.z;
                //}
                scale = value;
            }
        }
        
        //public Mesh Mesh { get => mesh; }

        #endregion

        #region Constructors

        public Transform()
        {
            position = Vector3.Zero;
            rotation = Vector3.Zero;
            scale = new Vector3(1, 1, 1);
            
            //mesh = new Mesh();
            //mesh.vertices[0] = new Vector3(1, 1, 0);
            //mesh.vertices[1] = new Vector3(-1, -1, 0);
        }

        #endregion

        #region Methods

        public void Reset()
        {
            Position = Vector3.Zero;
            rotation = Vector3.Zero;
            Scale = new Vector3(1, 1, 1);
        }

        public void translate(Vector3 translation)
        {
            position = position + translation;
            
            //if (mesh.vertices.Length == 0) return;
            //for (int i = 0; i < mesh.vertices.Length; i++)
            //    mesh.vertices[i] += translation;
        }

        public void rotate(Vector3 rotation)
        {
            this.rotation += rotation;
        }

        public void rotate(Vector3 Axis, float angle)
        {
            this.rotation += Axis * angle;
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
