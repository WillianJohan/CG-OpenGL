using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAPP_ComputacaoGrafica
{
    public class Transform : IEquatable<Transform>
    {
        Vector3 position;
        Vector3 rotation;
        Vector3 scale;

        #region Getters and Setters

        public Vector3 Position { get => position; set => position = value; }
        public Vector3 Rotation { get => rotation; }
        public Vector3 Scale { get => scale; set => scale = value; }

        #endregion
        
        #region Constructors

        public Transform()
        {
            position = Vector3.Zero;
            rotation = Vector3.Zero;
            scale = new Vector3(1, 1, 1);
        }

        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        #endregion

        #region Methods

        public void translate(Vector3 translation)
        {
            position = position + translation;
        }

        public void rotate(Vector3 rotation)
        {
            //not implemmented Yet
        }

        #endregion

        #region Operators
        
        public override bool Equals(object obj)                             => obj is Transform transform && Equals(transform);
        public bool Equals(Transform other)                                 => position.Equals(other.position) && rotation.Equals(other.rotation) && scale.Equals(other.scale);
        public static bool operator ==(Transform left, Transform right)     => left.Equals(right);
        public static bool operator !=(Transform left, Transform right)     => !(left == right);

        #endregion

    }
}
