using System.Collections.Generic;

namespace RendererEngine
{
    public class Scene
    {
        public string SceneName { get; set; }
        public static VirtualCamera virtualCamera { get; set; }
        public List<GameObject> Objects { get; set; }

        #region Constructors
        public Scene()
        {
            this.SceneName = "Simple Scene";
            virtualCamera = new VirtualCamera();
            this.Objects = new List<GameObject>();
        }

        public Scene(string Name)
        {
            this.SceneName = Name;
            virtualCamera = new VirtualCamera();
            this.Objects = new List<GameObject>();
        }

        public Scene(string Name, VirtualCamera MainCamera)
        {
            this.SceneName = Name;
            virtualCamera = MainCamera;
            this.Objects = new List<GameObject>();
        }

        public Scene(string Name, VirtualCamera MainCamera, List<GameObject> Objects)
        {
            this.SceneName = Name;
            virtualCamera = MainCamera;
            this.Objects = Objects;
        }

        public Scene(string Name, List<GameObject> Objects)
        {
            this.SceneName = Name;
            virtualCamera = new VirtualCamera();
            this.Objects = Objects;
        }
        #endregion

    }
}
