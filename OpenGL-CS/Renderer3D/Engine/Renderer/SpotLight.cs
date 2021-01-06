using System.Numerics;
namespace RendererEngine
{
    public class SpotLight
    {
        public Transform transform;
        public Vector3 La { get; private set; }
        public Vector3 Ld { get; private set; }
        public Vector3 Ls { get; private set; }

        public SpotLight()
        {
            transform = new Transform();
            setLA(0.2f);
            setLD(0.7f);
            setLS(1.0f);
        }

        public SpotLight(Transform transform, Vector3 la, Vector3 ld, Vector3 ls)
        {
            this.transform = transform;
            La = la;
            Ld = ld;
            Ls = ls;
        }

        public SpotLight(Vector3 la, Vector3 ld, Vector3 ls)
        {
            transform = new Transform();
            La = la;
            Ld = ld;
            Ls = ls;
        }

        public void setLA(float LA) => La = new Vector3(LA);
        public void setLD(float LD) => Ld = new Vector3(LD);
        public void setLS(float LS) => Ls = new Vector3(LS);

    }
}
