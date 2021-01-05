using System.Collections.Generic;

namespace RendererEngine
{
    public class Scene
    {
        public string SceneName { get; set; }
        public static VirtualCamera virtualCamera { get; set; }
        public List<GraphicObject> Objects { get; set; }

        #region Constructors
        public Scene()
        {
            this.SceneName = "Simple Scene";
            virtualCamera = new VirtualCamera();
            this.Objects = new List<GraphicObject>();
        }

        public Scene(string Name)
        {
            this.SceneName = Name;
            virtualCamera = new VirtualCamera();
            this.Objects = new List<GraphicObject>();
        }

        public Scene(string Name, VirtualCamera MainCamera)
        {
            this.SceneName = Name;
            virtualCamera = MainCamera;
            this.Objects = new List<GraphicObject>();
        }

        public Scene(string Name, VirtualCamera MainCamera, List<GraphicObject> Objects)
        {
            this.SceneName = Name;
            virtualCamera = MainCamera;
            this.Objects = Objects;
        }

        public Scene(string Name, List<GraphicObject> Objects)
        {
            this.SceneName = Name;
            virtualCamera = new VirtualCamera();
            this.Objects = Objects;
        }
        #endregion

    }
}
