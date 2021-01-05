using System.Numerics;
using static RendererEngine.OpenGL.GL;

namespace RendererEngine
{
    public class GraphicObject : Graphic
    {
        public string Name { get; set; }
        public Transform transform;

        #region Constructors

        public GraphicObject()
        {
            this.Name = "No Name Object";
            this.transform = new Transform();
        }

        public GraphicObject(string Name)
        {
            this.Name = Name;
            this.transform = new Transform();
        }

        public GraphicObject(string Name, Vector3 Position)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.transform.Position = Position;

        }

        public GraphicObject(string Name, Vector3 Position, Vector3 Rotation, Vector3 Scale)
        {
            this.Name = Name;
            this.transform = new Transform();
            this.transform.Position = Position;
            this.transform.Rotation = Rotation;
            this.transform.Scale = Scale;
        }

        public GraphicObject(string Name, Transform transform)
        {
            this.Name = Name;
            this.transform = transform;
        }

        #endregion

        //Verificar nos codigos do professor como ele utiliza os shaders
        protected override void Renderer()
        {
            transform.Rotation.Z = System.MathF.Sin(Time.TotalElapsedSeconds) * System.MathF.PI * 1f;
            
            shader.SetMatrix4x4("model", transform.TransformationMatrix);
            shader.Use();
            shader.SetMatrix4x4("projection", Scene.virtualCamera.ProjectionMatrix);
            System.Console.WriteLine(Scene.virtualCamera.ProjectionMatrix);

            glBindVertexArray(base.vao);
            glDrawArrays(GL_TRIANGLES, 0, 6);

        }
    }
}
