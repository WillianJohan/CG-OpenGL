using System.Numerics;

namespace RendererEngine
{
    public class Material
    {
        public Vector3 AmbientReflection {get; private set;}
        public Vector3 DiffuseReflection {get; private set;}
        public Vector3 Specularreflection {get; private set;}
        public float especular_exp { get; set; }

        public Material(Vector3 ambientReflection, Vector3 diffuseReflection, Vector3 specularreflection)
        {
            AmbientReflection = ambientReflection;
            DiffuseReflection = diffuseReflection;
            Specularreflection = specularreflection;
        }

        public Material()
        {
            setAmbientReflection(0.1f);
            setDiffuseReflection(0.1f);
            setSpecularreflection(1.0f);
            especular_exp = 20;
        }

        public void setAmbientReflection(float value) => AmbientReflection  = new Vector3(value);
        public void setDiffuseReflection(float value) => DiffuseReflection  = new Vector3(value);
        public void setSpecularreflection(float value) => Specularreflection = new Vector3(value);


        public void setAmbientReflection(Vector3 value) => AmbientReflection = value;
        public void setDiffuseReflection(Vector3 value) => DiffuseReflection = value;
        public void setSpecularreflection(Vector3 value) => Specularreflection = value;

    }
}
