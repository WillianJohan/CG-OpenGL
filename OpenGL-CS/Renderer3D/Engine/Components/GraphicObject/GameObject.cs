using System.Numerics;

namespace RendererEngine
{
    public class GameObject : Renderable
    {
        public string Name;

        #region Constructors

        public GameObject()
        {
            this.Name = "No Name Object";
            this.transform = new Transform();
            this.mesh = new Mesh();
            this.material = new Material();
            this.shader = new Shader();
        }

        public GameObject(string Name)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.mesh = new Mesh();
            this.material = new Material();
            this.shader = new Shader();
        }

        public GameObject(string Name, Vector3 Position)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.transform.Position = Position;
            this.mesh = new Mesh();
            this.material = new Material();
            this.shader = new Shader();
        }

        public GameObject(string Name, Vector3 Position, Vector3 Rotation, Vector3 Scale)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.transform.Position = Position;
            this.transform.Rotation = Rotation;
            this.transform.Scale = Scale;
            this.mesh = new Mesh();
            this.material = new Material();
            this.shader = new Shader();
        }

        public GameObject(string Name, Transform transform)
        {
            this.Name = Name;
            this.transform = transform;
            this.mesh = new Mesh();
            this.material = new Material();
            this.shader = new Shader();
        }

        public GameObject(string Name, Transform transform, Mesh mesh)
        {
            this.Name = Name;
            this.transform = transform;
            this.mesh = mesh;
            this.material = new Material();
            this.shader = new Shader();
        }

        public GameObject(string Name, Transform transform, Mesh mesh, Material material)
        {
            this.Name = Name;
            this.transform = transform;
            this.mesh = mesh;
            this.material = material;
            this.shader = new Shader();
        }

        #endregion

    }
}
