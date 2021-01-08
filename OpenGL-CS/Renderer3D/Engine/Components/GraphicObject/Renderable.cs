using System;

namespace RendererEngine
{
    public abstract class Renderable : IDisposable
    {
        public Transform transform  { get; set; }
        public Shader shader        { get; protected set; }
        public Mesh mesh            { get; protected set; }
        public Material material    { get; protected set; }

        public unsafe void Load()
        {
            shader.Load();
            mesh.Load();
        }

        public void Dispose()
        {
            mesh.Dispose();
            shader.Dispose();
        }

    }
}
