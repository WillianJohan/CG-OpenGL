using System.Collections.Generic;

namespace RendererEngine
{
    public class Scene
    {
        public string SceneName { get; set; }
        public VirtualCamera virtualCamera  { get; set; }
        public List<GameObject> Objects     { get; set; }
        public SpotLight spotLight          { get; set; }

        #region Constructors
        public Scene()
        {
            this.SceneName = "Simple Scene";
            this.virtualCamera = new VirtualCamera();
            this.Objects = new List<GameObject>();
            this.spotLight = new SpotLight();
        }

        public Scene(string Name)
        {
            this.SceneName = Name;
            this.virtualCamera = new VirtualCamera();
            this.Objects = new List<GameObject>();
            this.spotLight = new SpotLight();
        }

        public Scene(string Name, VirtualCamera MainCamera)
        {
            this.SceneName = Name;
            this.virtualCamera = MainCamera;
            this.Objects = new List<GameObject>();
            this.spotLight = new SpotLight();
        }

        public Scene(string Name, VirtualCamera MainCamera, List<GameObject> Objects)
        {
            this.SceneName = Name;
            this.virtualCamera = MainCamera;
            this.Objects = Objects;
            this.spotLight = new SpotLight();
        }

        public Scene(string Name, VirtualCamera MainCamera, List<GameObject> Objects, SpotLight spotLights)
        {
            this.SceneName = Name;
            this.virtualCamera = MainCamera;
            this.Objects = Objects;
            this.spotLight = spotLight;
        }

        public Scene(string Name, List<GameObject> Objects)
        {
            this.SceneName = Name;
            this.virtualCamera = new VirtualCamera();
            this.Objects = Objects;
            this.spotLight = new SpotLight();
        }
        #endregion

        public void LoadContent()
        {
            //REVISAR
            foreach (GameObject obj in Objects)
                obj.Load();
        }

        public void DrawObjects()
        {
            foreach (GameObject obj in Objects)
            {
                //Activate Shader
                obj.shader.Use();

                //LIGHT
                obj.shader.setVector3("light_position", spotLight.transform.Position);
                obj.shader.setVector3("La", spotLight.La);
                obj.shader.setVector3("Ld", spotLight.Ld);
                obj.shader.setVector3("Ls", spotLight.Ls);

                //CAMERA
                obj.shader.SetMatrix4x4("view", virtualCamera.VisualizationMatrix);
                obj.shader.SetMatrix4x4("proj", virtualCamera.ProjectionMatrix);

                // APPLY TRANSFORMATIONS AND MATERIAL VALUES
                obj.mesh.Bind();
                
                obj.shader.setVector3("Ka", obj.material.AmbientReflection);      // SETTING MATERIAL VALUES
                obj.shader.setVector3("Kd", obj.material.DiffuseReflection);      // SETTING MATERIAL VALUES
                obj.shader.setVector3("Ks", obj.material.Specularreflection);     // SETTING MATERIAL VALUES
                obj.shader.setFloat("especular_exp", obj.material.especular_exp); // SETTING MATERIAL VALUES

                obj.shader.SetMatrix4x4("matriz", obj.transform.TransformationMatrix);
                obj.mesh.Draw();
            
            }
        }
    }
}
