using System.Numerics;
using static RendererEngine.OpenGL.GL;

namespace RendererEngine
{
    public class GameObject : Graphic
    {
        public string Name;

        #region Constructors

        public GameObject()
        {
            this.Name = "No Name Object";
            this.transform = new Transform();
        }

        public GameObject(string Name)
        {
            this.Name = Name;
            this.transform = new Transform();
        }

        public GameObject(string Name, Vector3 Position)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.transform.Position = Position;

        }

        public GameObject(string Name, Vector3 Position, Vector3 Rotation, Vector3 Scale)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.transform.Position = Position;
            this.transform.Rotation = Rotation;
            this.transform.Scale = Scale;
        }

        public GameObject(string Name, Transform transform)
        {
            this.Name = Name;
            this.transform = transform;
        }

        public GameObject(string Name, Transform transform, Mesh mesh)
        {
            this.Name = Name;
            this.transform = transform;
            this.mesh = mesh;
        }

        #endregion



    }
}
